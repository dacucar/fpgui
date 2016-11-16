using System;
using System.Collections.Generic;

namespace FpgUI.Core
{
	public class ApplicationContext
	{
		//private IViewFactory viewFactory;
		public ApplicationContext(IViewFactory factory)
		{
			ViewFactory = factory;
		}

		public ApplicationContext()
		{
			ViewFactory = new XwtViewFactory();
		}

		public void LoadConfiguration()
		{
		}

		public void SaveConfiguration()
		{
		}

		public IViewFactory ViewFactory { get; }
	}
}

