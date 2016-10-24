using System;
using Xwt;
using FenixLib.Core;

namespace FpgUI
{
	class XwtFileActionsHandler : IFileActionsHandler
	{
		private static FileDialogFilter openFpgDialogFilter = 
			new FileDialogFilter("test", "*.fpg");

		void IFileActionsHandler.New(IFpgEditor editor)
		{

		}

		void IFileActionsHandler.Open(IFpgEditor editor)
		{
			var window = ( Window ) editor.WindowBackend;
			var dialog = new OpenFileDialog ();
			dialog.Filters.Add (new FileDialogFilter ("All files", "*.*"));
			dialog.Multiselect = false;
			dialog.InitialFileName = "test";
			if ( dialog.Run ( window ) )
			{
				ISpriteAssortment fpg;
				try
				{
					fpg = FenixLib.IO.NativeFile.LoadFpg ( 
						dialog.FileName );
				}
				catch (Exception e)
				{
					MessageDialog.ShowError ( window, 
						$"Could not open {dialog.FileName}", e.ToString() );

					return;

				}

				editor.Fpg = fpg;
				editor.FileName = dialog.FileName;
			}
		}

		void IFileActionsHandler.Save(IFpgEditor editor)
		{

		}

		void IFileActionsHandler.SaveAs(IFpgEditor editor)
		{

		}

		void IFileActionsHandler.Duplicate(IFpgEditor editor)
		{

		}
	}

}

