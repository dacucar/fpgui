using System;

namespace FpgUI.Core
{
	public interface IView
	{
		event EventHandler Shown;
		event EventHandler Closed;

		void ShowView(IView parent);

		void CloseView();
	}
}

