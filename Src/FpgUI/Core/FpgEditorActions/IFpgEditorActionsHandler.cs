using System;

namespace FpgUI.Core.FpgEditorActions
{
	public interface IFpgEditorActionsHandler
	{
		IFileActionsHandler FileActionsHandler { get; }

		IGraphicActionsHandler GraphicActionsHandler { get; }

		ISystemActionsHandler SystemActionsHandler { get; }

		IEditActionsHandler EditActionsHandler { get; }

		IPaletteActionsHandler PaletteActionsHandler { get; }
	}
}

