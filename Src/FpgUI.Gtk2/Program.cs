using System;
using Xwt;

namespace FpgUI.Gtk2
{
    public class Program
    {
        [STAThread]
        public static void Main ( string [] args )
        {
            Application.Initialize ( ToolkitType.Gtk );

            FpgEditorWindow w = new FpgEditorWindow ();
            w.Show ();

            Application.Run ();

            w.Dispose ();
            Application.Dispose ();
        }
    }
}

