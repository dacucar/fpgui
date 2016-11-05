using Xwt;
using FenixLib.Core;
using System;
using FpgUI.Core.FpgEditor;

namespace FpgUI.Xwt.FpgEditor
{		
	public class FpgEditorWindow : Window, IFpgEditor
	{
		object IFpgEditor.WindowBackend => this;

		private ISpriteAssortment fpg;
		ISpriteAssortment IFpgEditor.Fpg
		{ 
			get
			{
				return fpg;
			}
			set
			{
				fpg = value;

			}
		}

		IFpgEditorActionsHandler IFpgEditor.ActionsHandler { get; }
			= new ActionsHandler ();

		string IFpgEditor.FileName { get; set; }

		bool IFpgEditor.IsNewFile => ((IFpgEditor)this).FileName == null;

		public FpgEditorWindow ()
		{
			BuildUI ();
		}

		protected override bool OnCloseRequested ()
		{
			var allow_close = MessageDialog.Confirm ( 
				"FpgUI will be closed", Command.Ok );
			if ( allow_close )
				Application.Exit ();
			return allow_close;
		}

		protected virtual void BuildUI()
		{
			Title = "FpgUI";
			Width = 400;
			Height = 400;

			Menu mainMenu = new Menu ();

			var fileMenu = new MenuItem ( "_File" );
			fileMenu.SubMenu = new Menu ();

			var newFile = new MenuItem ( "_New" );
			newFile.Clicked += (sender, e) => 
				((IFpgEditor)this).ActionsHandler.FileActionsHandler.New(this);
			var openFile = new MenuItem ( "_Open" );
			openFile.Clicked += (sender, e) =>  
				((IFpgEditor)this).ActionsHandler.FileActionsHandler.Open(this);
			fileMenu.SubMenu.Items.Add ( openFile );
			var saveFile = new MenuItem("_Save...");
			saveFile.Clicked += (sender, e) => 
				((IFpgEditor)this).ActionsHandler.FileActionsHandler.Save(this);
			var saveFileAs = new MenuItem("Save As...");
			saveFileAs.Clicked += (sender, e) => 
				((IFpgEditor)this).ActionsHandler.FileActionsHandler.SaveAs(this);
			var closeFile = new MenuItem ( "_Close" );
			closeFile.Clicked += (sender, e ) => Close ();

			fileMenu.SubMenu.Items.Add ( newFile );
			fileMenu.SubMenu.Items.Add ( saveFile );
			fileMenu.SubMenu.Items.Add ( saveFileAs );
			fileMenu.SubMenu.Items.Add ( closeFile );

			var editMenu = new MenuItem ( "_Edit" );
			var cutEdit = new MenuItem ( "_Cut" );
			var copyEdit = new MenuItem ( "_Copy" );
			var pasteEdit = new MenuItem ( "_Paste" );

			editMenu.SubMenu = new Menu ();
			editMenu.SubMenu.Items.Add ( cutEdit );
			editMenu.SubMenu.Items.Add ( copyEdit );
			editMenu.SubMenu.Items.Add ( pasteEdit );

			var paletteMenu = new MenuItem ( "_Palette" );
			var viewEditPalette = new MenuItem ( "_View/Edit..." );
			var exportPalette = new MenuItem ( "_Export to PAL..." );

			paletteMenu.SubMenu = new Menu ();
			paletteMenu.SubMenu.Items.Add ( viewEditPalette );
			paletteMenu.SubMenu.Items.Add ( exportPalette );

			var graphicMenu = new MenuItem ( "_Graphic" );
			var addGraphic = new MenuItem ( "_Add" );
			var editGraphic = new MenuItem ( "_View/Edit" );
			var extractGraphic = new MenuItem ( "_Extract" );
			var extractToMap = new MenuItem ( "To _MAP file..." );
			var extractToPng = new MenuItem ( "To _PNG file..." );
			var deleteGraphic = new MenuItem ( "_Delete" );

			extractGraphic.SubMenu = new Menu ();
			extractGraphic.SubMenu.Items.Add ( extractToMap );
			extractGraphic.SubMenu.Items.Add ( extractToPng );

			graphicMenu.SubMenu = new Menu ();
			graphicMenu.SubMenu.Items.Add ( addGraphic );
			graphicMenu.SubMenu.Items.Add ( editGraphic );
			graphicMenu.SubMenu.Items.Add ( extractGraphic );
			graphicMenu.SubMenu.Items.Add ( deleteGraphic );

			var systemMenu = new MenuItem ( "_System" );
			var newWindowSystem = new MenuItem ( "New _window" );
			systemMenu.SubMenu = new Menu ();

			systemMenu.SubMenu.Items.Add ( newWindowSystem );

			mainMenu.Items.Add ( fileMenu );
			mainMenu.Items.Add ( editMenu );
			mainMenu.Items.Add ( paletteMenu );
			mainMenu.Items.Add ( graphicMenu );
			mainMenu.Items.Add ( systemMenu );

			MainMenu = mainMenu;

			var sampleLabel = new Label ( "Lalala" );
			Content = sampleLabel;			
		}
	}



}


