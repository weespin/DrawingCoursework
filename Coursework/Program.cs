using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Coursework
{

	static class Program
	{
		private enum DpiAwareness
		{
			None = 0,
			SystemAware = 1,
			PerMonitorAware = 2
		}
		// I have 4k monitor, i don't want to see blurry a image
		// According to https://msdn.microsoft.com/en-us/library/windows/desktop/dn280512(v=vs.85).aspx
		[DllImport("Shcore.dll")]
		static extern int SetProcessDpiAwareness(int PROCESS_DPI_AWARENESS);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			SetProcessDpiAwareness((int)DpiAwareness.PerMonitorAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
