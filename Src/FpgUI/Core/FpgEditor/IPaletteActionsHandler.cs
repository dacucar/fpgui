using System;

namespace FpgUI.Core.FpgEditor
{
	public interface IPaletteActionsHandler
	{
		void ViewEdit(IFpgEditor editor);
		void ExportToPal(IFpgEditor editor);
	}
}
