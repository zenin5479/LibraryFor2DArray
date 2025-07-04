using System;
using System.IO;
using System.Text;

namespace LibraryFor2DArray
{
   public class VariousMethods
   {

      public static int SizeRow(string nameArray)
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество строк массива {0}:", nameArray);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int SizeColumn(string nameArray)
      {
         int m;
         do
         {
            Console.WriteLine("Введите количество столбцов массива {0}:", nameArray);
            int.TryParse(Console.ReadLine(), out m);
            //m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0 || m > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (m <= 0 || m > 20);

         return m;
      }

      public static double[,] VvodArray(string path, string nameFile)
      {
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null || allLines.Length == 0)
         {
            Console.WriteLine("Ошибка содержимого файла для чтения {0}", nameFile);
            //Console.WriteLine("Ошибка содержимого файла для чтения {0}. Файл пуст", nameFile);
         }
         else
         {
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               indexLines++;
            }

            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter != line[countCharacter])
                     {
                        stringModified.Append(line[countCharacter]);
                     }
                     else
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        stringModified.Clear();
                        column++;
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               column = 0;
               row++;
            }
         }

         return arrayDouble;
      }

      public static double[,] InputArray(double[,] inputArray, int n, int m, string nameArray)
      {
         Console.WriteLine("Двумерный массив вещественных чисел {0}:", nameArray);
         double[,] outputArray = new double[n, m];
         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < m; j++)
            {
               outputArray[i, j] = inputArray[i, j];
               Console.Write("{0} ", outputArray[i, j]);
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
            }

            Console.WriteLine();
         }

         return outputArray;
      }

      public static bool SearchingPositiv(double[,] search)
      {
         bool fl = true;
         int i = 0;
         while (i < search.GetLength(0) && fl)
         {
            int j = 0;
            while (j < search.GetLength(1) && fl)
            {
               if (search[i, j] > 0)
               {
                  fl = false;
               }
               else
               {
                  j++;
               }
            }

            i++;
         }

         return fl;
      }

      public static double SearchingMinPositiv(double[,] search, string nameArray)
      {
         double min = search[0, 0];
         int i = 0;
         while (i < search.GetLength(0))
         {
            int j = 0;
            while (j < search.GetLength(1))
            {
               if (min < 0 && search[i, j] > min)
               {
                  min = search[i, j];
               }

               if (search[i, j] > 0 && search[i, j] < min)
               {
                  min = search[i, j];
               }

               j++;
            }

            i++;
         }

         Console.WriteLine("Минимальное значение среди положительных элементов двумерного массива {0}: {1}", nameArray, min);
         //Console.WriteLine("Минимальное значение среди положительных элементов двумерного массива {0}: {1:f2}", nameArray, min);
         //Console.WriteLine("Минимальное значение среди положительных элементов двумерного массива {0}: {1:f}", nameArray, min);
         return min;
      }

      public static double CalculatingValue(double minOne, double minTwo, double minThree)
      {
         return minOne * minTwo - minThree;
      }

      public static string[] VivodString(double input)
      {
         // Конвертация double в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         stringModified.Append(input);
         string line = stringModified.ToString();
         Console.WriteLine(line);
         string[] stringArray = { line };
         return stringArray;
      }

      public static void FileWriteString(string[] stringArray, string nameFile)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         string filePath = AppContext.BaseDirectory + nameFile;
         File.WriteAllLines(filePath, stringArray);
      }

      public static int SizeRow()
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество строк массива А");
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int SizeColumn()
      {
         int m;
         do
         {
            Console.WriteLine("Введите количество столбцов массива А");
            int.TryParse(Console.ReadLine(), out m);
            //m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0 || m > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (m <= 0 || m > 20);

         return m;
      }

      public static double[,] InputArray(double[,] inputArray, int n, int m)
      {
         Console.WriteLine("Двумерный числовой массив для проведения поиска");
         double[,] outputArray = new double[n, m];
         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < m; j++)
            {
               outputArray[i, j] = inputArray[i, j];
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               Console.Write("{0} ", outputArray[i, j]);
            }
            Console.WriteLine();
         }

         return outputArray;
      }

      public static double[,] VvodArray(int n, int m)
      {
         string filePath = AppContext.BaseDirectory + "a.txt";
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(filePath);
         if (allLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            Console.WriteLine("Исходный массив строк");
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               Console.WriteLine(allLines[indexLines]);
               indexLines++;
            }

            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               //Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter != line[countCharacter])
                     {
                        stringModified.Append(line[countCharacter]);
                     }
                     else
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDouble[row, column] + " ");
                        stringModified.Clear();
                        column++;
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDouble[row, column]);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               Console.WriteLine();
               column = 0;
               row++;
            }
            Console.ResetColor();
         }

         return arrayDouble;
      }

      public static double[] FindMax(double[,] inputArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         double[] arrayMax = new double[inputArray.GetLength(0)];
         int rowOut = 0;
         int columnOut = 0;
         while (rowOut < inputArray.GetLength(0))
         {
            // Cчитаем, что максимум - это первый элемент строки
            double maxOut = inputArray[rowOut, 0];
            while (columnOut < inputArray.GetLength(1))
            {
               if (maxOut < inputArray[rowOut, columnOut])
               {
                  maxOut = inputArray[rowOut, columnOut];
               }

               columnOut++;
            }

            arrayMax[rowOut] = maxOut;
            //Console.WriteLine("Максимум в строке {0} равен: {1}", rowOut, maxOut);
            columnOut = 0;
            rowOut++;
         }

         Console.WriteLine("Массив максимальных значений строк");
         int indexMax = 0;
         while (indexMax < arrayMax.Length)
         {
            Console.Write("{0} ", arrayMax[indexMax]);
            indexMax++;
         }

         Console.WriteLine();
         return arrayMax;
      }

      // Обновлен метод + 
      public static string[] VivodStringArray(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < inputArray.Length)
         {
            if (row != inputArray.Length - 1)
            {
               stringModified.Append(inputArray[row] + " ");
            }
            else
            {
               stringModified.Append(inputArray[row]);
            }

            row++;
         }

         Console.WriteLine(stringModified);
         string[] stringArray = { stringModified.ToString() };
         return stringArray;
      }

      public static void FileWriteString(string[] stringArray)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         string filePath = AppContext.BaseDirectory + "b.txt";
         File.WriteAllLines(filePath, stringArray);
      }
      
      // Обновлен метод + 
      public static string[] VivodArrayString(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.Length];
         int row = 0;
         while (row < inputArray.Length)
         {
            stringModified.Append(inputArray[row]);
            string subLine = stringModified.ToString();
            arrayString[row] = subLine;
            Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static void FileWriteArray(string[] arrayString)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         string filePath = AppContext.BaseDirectory + "c.txt";
         File.WriteAllLines(filePath, arrayString);
      }
   }
}