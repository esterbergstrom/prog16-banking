using System;
using AgiltBank.Frontend;

namespace AgiltBank
{
    class Program
    {
        public static StateContext StateContext { get; set; }

        static void Main(string[] args)
        {
            StateContext = new StateContext();

            Console.WriteLine("Hello World!");
        }
    }
}
