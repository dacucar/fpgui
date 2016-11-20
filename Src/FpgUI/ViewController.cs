using System;

namespace FpgUI
{
	public class ViewController<T> where T : IView
	{
		private T view;
		private FpgUIContext context;

		public ViewController(T view, FpgUIContext context)
		{
			this.view = view;
			this.context = context;
		}

		public FpgUIContext Context => context;

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

