using System;

namespace FpgUI.Core.FpgEditor
{
	public interface IPaletteActionsHandler
	{
		void ViewEdit(IFpgEditorView editor);
		void ExportToPal(IFpgEditorView editor);
	}
}
