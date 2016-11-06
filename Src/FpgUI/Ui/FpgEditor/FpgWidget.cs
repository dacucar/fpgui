using System;
using System.Collections.Generic;
using System.Linq;
using Xwt;
using Xwt.Drawing;
using FenixLib.Core;

namespace FpgUI.Ui
{
	public class FpgWidget : ListView
	{
		DataField<int> id = new DataField<int>();
		DataField<string> name = new DataField<string>();
		DataField<string> size = new DataField<string>();
		DataField<string> center = new DataField<string>();
		ListStore store;

		private ISpriteAssortment fpg;

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

		public IEnumerable<int> SelectedIds =>
			 this.SelectedRows.Select(r => store.GetValue(r, id)); 
		

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
	}
}

