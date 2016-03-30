using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	static class Program
	{
		private static MainForm mainForm;

		private static MainForm MainForm
		{
			get
			{
				if (mainForm == null)
				{
					mainForm = new MainForm();
				}

				return mainForm;
			}
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            if (!System.Diagnostics.Debugger.IsAttached)
			    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

			Application.Run(MainForm);
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			Exception ex = e.Exception;

			sb.Append("EXCEPTION: ");

            do
            {
                sb.AppendLine(ex.Message);
                if (ex.InnerException != null) ex = ex.InnerException;
            } while (ex.InnerException != null);
#if DEBUG
			sb.AppendLine(ex.StackTrace);
#endif

			MainForm.Log(sb.ToString());
		}
	}
}