using System.Diagnostics;

namespace GTAToolsHelper
{
    public static class Utils
    {
        public static void test()
        {
            var processes = Process.GetProcessesByName("GTA5.exe");
        }
    }
}
