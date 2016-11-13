using System;

namespace FpgUI.Core.FpgEditorActions
{
	public interface IGraphicActionsHandler
	{
		void Rename(IFpgEditorView editor);

		void Add(IFpgEditorView editor);

		void Delete(IFpgEditorView editor);

		void View(IFpgEditorView editor);

		void ExtratToPng(IFpgEditorView editor);

		void ExtractToMap(IFpgEditorView editor);
	}
}

