using System;

namespace FpgUI.Core
{
	class PresenterBase<T> where T : IView
	{
		private T view;
		public PresenterBase(T view)
		{
			this.view = view;
		}

		public T View { get { return view; } }

		public void ShowView(IView owner)
		{
			view.ShowView(owner);
		}

		public void ShowView()
		{
			view.ShowView(null);
		}

		public void CloseView()
		{
			view.CloseView();
		}
	}
}

