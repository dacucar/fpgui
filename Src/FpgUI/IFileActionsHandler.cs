using System;

namespace FpgUI
{
	public interface IFileActionsHandler
	{
		void New(IFpgEditor editor);
		void Open(IFpgEditor editor);
		void Save(IFpgEditor editor);
		void SaveAs(IFpgEditor editor);
		void Duplicate(IFpgEditor editor);
	}
}

