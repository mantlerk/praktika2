using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktica2._2
{
    class Program
    {
        static async Task Main() //начало
        {
            while (true) // Бесконечный цикл
            {
                Console.WriteLine("Выберите задачу для выполнения:");
                Console.WriteLine("1 - Задача 1");
                Console.WriteLine("2 - Задача 2");
                Console.WriteLine("3 - Задача 3");
                Console.WriteLine("0 - Выйти");

                string choice = Console.ReadLine();
                Task selectedTask = null;

                switch (choice)
                {
                    case "1":
                        selectedTask = Task1();
                        break;
                    case "2":
                        selectedTask = Task2();
                        break;
                    case "3":
                        selectedTask = Task3();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                        break;
                }

                if (selectedTask != null)
                {
                    await selectedTask;
                    Console.WriteLine("Задача завершена.");
                }

                Console.WriteLine("Все задачи завершены.");
            }
        }
        /*{
            Task task1 = Task1(); //Задача 1
            Task task2 = Task2(); //Задача 2
            Task task3 = Task3(); //Задача 3

            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("Все задачи завершены.");
        }*/

        static async Task Task1() // Задача 1
        {
            // Вывод массива на экран
            Console.WriteLine("Задача 1: Заполнение массива по размерности N:");
            System.Console.OutputEncoding = System.Text.Encoding.UTF8; // codirovka

            Console.Write("Введите размер массива N: ");
            int N = int.Parse(Console.ReadLine());

            // Создаем массив размерности N
            int[] array = new int[N];

            // Заполняем массив числами от 1 до N
            for (int i = 0; i < N; i++)
            {
                array[i] = i + 1;
            }

            // Выводим элементы массива в обратном порядке
            Console.WriteLine("Элементы массива в обратном порядке:");
            for (int i = N - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static async Task Task2() // Задача 2
        {
            int size = 5; // Размерность массива
            //int colums = 5;
            int[,] squareArray = new int[size, size]; // Объявление квадратного массива

            // Заполнение массива по заданному шаблону
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j >= i) // Условие для заполнения единицами и нулями
                    {
                        squareArray[i, j] = 1;
                    }
                    else
                    {
                        squareArray[i, j] = 0;
                    }
                }
            }

            // Вывод массива на экран
            Console.WriteLine("\nЗадача 2: Заполнение массива по шаблону:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(squareArray[i, j] + " "); // Вывод элемента массива с пробелом
                }
                Console.WriteLine(); // Переход на новую строку после каждой строки массива
            }
        }
        static async Task Task3() // Задача 3
        {
            int n = 5; // Размерность массива
            int[,] spiralArray = new int[n, n];

            FillSpiral(spiralArray, n);
            Console.WriteLine("\nЗадача 3: Заполнение массива спиралью:");
            PrintArray(spiralArray);
        }

        static void FillSpiral(int[,] array, int n)
        {
            int value = 1;
            int top = 0, bottom = n - 1, left = 0, right = n - 1;

            while (value <= n * n)
            {
                // Заполнение верхней строки
                for (int i = left; i <= right; i++)
                {
                    array[top, i] = value++;
                }
                top++;

                // Заполнение правого столбца
                for (int i = top; i <= bottom; i++)
                {
                    array[i, right] = value++;
                }
                right--;

                // Заполнение нижней строки
                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        array[bottom, i] = value++;
                    }
                    bottom--;
                }

                // Заполнение левого столбца
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        array[i, left] = value++;
                    }
                    left++;
                }
            }
        }

        static void PrintArray(int[,] array)
        {
            int n = array.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
