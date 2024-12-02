using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()//Массив строк string[] args нигде не применяется, это лишний код
    {
        string text = "Это пример текста. Текст должен быть проанализирован. Это важно.";
        Dictionary<string, int> wordCounts = WordFrequency(text);

        foreach (var item in wordCounts)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }

    static Dictionary<string, int> WordFrequency(string text)
    {
        string[] words = text.Split(' ');
        Dictionary<string, int> result = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            // Метод Trim() был пустым, а программа выводила некоторые слова с точкой в конце. Поэтому я добавил в условие метода '.', чтобы он обрезал ненужные символы.
            string word = words[i].Trim('.').ToLower(); 

            if (result.ContainsKey(word))
            {
                result[word] += 1; //result[word] = result[word] + 1 можно упростить
            }
            else
            {
                result.Add(word, 1);
            }
        }

        //Данный код перебирает значения из result и копирует их в новый словарь, при этом ничего не сортируя (судя по названию словаря) и затем возвращается в метод Main.
        //Эта операция увеличивает продолжительность выполнения кода, и ухудшает читаемость.
        
        /*Dictionary<string, int> sortedResult = new Dictionary<string, int>();
        foreach (var item in result)
        {
            sortedResult.Add(item.Key, item.Value);
        }*/
        return result; //Возвращаем result вместо sortedResult
    }
}