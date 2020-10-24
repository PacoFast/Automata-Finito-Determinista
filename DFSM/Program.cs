 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DFSM
{
    class Program
    {
        static List<Transition> transitionTable = new List<Transition>(); 
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa la variable: ");
            string input = Console.ReadLine();
            FileManagment file = new FileManagment();

            foreach (Transition element in file.getTable())
            {
                transitionTable.Add(element);
            }

            if (recognizeTable(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"\n{input} fue ACEPTADA");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{input} fue RECHAZADA");
            }
        }
        public static bool recognizeTable(string input)
        {
            string currentState = "q1";
            string builder = String.Empty; 
            foreach(char c in input.ToCharArray())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Transition transition = transitionTable.Find(t => t.StartState == currentState &&
                                                       t.Symbol == getToken(c));

                if(transition == null)
                {
                    return false; 
                }

                currentState = transition.EndState;
                Console.WriteLine("Transiciones:");
                Console.WriteLine($"({transition.StartState}, {c}) -> {transition.EndState}");

            }
            return currentState == "q2";
        }

        public static char getToken(char symbol)
        {
            if (char.IsDigit(symbol))
                return 'd';
            else if (char.IsLetter(symbol))
                return 'l';
            else if (symbol == '_')
                return '_';
            else
                return 'e'; 
        }

        

       

    }

    
   

}
