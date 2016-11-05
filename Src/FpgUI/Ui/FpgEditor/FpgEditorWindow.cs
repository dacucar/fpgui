using Xwt;
using FenixLib.Core;
using System;
using FpgUI.Core.FpgEditor;

namespace FpgUI.Ui
{		
	public class FpgEditorWindow : Window, IFpgEditor
	{
		public event EventHandler FpgChanged;

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
				FpgChanged(this, EventArgs.Empty);
			}
		}
			
		IFpgEditorActionsHandler IFpgEditor.ActionsHandler { get; }
			= new ActionsHandler ();

		private string filename;
		string IFpgEditor.FileName
		{ 
			get
			{
				return filename;
			}
			set
			{
				filename = value;
				statusLabel.Text = filename;
				depthLabel.Text = $"{fpg.GraphicFormat.BitsPerPixel}bpp";
			}
		}

		bool IFpgEditor.IsNewFile => ((IFpgEditor)this).FileName == null;

		protected virtual void OnFpgChanged(object sender, EventArgs e)
		{
			fpgWidget.Fpg = fpg;
		}

		protected override bool OnCloseRequested ()
		{
			var allow_close = MessageDialog.Confirm ( 
				"FpgUI will be closed", Command.Ok );
			if ( allow_close )
				Application.Exit ();
			return allow_close;
		}

		public FpgEditorWindow ()
		{
			buildUI ();
			fpgEditor.FpgChanged += OnFpgChanged;
		}

		private IFpgEditor fpgEditor
		{
			get
			{
				return this;
			}
		}

		private FpgWidget fpgWidget;
		private Label statusLabel;
		private Label depthLabel;

		private IFpgEditorActionsHandler actions => fpgEditor.ActionsHandler;

		private IEditActionsHandler editActions => actions.EditActionsHandler;

		private IFileActionsHandler fileActions => actions.FileActionsHandler;

		private IPaletteActionsHandler paletteActions => actions.PaletteActionsHandler;

		private void buildUI()
		{
			Title = "FpgUI";
			Width = 400;
			Height = 400;

			Menu mainMenu = new Menu ();

			var fileMenu = new MenuItem ( "_File" );
			fileMenu.SubMenu = new Menu ();

			var newFile = new MenuItem ( "_New" );
			newFile.Clicked += (sender, e) => 
				fileActions.New(this);
			var openFile = new MenuItem ( "_Open" );
			openFile.Clicked += (sender, e) =>  
				fileActions.Open(this);
			fileMenu.SubMenu.Items.Add ( openFile );
			var saveFile = new MenuItem("_Save...");
			saveFile.Clicked += (sender, e) => 
				fileActions.Save(this);
			var saveFileAs = new MenuItem("Save As...");
			saveFileAs.Clicked += (sender, e) => 
				fileActions.SaveAs(this);
			var closeFile = new MenuItem ( "_Close" );
			closeFile.Clicked += (sender, e ) => Close ();

			fileMenu.SubMenu.Items.Add ( newFile );
			fileMenu.SubMenu.Items.Add ( saveFile );
			fileMenu.SubMenu.Items.Add ( saveFileAs );
			fileMenu.SubMenu.Items.Add ( closeFile );

			var editMenu = new MenuItem ( "_Edit" );
			var cutEdit = new MenuItem ( "_Cut" );
			cutEdit.Clicked += (sender, e) => 
				actions.EditActionsHandler.Copy(this);
			var copyEdit = new MenuItem ( "_Copy" );
			copyEdit.Clicked+= (sender, e) => 
				actions.EditActionsHandler.Copy(this);
			var pasteEdit = new MenuItem ( "_Paste" );
			pasteEdit.Clicked += (sender, e) => 
				actions.EditActionsHandler.Paste ( this );

			editMenu.SubMenu = new Menu ();
			editMenu.SubMenu.Items.Add ( cutEdit );
			editMenu.SubMenu.Items.Add ( copyEdit );
			editMenu.SubMenu.Items.Add ( pasteEdit );

			var paletteMenu = new MenuItem ( "_Palette" );
			var viewEditPalette = new MenuItem ( "_View/Edit..." );
			var exportPalette = new MenuItem ( "_Export to PAL..." );
			exportPalette.Clicked += (sender, e) => 
				paletteActions.ExportToPal(this);

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

			//var sampleLabel = new Label ( "Lalala" );
			fpgWidget = new FpgWidget();

			statusLabel = new Label("No Label");
			depthLabel = new Label("8bpp");
			var statusFrame = new Frame (statusLabel);
			var depthFrame = new Frame(depthLabel);

			var statusContainer = new HBox();
			statusContainer.PackStart(statusFrame, true);
			statusContainer.PackStart(depthFrame);

			var vbox = new VBox();
			vbox.PackStart(fpgWidget, true);
			vbox.PackStart(statusContainer);

			Content = vbox;
		}
	}
}


