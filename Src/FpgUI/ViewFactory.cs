using System;
using FenixLib.Core;
using Xwt;
using FpgUI.Core.FpgEditorActions;
using FpgUI.Core;
using FpgUI.Ui;

/*

namespace FpgUI.Ui
{
	public class WindowsFactory : IWindowsFactory
	{
		public WindowsFactory()
		{
		}

		#region IWindowsFactory implementation

		public IFpgEditor CreateFpgEditorWindow(ApplicationContext context, 
		                                        ISpriteAssortment fpg = null)
		{
			var w = new FpgEditorWindow(context);
			w.Show();
			return w;
		}

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

		#endregion
	}
}

*/