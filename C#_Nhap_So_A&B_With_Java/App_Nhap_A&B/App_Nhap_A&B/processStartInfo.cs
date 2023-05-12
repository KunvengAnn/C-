using System.Diagnostics;

namespace App_Nhap_A_B
{
    internal class processStartInfo
    {
        internal bool useShellExecute;

        public processStartInfo()
        {
        }

        public bool CreateNoWindow { get; internal set; }
        public string FileName { get; internal set; }
        public ProcessWindowStyle WindowStyle { get; internal set; }
        public bool RedirectStandarndOutput { get; internal set; }
        public string WorkingDirectory { get; internal set; }
        public string Arguments { get; internal set; }
    }
}