using System;
using Xwt;
using FpgUI.Core.FpgEditor;

namespace FpgUI.Ui
{
	sealed class ActionsHandler : IFpgEditorActionsHandler
	{
		public IFileActionsHandler FileActionsHandler { get; }
			= new FileActionsHandler();
		public IGraphicActionsHandler GraphicActionsHandler { get; }
			= null;
		public IPaletteActionsHandler PaletteActionsHandler { get; }
			= null;
		public IEditActionsHandler EditActionsHandler { get; }
			= null;
		public ISystemActionsHandler SystemActionsHandler { get; }
			= null;
	}
}

