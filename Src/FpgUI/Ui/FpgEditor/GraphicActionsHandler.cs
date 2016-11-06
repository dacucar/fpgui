using System;
using FpgUI.Core.FpgEditor;
using FenixLib.Core;
using FenixLib.IO;
using Xwt;

namespace FpgUI
{
	public class GraphicActionsHandler : IGraphicActionsHandler
    {
		private static FileDialogFilter fpgFilesFilter = 
			new FileDialogFilter("Map Files (*.map)", "*.map");
		private static FileDialogFilter allFilesFilter =
			new FileDialogFilter("All Files (*.*)", "*.*");
		
        public GraphicActionsHandler()
        {
        }

		#region IGraphicActionsHandler implementation

		public void Rename(IFpgEditor editor)
		{
			throw new NotImplementedException();
		}

		public void Add(IFpgEditor editor)
		{
			throw new NotImplementedException();
		}

		public void Delete(IFpgEditor editor)
		{
			foreach (var id in editor.SelectedGraphicsIds)
			{
				editor.Fpg.Remove(id);
			}
			editor.NotifyFpgChange();
		}

		public void View(IFpgEditor editor)
		{
			throw new NotImplementedException();
		}

		public void ExtratToPng(IFpgEditor editor)
		{

		}

		public void ExtractToMap(IFpgEditor editor)
		{
			var w = (Window)editor.WindowBackend;
			var dialog = new SaveFileDialog();
			dialog.Filters.Add(fpgFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Title = "Save Map";

			foreach (var id in editor.SelectedGraphicsIds)
			{
				var s = editor.Fpg[id];
				if (!String.IsNullOrEmpty(s.Description))
				{
					dialog.InitialFileName = $"{s.Description}.map";
				}
				else
				{
					dialog.InitialFileName = $"{s.Id}.map";
				}
					
				if (dialog.Run(w))
				{
					try
					{
						NativeFile.SaveToMap(s,	dialog.FileName);
					}
					catch (Exception e)
					{
						MessageDialog.ShowError(w,
							$"Could not save {dialog.FileName}",
							e.ToString());					
					}
				}	
			}
		}

		#endregion
    }
}

