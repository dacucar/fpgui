using System;
using Xwt;
using FpgUI.Core.FpgEditor;
using FenixLib.Core;
using FenixLib.IO;
/*
namespace FpgUI.Ui
{
	
	class FileActionsHandler : IFileActionsHandler
	{
		private static FileDialogFilter fpgFilesFilter = 
			new FileDialogFilter("Fpg Files (*.fpg)", "*.fpg");
		private static FileDialogFilter allFilesFilter =
			new FileDialogFilter("All Files (*.*)", "*.*");

		void IFileActionsHandler.New()
		{
			//editor.Context.CreateNewFpgDialog();
		}

		void IFileActionsHandler.Open()
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

		void IFileActionsHandler.Save(IFpgEditorView editor)
		{
			if (editor.IsNewFile)
			{
				((IFileActionsHandler)this).SaveAs(editor);
			}
			else
			{
				try
				{
					editor.Fpg.SaveToFpg(editor.FileName);
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

		void IFileActionsHandler.SaveAs(IFpgEditorView editor)
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
					editor.Fpg.SaveToFpg(dialog.FileName);
				}
				catch (Exception e)
				{
					MessageDialog.ShowError(w,
						$"Could not save {dialog.FileName}",
						e.ToString());					
				}
			}
		}

		void IFileActionsHandler.Duplicate(IFpgEditorView editor)
		{

		}
	}

}

*/