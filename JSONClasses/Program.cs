﻿using System;
using System.IO;

namespace JSONClasses
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine(System.IO.File.ReadAllText(@"D:\ProgramData\JuniorMind\OOP\(1.) JSON\JSON_full - OOP\JSON - OOP"));

            if (args.Length != 1)
            {
                Console.WriteLine("Usage: program <path to json>");
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("{0} not found", args[0]);
                return;
            }

            string text = System.IO.File.ReadAllText(args[0]);
            var jsonObject = new Value();
            var match = jsonObject.Match(text);
            Console.Write(match.Success());
            Console.ReadLine();
        }
    }
}