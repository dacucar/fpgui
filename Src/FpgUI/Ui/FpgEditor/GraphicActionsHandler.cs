using System;
using FenixLib.Core;
using FenixLib.IO;
using Xwt;

/*
namespace FpgUI
{
	
	public class GraphicActionsHandler : IGraphicActionsHandler
    {

		public void Delete(IFpgEditorView editor)
		{
			foreach (var id in editor.SelectedGraphicsIds)
			{
				editor.Fpg.Remove(id);
			}
			editor.NotifyFpgChange();
		}

		public void ExtractToMap(IFpgEditorView editor)
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
						s.SaveToMap(dialog.FileName);
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
*/
