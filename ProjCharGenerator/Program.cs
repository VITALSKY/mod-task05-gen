using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    class Task1
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private int amount = 0;
        private Random ran_obj = new Random();
        private int[,] np;

        public Task1(int[,] exampl)
        {
            int m;
            int n;
            size = syms.Length;
            data = syms.ToCharArray();
            int amount2 = 0;
            if (size != 0)
            {
                for (m = 0; m < size; m++)
                {
                    for (n = 0; n < size; n++)
                    {
                        amount = amount + exampl[m, n];
                    }
                }
            }
            np = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    amount2 = amount2 + exampl[i, j];
                    np[i, j] = amount2;
                }
            }
        }
        public string getOutput()
        {
            int iterations = 0;
            string output = "";
            while(iterations!=1000)
            {
                output += getSym();
                if (iterations != 999)
                {
                    output += ' ';
                }
                iterations++;
            }
            return output;
        }
        public string getSym()
        {
            int i = 0;
            int j = 0;
            int m = ran_obj.Next(0, amount);
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (m < np[i, j])
                        return data[i].ToString() + data[j].ToString();
                }
            }

            return data[i].ToString() + data[j].ToString();
        }
    }
    class Task2
    {
        private string[] data;
        private int size;
        private Random ran_obj = new Random();
        private int[] np;
        private int amount = 0;

        public Task2(string[] words)
        {
            data = words;
            size = words.Length;
            np = new int[size];
            int i = 0;
            while(i != size)
            {
                amount += i;
                np[i] = amount;
                i++;
            }
            
        }
        public string getWords()
        {
            int m = ran_obj.Next(0, amount);
            int j = 0;
            while(j!=size)
            {
                if (np[j] > m)
                    break;
                else
                    j++;
            }
            return data[j];
        }
        public string getOutput()
        {
            int iterations = 0;
            string output = "";
            while (iterations != 1000)
            {
                output += getWords();
                if (iterations != 999)
                {
                    output += ' ';
                }
                iterations++;
            }
            return output;
        }
    }
    class Task3
    {
        private string[] data;
        private int size;
        private Random ran_obj = new Random();
        private int[] np;
        private int amount = 0;

        public Task3(string[] words)
        {
            data = words;
            size = words.Length;
            np = new int[size];
            int i = 0;
            while(i != size)
            {
                amount += i;
                np[i] = amount;
                i++;
            }
        }
        public string getTwoWords()
        {
            int m = ran_obj.Next(0, amount);
            int j = 0;
            while (j != size)
            {
                if (np[j] > m)
                    break;
                else
                    j++;
            }
            return data[j];
        }
        public string getOutput()
        {
            int iterations = 0;
            string output = "";
            while (iterations != 1000)
            {
                output += getTwoWords();
                if (iterations != 999)
                {
                    output += ' ';
                }
                iterations++;
            }
            return output;
        }
    }
    class CharGenerator 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator() 
        {
           size = syms.Length;
           data = syms.ToCharArray(); 
        }
        public char getSym() 
        {
           return data[random.Next(0, size)]; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
               char ch = gen.getSym(); 
               if (stat.ContainsKey(ch))
                  stat[ch]++;
               else
                  stat.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat) 
            {
                 Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            }

            ///////////////////////////////////////////////////////////////
            string[] task2_words = File.ReadAllLines("Task2_words.txt");
            Task2 wordFrequency = new Task2(task2_words);
            string task2 = wordFrequency.getOutput();
            File.WriteAllText("t2.txt", task2);


            ///////////////////////////////////////////////////////////////
            string[] task3_word_two = File.ReadAllLines("Task3_words.txt");
            Task3 frequencyOfTwoWords = new Task3(task3_word_two);
            string task3 = frequencyOfTwoWords.getOutput();
            File.WriteAllText("t3.txt", task3);


            ///////////////////////////////////////////////////////////////
            string[] matrix_taskOne = File.ReadAllLines("matrix_taskOne.txt");
            int[,] chastota = new int[matrix_taskOne.Length, matrix_taskOne[0].Split(' ').Length];
            int k = 0;
            while (k != matrix_taskOne.Length)
            {
                string[] temp = matrix_taskOne[k].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    chastota[k, j] = Convert.ToInt32(temp[j]);
                k++;
            }
            Task1 bigram = new Task1(chastota);
            string task1 = bigram.getOutput();
            File.WriteAllText("t1.txt", task1);




        }
    }
}

