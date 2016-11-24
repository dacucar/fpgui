using System;
using FenixLib.Core;
using Xwt;

namespace FpgUI
{
	public class ViewFactory : IViewFactory
	{
		public ViewFactory()
		{
		}

		#region IWindowsFactory implementation

		public IFpgEditorView CreateFpgEditorView()
		{
			var v = new FpgEditorView();
			return v;
		}

		public IAddGraphicDialog CreateAddGraphicDialog()
		{
			var v = new AddGraphicDialog();
			return v;
		}
		/*
		public void CreateNewFpgDialog(ApplicationContext context)
		{
			var w = new NewFpgDialog();

			w.CommandActivated += (sender, e) =>
			{
				if (e.Command == Command.Ok)
				{
					var editor = CreateFpgEditorWindow(context);
					editor.Fpg = new SpriteAssortment(w.GraphicFormat, 
						w.Palette);
				}
				w.Close();
			};
				
			w.Show();
		}

		public void CreateAddGraphicDialog(ApplicationContext context)
		{
			var w = new AddGraphicDialog();

			w.CommandActivated += (sender, e) =>
			{
				if (e.Command == Command.Ok)
				{
				}
				w.Close();
			};

			w.Show();
		}

		public void CreatePaletteEditorWindow(ApplicationContext context, Palette pal = null)
		{
			throw new NotImplementedException();
		}

		public void CreateSpriteEditorWindow(ApplicationContext context, ISprite map = null)
		{
			throw new NotImplementedException();
		}
*/
		#endregion
	}
}
	