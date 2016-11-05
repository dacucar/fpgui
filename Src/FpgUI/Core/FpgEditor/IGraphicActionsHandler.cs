using System;

namespace FpgUI.Core.FpgEditor
{
	public interface IGraphicActionsHandler
	{
		void Rename(IFpgEditor editor);
		void Add(IFpgEditor editor);
		void Delete(IFpgEditor editor);
		void View(IFpgEditor editor);
		void ExtratToPng(IFpgEditor editor);
		void ExtractToMap(IFpgEditor editor);
	}
}

