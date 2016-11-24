using System;
using System.Collections.Generic;

namespace FpgUI
{
	public class FpgUIContext
	{
		public delegate void LastViewClosedHandler();

		private readonly LastViewClosedHandler lastViewClosed;
		private readonly ICollection<IView> views = new List<IView>();

		public FpgUIContext(IViewFactory factory, 
			LastViewClosedHandler handler)
		{
			ViewFactory = factory;
			lastViewClosed = handler;
		}

		public FpgUIContext()
		{
			ViewFactory = new ViewFactory();
			lastViewClosed = XwtDefaults.LastViewClosedHandler;
		}

		public IViewFactory ViewFactory { get; }

		public void LoadConfiguration()
		{
		}

		public void SaveConfiguration()
		{
		}

		internal virtual void OnViewClosed(object sender, IView view)
		{
			views.Remove(view);

			if (views.Count == 0)
			{
				lastViewClosed();
			}			
		}

		internal virtual void OnViewShown(object sender, IView view)
		{
			views.Add(view);
		}
	}
}

