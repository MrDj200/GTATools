using System.Runtime.InteropServices;

namespace GTATools
{
    class KeyStates
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public static bool ScrollLock
        {
            get
            {
                return (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
            }
        }
    }
}
