using System;
using System.Collections.Generic;
using System.Text;
using AgiltBank.Frontend.States;

namespace AgiltBank.Frontend
{
    public class StateContext
    {
        public StateContext()
        {
            State = new Home();
        }

        public IState State { get; set; }
    }
}
