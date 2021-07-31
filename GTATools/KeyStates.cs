using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace GTATools
{
    class KeyStates
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern ushort GetKeyState(int keyCode); // Originally return type of short

        public static bool ScrollLock
        {
            get
            {
                //return (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
                return (GetKeyState((int)Keys.Scroll) & 0xffff) != 0;
            }
        }
        
        public static bool WheelspinHotkey
        {
            get
            {
                var keyCode = (int)Properties.Settings.Default.WheelspinKey; // Fetching the current settings
                Key converted = KeyInterop.KeyFromVirtualKey(keyCode); // Converting winforms key to keyboard key
                return Keyboard.IsKeyToggled(converted);

                //return (GetKeyState(keyCode) & 0xffff) != 0;
            }
        }
    }
}
