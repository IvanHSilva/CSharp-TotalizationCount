using System;
using System.Collections.Generic;
using System.IO;

namespace TotalizationCount {
    internal class Program {
        static void Main(string[] args) {

            string path = "E:\\DEV-Files\\C#\\";
            string file = "Prize.txt";
            Dictionary<string, int> map = new Dictionary<string, int>();

            try {
                Console.WriteLine("Participantes/subtotais:");
                using (StreamReader sr = new StreamReader($"{path}{file}")) {
                    while (!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        string[] vect = line.Split(',');
                        string name = vect[0];
                        int count = int.Parse(vect[1]);

                        if (map.ContainsKey(name)) {
                            map[name] += count;
                        } else {
                            map[name] = count;
                        }
                        Console.WriteLine(line);
                    }
                };
                Console.WriteLine();

                Console.WriteLine("Totais:");
                foreach (KeyValuePair<string, int> item in map) {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                Console.WriteLine();
            } catch (IOException e) {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}
