using System;
using System.Collections.Generic;
using System.Text;

namespace DFSM
{
    class Transition
    {
        public string StartState { get;  set;}

        public char Symbol { get;  set;  }
        public string EndState { get;  set;}

        public Transition(string StartState, char Symbol,  string EndState)
        {
            this.StartState = StartState;
            this.EndState = EndState;
            this.Symbol = Symbol;
        }

        public override string ToString()
        {
            return string.Format($"Estado inicial: {StartState} || Estado final: {EndState}");
        }

    }
}
