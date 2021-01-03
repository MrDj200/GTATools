using System;
using System.Threading;
using System.Windows.Forms;

namespace GTATools
{
    class LagHandler
    {
        public static RadioButton Button { get; set; }
        public static void DoShit()
        {
            bool state = KeyStates.ScrollLock;
            while (Button != null)
            {
                if (KeyStates.ScrollLock && !state)
                {
                    //fw.Block();                    
                    state = KeyStates.ScrollLock;
                    Button.Checked = state;
                    System.Media.SystemSounds.Hand.Play();
                }
                else if (!KeyStates.ScrollLock && state)
                {
                    //fw.Unblock();
                    state = KeyStates.ScrollLock;
                    Button.Checked = state;
                }
                Console.Title = $"Is Lagging: {state}";
                Thread.Sleep(100);
            }
        }
    }
}
