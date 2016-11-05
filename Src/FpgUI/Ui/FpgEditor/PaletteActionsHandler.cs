using System;
using FpgUI.Core.FpgEditor;
using Xwt;

namespace FpgUI
{
	public class PaletteActionsHandler : IPaletteActionsHandler
	{
		private static FileDialogFilter fpgFilesFilter = 
			new FileDialogFilter("Pal Files (*.pal)", "*.pal");
		private static FileDialogFilter allFilesFilter =
			new FileDialogFilter("All Files (*.*)", "*.*");

		public PaletteActionsHandler()
		{
			
		}

		#region IPaletteActionsHandler implementation

		public void ViewEdit(IFpgEditor editor)
		{
			throw new NotImplementedException();
		}

		public void ExportToPal(IFpgEditor editor)
		{
			var w = (Window)editor.WindowBackend;
			var dialog = new SaveFileDialog();
			dialog.Filters.Add(fpgFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Multiselect = false;
			dialog.Title = "Save Pal";
			dialog.InitialFileName = "Untitled.pal";

			if (dialog.Run(w))
			{
				try
				{
					FenixLib.IO.NativeFile.SaveToPal(editor.Fpg.Palette,
						dialog.FileName);
				}
				catch (Exception e)
				{
					MessageDialog.ShowError(w,
						$"Could not save {dialog.FileName}",
						e.ToString());					
				}
			}
		}

		#endregion
	}
}

