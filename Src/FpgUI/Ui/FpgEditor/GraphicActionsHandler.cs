using System;
using FpgUI.Core.FpgEditor;
using FenixLib.Core;

namespace FpgUI
{
	public class GraphicActionsHandler : IGraphicActionsHandler
    {
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
			throw new NotImplementedException();
		}

		public void ExtractToMap(IFpgEditor editor)
		{
			throw new NotImplementedException();
		}

		#endregion
    }
}

