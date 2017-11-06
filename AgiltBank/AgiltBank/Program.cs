using System;
using AgiltBank.States;

namespace AgiltBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            context.State = new Home();
        }
    }
}
