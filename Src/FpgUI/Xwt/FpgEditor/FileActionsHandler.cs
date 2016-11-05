using System;
using Xwt;
using FpgUI.Core.FpgEditor;
using FenixLib.Core;

namespace FpgUI.Xwt.FpgEditor
{
	class FileActionsHandler : IFileActionsHandler
	{
		private static FileDialogFilter fpgFilesFilter = 
			new FileDialogFilter("Fpg Files (*.fpg)", "*.fpg");
		private static FileDialogFilter allFilesFilter =
			new FileDialogFilter("All Files (*.*)", "*.*");

		void IFileActionsHandler.New(IFpgEditor editor)
		{

		}

		void IFileActionsHandler.Open(IFpgEditor editor)
		{
			var w = (Window)editor.WindowBackend;
			var dialog = new OpenFileDialog();
			dialog.Filters.Add(fpgFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Multiselect = false;
			dialog.InitialFileName = "test";
			if (dialog.Run(w))
			{
				ISpriteAssortment fpg;
				try
				{
					fpg = FenixLib.IO.NativeFile.LoadFpg(
						dialog.FileName);
				}
				catch (Exception e)
				{
					MessageDialog.ShowError(w, 
						$"Could not open {dialog.FileName}", e.ToString()); 

					return;

				}

				editor.Fpg = fpg;
				editor.FileName = dialog.FileName;
			}
		}

		void IFileActionsHandler.Save(IFpgEditor editor)
		{
			if (editor.IsNewFile)
			{
				((IFileActionsHandler)this).SaveAs(editor);
			}
			else
			{
				try
				{
					FenixLib.IO.NativeFile.SaveToFpg(editor.Fpg,
						editor.FileName);
				}
				catch (Exception e)
				{
					var w = (Window)editor.WindowBackend;
					MessageDialog.ShowError(w,
						$"Could not save {editor.FileName}",
						e.ToString());
				}
			}
		}

		void IFileActionsHandler.SaveAs(IFpgEditor editor)
		{
			var w = (Window)editor.WindowBackend;
			var dialog = new SaveFileDialog();
			dialog.Filters.Add(fpgFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Multiselect = false;
			dialog.Title = "Save Fpg";
			dialog.InitialFileName = "Untitled.fpg";

			if (dialog.Run(w))
			{
				try
				{
					FenixLib.IO.NativeFile.SaveToFpg(editor.Fpg,
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

		void IFileActionsHandler.Duplicate(IFpgEditor editor)
		{

		}
	}

}

