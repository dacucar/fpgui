using System;
using FenixLib.Core;
using FpgUI.Core.FpgEditor;

namespace FpgUI.Core
{
	public interface IWindowsFactory
	{
		IFpgEditor CreateFpgEditorWindow(ApplicationContext context, ISpriteAssortment fpg = null);

		void CreatePaletteEditorWindow(ApplicationContext context, Palette pal = null);

		void CreateSpriteEditorWindow(ApplicationContext context, ISprite map = null );

		void CreateNewFpgDialog(ApplicationContext context);
	}
}

