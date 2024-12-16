using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string text = "Это пример текста. Текст должен быть проанализирован. Это важно.";
        Dictionary<string, int> wordCounts = WordFrequency(text);

        foreach (var item in wordCounts)
        {
            //Вместо Console.WriteLine(item.Key + ": " + item.Value);
            //Тут можно добавить интерполяцию строк, так будет легче читать код
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static Dictionary<string, int> WordFrequency(string text)
    {
        string[] words = text.Split(' ');
        Dictionary<string, int> result = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            // Добавив в условие Trim '.', он стал обрезать ненужный символ, т.е. выводить слова без точки перед :
            string word = words[i].Trim('.').ToLower();

            if (result.ContainsKey(word))
            {
                //Было result[word] = result[word] + 1; Но можно сделать проще += 1;
                result[word] += 1;
            }
            else
            {
                result.Add(word, 1);
            }
        }

        //SortedResult просто перебирал массив result и копировал в новый, не делая никакой сортировки 
        //Этот кусок кода значительно замедляет процесс выполнения программы и делает код менее читабельным

        /*Dictionary<string, int> sortedResult = new Dictionary<string, int>();
        foreach (var item in result)
        {
            sortedResult.Add(item.Key, item.Value);
        }

        return sortedResult;*/

        //Возвратим result вместо sortedResult
        return result;
    }
}