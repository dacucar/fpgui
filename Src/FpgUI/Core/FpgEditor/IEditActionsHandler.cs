using System;

namespace FpgUI.Core.FpgEditor
{
	public interface IEditActionsHandler
	{
		void Copy(IFpgEditorView editor);

		void Paste(IFpgEditorView editor);

		void Cut(IFpgEditorView editor);
	}
}

