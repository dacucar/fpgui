using System;
using Xwt;

namespace FpgUI.Xwt
{
	public partial class FpgEditorView
	{
		protected FpgWidget fpgWidget;
		protected Label statusLabel;
		protected Label depthLabel;

		private void buildUI()
		{
			Title = "FpgUI";
			Width = 400;
			Height = 400;

			Menu mainMenu = new Menu();

			var fileMenu = new MenuItem("_File");
			fileMenu.SubMenu = new Menu();

			var newFile = new MenuItem("_New");
			newFile.Clicked += (sender, e) => 
				NewFpgClicked?.Invoke(this, EventArgs.Empty);

			var openFile = new MenuItem("_Open");
			openFile.Clicked += (sender, e) => 
				OpenClicked?.Invoke(this, EventArgs.Empty);
			fileMenu.SubMenu.Items.Add(openFile);
			var saveFile = new MenuItem("_Save...");
			saveFile.Clicked += (sender, e) => 
				SaveClicked?.Invoke(this, EventArgs.Empty);
			var saveFileAs = new MenuItem("Save As...");
			saveFileAs.Clicked += (sender, e) => 
				SaveAsClicked?.Invoke(this, EventArgs.Empty);
			var duplicateFpg = new MenuItem("Duplicate Fpg...");
			duplicateFpg.Clicked += (sender, e) => 
				DuplicateFpgClicked?.Invoke(this, EventArgs.Empty);
			var closeFile = new MenuItem("_Close Fpg");
			closeFile.Clicked += (sender, e) =>
				CloseClicked?.Invoke(this, EventArgs.Empty);

			fileMenu.SubMenu.Items.Add(newFile);
			fileMenu.SubMenu.Items.Add(saveFile);
			fileMenu.SubMenu.Items.Add(saveFileAs);
			fileMenu.SubMenu.Items.Add(duplicateFpg);
			fileMenu.SubMenu.Items.Add(closeFile);

			var editMenu = new MenuItem("_Edit");
			var cutEdit = new MenuItem("_Cut");
			cutEdit.Clicked += (sender, e) => 
				CutClicked?.Invoke(this, EventArgs.Empty);
			var copyEdit = new MenuItem("_Copy");
			copyEdit.Clicked += (sender, e) => 
				CopyClicked?.Invoke(this, EventArgs.Empty);
			var pasteEdit = new MenuItem("_Paste");
			pasteEdit.Clicked += (sender, e) => 
				PasteClicked?.Invoke(this, EventArgs.Empty);

			editMenu.SubMenu = new Menu();
			editMenu.SubMenu.Items.Add(cutEdit);
			editMenu.SubMenu.Items.Add(copyEdit);
			editMenu.SubMenu.Items.Add(pasteEdit);

			var paletteMenu = new MenuItem("_Palette");
			var viewEditPalette = new MenuItem("_View/Edit...");
			viewEditPalette.Clicked += (sender, e) => 
				ViewEditPaletteClicked?.Invoke(this, EventArgs.Empty);
			var exportPalette = new MenuItem("_Export to PAL...");
			exportPalette.Clicked += (sender, e) => 
				ExtractToPalClicked?.Invoke(this, EventArgs.Empty);

			paletteMenu.SubMenu = new Menu();
			paletteMenu.SubMenu.Items.Add(viewEditPalette);
			paletteMenu.SubMenu.Items.Add(exportPalette);

			var graphicMenu = new MenuItem("_Graphic");
			var addGraphic = new MenuItem("_Add");
			addGraphic.Clicked += (sender, e) => 
				AddGraphicClicked?.Invoke(this, e);
			var editGraphic = new MenuItem("_View/Edit");
			editGraphic.Clicked += (sender, e) => 
				ViewEditGraphicClicked?.Invoke(this, EventArgs.Empty);
			var extractGraphic = new MenuItem("_Extract");
			var extractToMap = new MenuItem("To _MAP file...");
			extractToMap.Clicked += (sender, e) => 
				ExtractToMapClicked?.Invoke(this, EventArgs.Empty);
			var extractToPng = new MenuItem("To _PNG file...");
			extractToPng.Clicked += (sender, e) => 
				ExtractToPngClicked?.Invoke(this, EventArgs.Empty);
			var deleteGraphic = new MenuItem("_Delete");
			deleteGraphic.Clicked += (sender, e) => 
				RemoveGraphicClicked?.Invoke(this, EventArgs.Empty);

			extractGraphic.SubMenu = new Menu();
			extractGraphic.SubMenu.Items.Add(extractToMap);
			extractGraphic.SubMenu.Items.Add(extractToPng);

			graphicMenu.SubMenu = new Menu();
			graphicMenu.SubMenu.Items.Add(addGraphic);
			graphicMenu.SubMenu.Items.Add(editGraphic);
			graphicMenu.SubMenu.Items.Add(extractGraphic);
			graphicMenu.SubMenu.Items.Add(deleteGraphic);

			var systemMenu = new MenuItem("_System");
			var newWindowSystem = new MenuItem("New _window");
			newWindowSystem.Clicked += (sender, e) => 
				NewWindowClicked?.Invoke(this, EventArgs.Empty);

			systemMenu.SubMenu = new Menu();
			systemMenu.SubMenu.Items.Add(newWindowSystem);

			mainMenu.Items.Add(fileMenu);
			mainMenu.Items.Add(editMenu);
			mainMenu.Items.Add(paletteMenu);
			mainMenu.Items.Add(graphicMenu);
			mainMenu.Items.Add(systemMenu);

			MainMenu = mainMenu;

			//var sampleLabel = new Label ( "Lalala" );
			fpgWidget = new FpgWidget();

			statusLabel = new Label("Status Label");
			depthLabel = new Label("Depth Label");
			var statusFrame = new Frame(statusLabel);
			var depthFrame = new Frame(depthLabel);

			var statusContainer = new HBox();
			statusContainer.PackStart(statusFrame, true);
			statusContainer.PackStart(depthFrame);

			var vbox = new VBox();
			vbox.PackStart(fpgWidget, true);
			vbox.PackStart(statusContainer);

			mapCommand(UiControl.NewFpg, newFile);
			mapCommand(UiControl.OpenFpg, openFile);
			mapCommand(UiControl.SaveFpg, saveFile);
			mapCommand(UiControl.SaveAsFpg, saveFileAs);
			mapCommand(UiControl.Close, closeFile);
			mapCommand(UiControl.Cut, cutEdit);
			mapCommand(UiControl.Copy, copyEdit);
			mapCommand(UiControl.Paste, pasteEdit);
			mapCommand(UiControl.DuplicateFpg, duplicateFpg);
			mapCommand(UiControl.PaletteControls, paletteMenu);
			mapCommand(UiControl.ViewEditPalette, viewEditPalette);
			mapCommand(UiControl.ExportToPal, exportPalette);
			mapCommand(UiControl.GraphicControls, graphicMenu);
			mapCommand(UiControl.AddGraphic, addGraphic);
			mapCommand(UiControl.ExportGraphic, extractGraphic);
			mapCommand(UiControl.ViewEditGraphic, editGraphic);
			mapCommand(UiControl.Delete, deleteGraphic);
			mapCommand(UiControl.NewWindow, newWindowSystem);

			Content = vbox;
		}
	}
}

