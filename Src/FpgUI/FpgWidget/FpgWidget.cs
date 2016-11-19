using System;
using System.Collections.Generic;
using System.Linq;
using Xwt;
using Xwt.Drawing;
using FenixLib.Core;

namespace FpgUI.Widgets
{
	public class FpgWidget : ListView, IFpgWidget
	{
		private DataField<int> id = new DataField<int>();
		private DataField<string> name = new DataField<string>();
		private DataField<string> size = new DataField<string>();
		private DataField<string> center = new DataField<string>();
		private ListStore store;

		private ISpriteAssortment fpg;

		public FpgWidget()
		{
			this.SelectionMode = SelectionMode.Multiple;
			store = new ListStore(id, name, size, center);
			Columns.Add("Id", id);
			Columns.Add("Description", name);
			Columns.Add("Size", size);
			Columns.Add("Center", center);
			DataSource = store;
		}

		public ISpriteAssortment Fpg
		{ 
			get
			{
				return fpg;
			}
			set
			{
				fpg = value;
				store.Clear();
				if (fpg != null)
				{
					foreach (var s in fpg)
					{
						var r = store.AddRow();
						store.SetValue(r, id, s.Id);
						store.SetValue(r, name, s.Description);
						store.SetValue(r, size, $"{s.Width}x{s.Height}");
						store.SetValue(r, center, $"{s.Center.X}x{s.Center.Y}");
					}
				}
			}
		}

		public IEnumerable<ISprite> SelectedSprites
		{
			get
			{
				return this.SelectedRows.Select(r => Fpg[store.GetValue(r, id)]);
			}
		}
	}
}

