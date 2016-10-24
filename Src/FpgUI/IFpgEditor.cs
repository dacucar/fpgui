using System;
using FenixLib.Core;

namespace FpgUI
{
	public interface IFpgEditor
	{
		ISpriteAssortment Fpg { get; set; }
		object WindowBackend { get; }
		IFpgEditorActionsHandler ActionsHandler { get; }
		string FileName { get; set; }
		bool IsNewFile { get; }
	}
}

