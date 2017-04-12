using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net_Example_2
{
    class Program
    {
        #region Задание
        //9. Создать класс четырехугольник, члены класса – координаты 4-х точек. 
        //Предусмотреть в классе методы вычисления и вывода сведений о фигуре – длины сторон, диагоналей, периметр, площадь. 
        //Создать производный класс – равнобочная трапеция, предусмотреть в классе проверку, является ли фигура равнобочной трапецией.
        //Написать программу, демонстрирующую работу с классом: дано N четырехугольников и M трапеций, 
        //найти максимальную площадь четырехугольников и количество четырехугольников, имеющих максимальную площадь, 
        //и трапецию с наименьшей диагональю.
        #endregion 

        static void Main(string[] args)
        {
            #region Переменные
            // Количество четырёхугольников
            int N = 0;
            // Количество равнобочных трапеций
            int M = 0;

            // Массив точек для вигуры
            Point[] points = new Point[4];
            // Координаты точки по х
            double x = 0;
            // Координаты точки по у
            double y = 0;

            // Максимальная площадь среди четырехугольников
            double maxQuadrangleS = 0;
            // Кол-во четырёхуугольников с максимальной площадью
            long countQuadranglesWithMaxS = 0;

            // Индекс трапеция с минимальной длиной трапеции 
            long indexMinDiagonalForTrapezoid = 0;
            // Минимальная длина диагонали трапеции
            double minDiagonalForTrapezoid = long.MaxValue;

            // Коллекция четырёхугольников
            List<Quadrangle> QuadrangleList = new List<Quadrangle>();
            // Коллекция равнобочных трапеций
            List<IsoscelesTrapezoid> IsoscelesTrapezoidList = new List<IsoscelesTrapezoid>();
            #endregion
            
            #region Вводим данные о количестве фигур
            while (true)
            {
                try
                {
                    Console.Write("Укажите количество четырёхугольников : ");
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N < 0)
                    {
                        Console.WriteLine("Количество не может быть отрицательным");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка при вводе");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Укажите кооличество равнобочных трапеций : ");
                    M = Convert.ToInt32(Console.ReadLine());
                    if (M < 0)
                    {
                        Console.WriteLine("Количество не может быть отрицательным");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка при вводе");
                }
            }
            #endregion

            #region Вводим данные о четырехугольниках
            Console.WriteLine("Ввод данных о четырехугольниках : ");
            for (int i = 0; i < N; )
            {
                for (int j = 0; j < 4; )
                {
                    try
                    {
                        Console.Write("Четырёхугольник {0}; Введите координаты {1} точки x: ", (i + 1), (j + 1));
                        x = Double.Parse(Console.ReadLine());
                        Console.Write("Четырёхугольник {0}; Введите координаты {1} точки y: ", (i + 1), (j + 1));
                        y = Double.Parse(Console.ReadLine());

                        points[j] = new Point(x, y);
                        ++j;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при вводе");
                    }
                }
                QuadrangleList.Add(new Quadrangle(points[0], points[1], points[2], points[3]));
                ++i;
            }
            #endregion

            #region Вводим данные о равнобочных трапециях
            Console.WriteLine("Ввод данных о равнобочных трапециях : ");
            for (int i = 0; i < M; )
            {
                for (int j = 0; j < 4; )
                {
                    try
                    {
                        Console.Write("Равнобочная трапеция {0}; Введите координаты {1} точки x: ", (i + 1), (j + 1));
                        x = Double.Parse(Console.ReadLine());
                        Console.Write("Равнобочная трапеция {0}; Введите координаты {1} точки y: ", (i + 1), (j + 1));
                        y = Double.Parse(Console.ReadLine());

                        points[j] = new Point(x, y);
                        ++j;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при вводе");
                    }
                }
                IsoscelesTrapezoidList.Add(new IsoscelesTrapezoid(points[0], points[1], points[2], points[3]));
                ++i;
            }
            #endregion

            #region Вывод данных о четырёугольникаах
            for (int i = 0; i < QuadrangleList.Count; i++)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Четырёхугольник {0} : ", i + 1);
                Console.WriteLine(QuadrangleList[i].GetInfoAboutFigure());
                Console.WriteLine("-----------------------------------");
            }
            #endregion

            #region Вывод данных о равнобедренных трапециях
            for (int i = 0; i < IsoscelesTrapezoidList.Count; i++)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Равнобедренная трапеция {0} : ", i + 1);
                Console.WriteLine(IsoscelesTrapezoidList[i].GetInfoAboutFigure());
                Console.WriteLine("-----------------------------------");
            }
            #endregion

            #region Находим максимальную площадь среди четырёхугольнико
            // Считаем максимальную площадь среди четырёхугольников
            for (int i = 0; i < QuadrangleList.Count; i++)
                if (QuadrangleList[i].S >= maxQuadrangleS)
                    maxQuadrangleS = QuadrangleList[i].S;
            #endregion

            #region Считаем четырёхуголники с масимальной площадью
            for (int i = 0; i < QuadrangleList.Count; i++)
                if (QuadrangleList[i].S == maxQuadrangleS)
                    ++countQuadranglesWithMaxS;
            #endregion

            #region Находим трапецию с минимальной диагональю
            for (int i = 0; i < IsoscelesTrapezoidList.Count; i++)
            {
                if (IsoscelesTrapezoidList[i].BD_length < minDiagonalForTrapezoid)
                {
                    minDiagonalForTrapezoid = IsoscelesTrapezoidList[i].BD_length;
                    indexMinDiagonalForTrapezoid = i;
                }
            }
            #endregion

            #region  Выводим результаты по заданию
            Console.WriteLine("Количество четырёхугольников с макс. площадью {0} - {1} четырёхугольников",
                maxQuadrangleS, countQuadranglesWithMaxS);
            Console.WriteLine("Трепеция с минимальной длиной диагонали ({0}) - {1} трапеция",
                Math.Round(minDiagonalForTrapezoid, 3), indexMinDiagonalForTrapezoid + 1);
            #endregion

            // Задержка выполнения
            Console.ReadLine();
        }
    }
}
