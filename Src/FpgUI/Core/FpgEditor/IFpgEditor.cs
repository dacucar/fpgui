using System;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI.Core.FpgEditor
{
	public interface IFpgEditor
	{
		ISpriteAssortment Fpg { get; set; }

		object WindowBackend { get; }

		IFpgEditorActionsHandler ActionsHandler { get; }

		string FileName { get; set; }

		bool IsNewFile { get; }

		event EventHandler FpgChanged;

		IEnumerable<int> SelectedGraphicsIds { get; }

		void NotifyFpgChange();

		ApplicationContext Context { get; }
	}
}

