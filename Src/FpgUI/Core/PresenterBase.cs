using System;

namespace FpgUI.Core
{
	public class PresenterBase<T> where T : IView
	{
		private T view;
		private ApplicationContext context;

		public PresenterBase(T view, ApplicationContext context)
		{
			this.view = view;
			this.context = context;
		}

		public ApplicationContext Context => context;

		public T View => view;

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

