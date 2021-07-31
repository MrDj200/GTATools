using System;
using System.Windows.Input;

namespace Tests
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Keyboard.IsKeyToggled(Key.A));
            }
            Console.ReadLine();
        }
    }
}
