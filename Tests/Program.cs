using System;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Events;

namespace Tests
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Task.Delay(1000).Wait();
            Simulate.Events().Hold(KeyCode.S).Wait(1000).Release(KeyCode.S).Invoke().Wait();
            Console.ReadLine();
        }
    }
}
