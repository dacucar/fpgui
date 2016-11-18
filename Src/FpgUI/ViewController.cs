using System;

namespace FpgUI.FpgEditor
{
	public class ViewController<T> where T : IView
	{
		private T view;
		private ApplicationContext context;

		public ViewController(T view, ApplicationContext context)
		{
			this.view = view;
			this.context = context;
		}

		public ApplicationContext Context => context;

		public T View
		{
			get
			{
				return view;
			}
		}

		public virtual void ShowView(IView owner)
		{
			view.ShowView(owner);
		}

		public virtual void ShowView()
		{
			view.ShowView(null);
		}

		public virtual void CloseView()
		{
			view.CloseView();
		}
	}
}

