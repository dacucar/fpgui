using System;
using System.Collections.Generic;

namespace FpgUI
{
	public class FpgUIContext
	{
		public FpgUIContext(IViewFactory factory)
		{
			ViewFactory = factory;
		}

		public FpgUIContext()
		{
			ViewFactory = new ViewFactory();
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

