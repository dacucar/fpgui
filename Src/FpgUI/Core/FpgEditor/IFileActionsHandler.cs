using System;

namespace FpgUI.Core.FpgEditor
{
	public interface IFileActionsHandler
	{
		void New(IFpgEditorView editor);

		void Open(IFpgEditorView editor);

		void Save(IFpgEditorView editor);

		void SaveAs(IFpgEditorView editor);

		void Duplicate(IFpgEditorView editor);
	}
}

