using System;
using System.IO;
using FenixLib.Core;
using FenixLib.IO;

namespace FpgUI
{
	/*
	 * Methods to load or to save data from the model. 
	 * 
	 * These methods are totally disconnected from the view.
	 * 
	 * They rely on the FenixLib.IO decoders. Every load/save method has
	 * a two-parameter overload that takes a IDecoder<?>. The single-parameter 
	 * overload invokes the two-parameter version.
	 * 
	 * Only the two-parameter version need to be tested.
	 */
	public partial class FpgEditorController
	{
		public void New(GraphicFormat f, Palette p)
		{
			editor.Fpg = new SpriteAssortment(f, p);
			editor.FileName = null;
			HasChanged = false;
			UpdateEnabledControls();
		}

		public void Load(string filename,  IDecoder<ISpriteAssortment> decoder)
		{
			using (var stream = File.Open(
				filename, 
				FileMode.Open, 
				FileAccess.Read, 
				FileShare.None))
			{
				var fpg = decoder.Decode(stream);
				editor.FileName = filename;
				editor.Fpg = fpg;
			}
			HasChanged = false;
		}

		public void Load(string filename)
		{
			Load(filename, new FpgSpriteAssortmentDecoder());
			UpdateEnabledControls();
		}

		public void Save(string filename, IEncoder<ISpriteAssortment> encoder)
		{
			using (var stream = File.Open(
				filename, 
				FileMode.Create, 
				FileAccess.Write,
				FileShare.None))
			{
				encoder.Encode(editor.Fpg, stream);
				editor.FileName = filename;
			}
			HasChanged = false;
		}

		public void Save(string filename)
		{
			Save(filename, new FpgSpriteAssortmentEncoder());
		}

		public void ExtractPalette(string filename, IEncoder<Palette> encoder)
		{
			using (var stream = File.Open(
				filename,
				FileMode.Create,
				FileAccess.Write,
				FileShare.None))
			{
				encoder.Encode(editor.Fpg.Palette, stream);
			}
		}

		public void ExtractPalette(string filename)
		{
			ExtractPalette(filename, new PalPaletteEncoder());
		}
	}
}

