using System;

namespace FpgUI
{
	public class ViewController<T> where T : IView
	{
		/// <summary>
		/// Occurs when the controlled view is closed.
		/// 
		/// The controller will auto-register the 
		/// <see cref="FpgUIContext"/> as a listener to this event.
		/// See <see cref="ViewController(T, FpgUIContext)"/> .
		/// </summary>
		public event EventHandler<IView> ViewClosed;
		/// <summary>
		/// Occurs when the controlled view is displayed.
		/// </summary>
		public event EventHandler<IView> ViewShown;

		private T view;
		private FpgUIContext context;

		/// <summary>
		/// Initializes a new instance of the <see cref="FpgUI.ViewController`1"/> class.
		/// 
		/// The <see cref="FpgUIContext"/> is registered as an observer of the
		/// <see cref="ViewClosed"/> event.
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="context">Context.</param>
		public ViewController(T view, FpgUIContext context)
		{
			this.view = view;
			this.context = context;

			this.view.ViewClosed += View_ViewClosed;

			// Auto-Register the context to listen to ViewClose & ViewShown
			// of the controller
			ViewClosed += context.OnViewClosed;
			ViewShown += context.OnViewShown;
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
			ViewShown?.Invoke(this, view);
			view.ShowView(null);
		}

		public virtual void CloseView()
		{
			view.CloseView();
		}

		private void View_ViewClosed(object sender, EventArgs e)
		{
			ViewClosed?.Invoke(this, view);
		}
	}
}

