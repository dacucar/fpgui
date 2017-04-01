using System;
using System.Collections.Generic;
using System.Linq;
using Xwt;
using FenixLib.Core;

namespace FpgUI.Xwt
{
	public partial class FpgEditorView : Window, IFpgEditorView
	{
		private static readonly FileDialogFilter fpgFilesFilter =
			new FileDialogFilter("Fpg Files (*.fpg)", "*.fpg");
		private static readonly FileDialogFilter allFilesFilter =
			new FileDialogFilter("All Files (*.*)", "*.*");
		private static readonly FileDialogFilter palFilesFilter =
			new FileDialogFilter("Pal Files (*.pal)", "*.pal");	
		private static readonly FileDialogFilter mapFilesFilter =
			new FileDialogFilter("Map Files (*.map)", "*.map");			

		private readonly IDictionary<UiControl, ISensitive> commands =
			new Dictionary<UiControl, ISensitive>();

		public FpgEditorView()
		{
			// IView events

			buildUI();
		}

		public IFpgWidget FpgWidget
		{
			get
			{
				return fpgWidget;
			}
		}

		public ISpriteAssortment Fpg
		{
			set
			{
				fpgWidget.Fpg = value;
			}
		}

		public void ShowView(IView parent)
		{
			Show();
		}

		public void CloseView()
		{
			Close();
		}

		public void SetControlEnabled(UiControl control, bool value)
		{
			commands[control].Sensitive = value;
		}

		public string LetUserSelectFileToOpen()
		{
			var dialog = new OpenFileDialog();
			dialog.Filters.Add(fpgFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Multiselect = false;
			if (dialog.Run(this))
			{
				return dialog.FileName;
			}

			return null;
		}

		public string LetUserSelectFileToSave(string initialFileName)
		{
			var dialog = new SaveFileDialog();
			dialog.Filters.Add(fpgFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Multiselect = false;
			dialog.InitialFileName = initialFileName;
			if (dialog.Run(this))
			{
				return dialog.FileName;
			}

			return null;
		}

		public string LetUserSelectPaletteToExtract(string initialFilename)
		{
			var dialog = new OpenFileDialog();
			dialog.Filters.Add(palFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Multiselect = false;
			if (dialog.Run(this))
			{
				return dialog.FileName;
			}

			return null;
		}

		public YesNoCancel AskUserIfChangesShouldBeSaved(string message)
		{
			var result = MessageDialog.AskQuestion(
				message, 
				new Command[] { Command.Save, Command.No, Command.Cancel });

			if (result == Command.Save)
				return YesNoCancel.Yes;
			else if (result == Command.No)
				return YesNoCancel.No;
			else
				return YesNoCancel.Cancel;
		}

		public string LetUserSelectWhereToExtractGraphic(string initialFileName)
		{
			var dialog = new SaveFileDialog();
			dialog.Filters.Add(mapFilesFilter);
			dialog.Filters.Add(allFilesFilter);
			dialog.Multiselect = false;
			dialog.InitialFileName = initialFileName;
			if (dialog.Run(this))
			{
				return dialog.FileName;
			}

			return null;
		}

		protected override bool OnCloseRequested()
		{
			var args = new ClosingEventArgs();
			Closing?.Invoke(this, args);
			return !args.Cancel;
		}

		protected override void OnClosed()
		{
			viewClosed?.Invoke(this, EventArgs.Empty);
		}

		private void mapCommand(UiControl command, Widget widget)
		{
			this.commands.Add(command, new SensitiveWidgetAdapter(widget));
		}

		private void mapCommand(UiControl command, MenuItem menuItem)
		{
			this.commands.Add(command, new SensitiveMenuItemAdapter(menuItem));
		}

		private interface ISensitive
		{
			bool Sensitive { get; set; }
		}
			
		private sealed class SensitiveMenuItemAdapter : ISensitive
		{
			private readonly MenuItem menuItem;

			public SensitiveMenuItemAdapter(MenuItem menuItem)
			{
				this.menuItem = menuItem;
			}
				
			#region ISensitive implementation

			public bool Sensitive
			{
				get
				{
					return menuItem.Sensitive;
				}
				set
				{
					menuItem.Sensitive = value;
				}
			}
			#endregion
		}

		private sealed class SensitiveWidgetAdapter : ISensitive
		{
			private readonly Widget widget;

			public SensitiveWidgetAdapter(Widget widget)
			{
				this.widget = widget;
			}

			#region ISensitive implementation
			public bool Sensitive
			{
				get
				{
					return widget.Sensitive;
				}
				set
				{
					widget.Sensitive = value;
				}
			}
			#endregion
		}
	}
}