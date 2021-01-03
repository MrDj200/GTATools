using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Process gtaProc = Process.GetProcessesByName("GTA5").FirstOrDefault();
            Console.WriteLine(gtaProc == null);
            Console.ReadLine();
        }
    }
}
