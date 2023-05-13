using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

public class QuickSort
{
    static void Main()
    {
        string filePath = "data.txt"; // путь к файлу
        int[] array = ReadDataFromFile(filePath); // считываем данные из файла
        QuickSortAlgorithm(array, 0, array.Length - 1); // сортируем данные
        Console.WriteLine("Отсортированый массив по возрастанию: {0}", string.Join(" ", array));
        Array.Reverse(array);
        Console.WriteLine("Отсортированый массив по убыванию: {0}", string.Join(" ", array));
    }

    //Считывание данных из файла и формирование масcива чисел
    public static int[] ReadDataFromFile(string filePath)
    {
        string lines = File.ReadAllText(filePath).ToString(); // считываем все строки из файла в одну
        
        var numbers = Regex.Matches(lines, @"(0$|-?[1-9]\d*)").Cast<Match>().Select(x => int.Parse(x.Value)).ToArray(); // cчитываем все числа из строки в масивв чисел типа string
        int n = Convert.ToInt32(numbers[0]); //присваиваем нуливой элемент масива чисел к переменной обозночающей количество элементов в массиве
        int from = Convert.ToInt32(numbers[1]); //присваиваем первый элемент масива чисел к переменной обозночающей диапазон рандома От
        int before = Convert.ToInt32(numbers[2]); //присваиваем первый элемент масива чисел к переменной обозночающей диапазон рандома До
        int[] array = new int[n]; //создаём массив элементво
        Random random = new Random(); //создаём объект для генерации случайных чисел
        for (int i = 0; i < n; i++)
        {
            array[i] = random.Next(from, before); //присваиваем элементу массива array[i] рандомное значение от и до
        }
        Console.WriteLine("Не отсортированый массив: {0}", string.Join(" ", array));
        return array;
    }


    public static void QuickSortAlgorithm(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right); 
            QuickSortAlgorithm(array, left, pivotIndex - 1); 
            QuickSortAlgorithm(array, pivotIndex + 1, right); 
        }
    }

    //Поиск опорного элемента и перемещение меньше и большего элемента между собой
    public static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right]; // опорный элемент - последний элемент в массиве
        int i = left - 1; // индекс элемента, который будет перемещен на место опорного
        for (int j = left; j < right; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j); // перемещаем элемент в левую часть массива
            }
        }
        Swap(array, i + 1, right); // перемещаем опорный элемент на свое место
        return i + 1;
    }

    //Перестановка элементов
    public static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}