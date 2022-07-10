using Microsoft.Maui.Graphics;
using Microsoft.AspNetCore.Components;

using PlatformView = Microsoft.AspNetCore.Components.ComponentBase;

namespace Microsoft.Maui.Platform
{
	public static class LabelExtensions
	{
		public static void UpdateTextColor(this PlatformView platformLabel, ITextStyle textStyle, object? defaultColor = null)
		{
		}

		public static void UpdateCharacterSpacing(this MauiLabel platformLabel, ITextStyle textStyle)
		{
		}

		public static void UpdateFont(this PlatformView platformLabel, ITextStyle textStyle, IFontManager fontManager, double defaultSize)
		{
		}

		public static void UpdateHorizontalTextAlignment(this PlatformView platformLabel, ILabel label)
		{
		}

		public static void UpdateVerticalTextAlignment(this PlatformView platformLabel, ILabel label)
		{
		}

		public static void UpdatePadding(this PlatformView platformLabel, ILabel label)
		{
		}

		public static void UpdateTextDecorations(this PlatformView platformLabel, ILabel label)
		{
		}

		public static void UpdateLineHeight(this PlatformView platformLabel, ILabel label)
		{
		}

		internal static void UpdateTextHtml(this PlatformView platformLabel, ILabel label)
		{
		}

		internal static void UpdateTextPlainText(this PlatformView platformLabel, IText label)
		{
		}
	}
}