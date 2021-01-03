using System.Diagnostics;

namespace GTATools
{
    class FirewallRule
    {
        public string Name { get; private set; }

        private string GamePath;
        public FirewallRule(string path, string ruleName = "DjsLagSwitch")
        {
            Name = ruleName;
            GamePath = path;
            // Add rule. if exists, readd
        }

        public void Block()
        {
            Create();
        }

        public void Unblock()
        {
            Delete();
        }

        private void Create()
        {
            ProcessStartInfo blockInInfo = new ProcessStartInfo("cmd.exe");
            ProcessStartInfo blockOutInfo = new ProcessStartInfo("cmd.exe");

            blockInInfo.WindowStyle = ProcessWindowStyle.Hidden;
            blockOutInfo.WindowStyle = ProcessWindowStyle.Hidden;

            blockInInfo.Arguments = $"/C netsh advfirewall firewall add rule name=\"{Name}\" dir=in action=block program=\"{GamePath}\" enable=yes";
            blockOutInfo.Arguments = $"/C netsh advfirewall firewall add rule name=\"{Name}\" dir=out action=block program=\"{GamePath}\" enable=yes";

            Process.Start(blockInInfo);
            //System.Console.WriteLine($"Block in : {blockInInfo.Arguments}");
            Process.Start(blockOutInfo);
            //System.Console.WriteLine($"Block out: {blockOutInfo.Arguments}");
        }

        private void Delete()
        {
            ProcessStartInfo deleteRulesInfo = new ProcessStartInfo("cmd.exe")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = $"/C netsh advfirewall firewall delete rule name=\"{Name}\" program=\"{GamePath}\""
            };

            Process.Start(deleteRulesInfo);
            //System.Console.WriteLine($"\nDelete: {deleteRulesInfo.Arguments}");
        }
    }
}
