using System;

namespace FpgUI.FpgEditor
{
	public interface IView
	{
		event EventHandler Shown;
		event EventHandler Closed;

		void ShowView(IView parent);

		void CloseView();
	}
}

