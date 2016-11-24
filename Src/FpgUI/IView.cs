using System;

namespace FpgUI
{
	public interface IView
	{
		/// <summary>
		/// Shall occur when the View is effectively closed.
		/// 
		/// <see cref="ViewController"/> observes this event
		/// to fire the ViewController.ViewClosed event.
		/// </summary>
		event EventHandler ViewClosed;

		/// <summary>
		/// Shall display the view.
		/// </summary>
		/// <param name="parent">Parent.</param>
		void ShowView(IView parent);

		/// <summary>
		/// Shall close the view.
		/// </summary>
		void CloseView();
	}
}

