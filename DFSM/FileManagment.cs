using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DFSM
{
    class FileManagment
    {
        StreamReader sr = null;
        List<Transition> transitions = null;
        string line; 
        public FileManagment()
        {
            sr = new StreamReader(@"C:\test.txt");
        }

        public List<Transition> getTable()
        {
            transitions = new List<Transition>(); 
            while((line = sr.ReadLine()) != null)
            {
                var transition = line.Split(" ");
                string startState = transition[0];
                char c = transition[1].ToString()[0];
                string endState = transition[2];
                Transition transition1 = new Transition(startState, c, endState);
                transitions.Add(transition1);
            }
            return transitions; 
        }

        ~FileManagment()
        {
            sr.Close(); 
        }

    }
}
