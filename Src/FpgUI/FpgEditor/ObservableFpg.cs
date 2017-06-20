using System;
using System.Collections;
using System.Collections.Generic;
using FenixLib.Core;

namespace FpgUI.FpgEditor
{
	public class ObservableFpg : ISpriteAssortment
	{
		public event EventHandler Changed;

		private readonly ISpriteAssortment decorated;

		public ObservableFpg(ISpriteAssortment subject)
		{
			decorated = subject;
		}

		#region ISpriteAssortment implementation

		public void Add(int id, ISprite sprite)
		{
			decorated.Add(id, sprite);
			Changed?.Invoke(this, EventArgs.Empty);
		}

		public void Update(int id, ISprite sprite)
		{
			decorated.Update(id, sprite);
			Changed?.Invoke(this, EventArgs.Empty);
		}

		public void Remove(int id)
		{
			decorated.Remove(id);
			Changed?.Invoke(this, EventArgs.Empty);
		}

		public int GetFreeId()	=> decorated.GetFreeId();

		public GraphicFormat GraphicFormat => decorated.GraphicFormat;

		public Palette Palette => decorated.Palette;

		public SpriteAssortmentSprite this[int id] => decorated[id];

		public ICollection<SpriteAssortmentSprite> Sprites => decorated.Sprites;

		public IEnumerable<int> Ids => decorated.Ids;

		#endregion

		#region IEnumerable implementation

		public IEnumerator<SpriteAssortmentSprite> GetEnumerator() => decorated.GetEnumerator();
		#endregion

		#region IEnumerable implementation

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		#endregion
	}
}

