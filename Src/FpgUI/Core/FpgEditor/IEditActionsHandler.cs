using System;

namespace FpgUI.Core.FpgEditor
{
	public interface IEditActionsHandler
	{
		void Copy(IFpgEditor editor);

		void Paste(IFpgEditor editor);

		void Cut(IFpgEditor editor);
	}
}

