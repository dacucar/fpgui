using System;

namespace FpgUI
{
	public interface IView
	{
		event EventHandler Shown;
		event EventHandler Closed;

		void ShowView(IView parent);

		void CloseView();
	}
}

