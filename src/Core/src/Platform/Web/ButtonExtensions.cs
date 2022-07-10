using System;
using Microsoft.AspNetCore.Components;

using PlatformView = Microsoft.AspNetCore.Components.ComponentBase;

namespace Microsoft.Maui.Platform
{
	public static class ButtonExtensions
	{
		public const double AlmostZero = 0.00001;

		public static void UpdateStrokeColor(this ComponentBase platformButton, IButtonStroke buttonStroke)
		{
		}

		public static void UpdateStrokeThickness(this ComponentBase platformButton, IButtonStroke buttonStroke)
		{
		}

		public static void UpdateCornerRadius(this ComponentBase platformButton, IButtonStroke buttonStroke)
		{
		}

		public static void UpdateText(this ComponentBase platformButton, IText button)
		{

		}

		public static void UpdateTextColor(this ComponentBase platformButton, ITextStyle button)
		{
		}

		public static void UpdateCharacterSpacing(this MauiButton platformButton, ITextStyle textStyle)
		{
		}

		public static void UpdateFont(this ComponentBase platformButton, ITextStyle textStyle, IFontManager fontManager)
		{
		}

		public static void UpdatePadding(this ComponentBase platformButton, IButton button, Thickness? defaultPadding = null)
		{

		}

		public static void UpdatePadding(this ComponentBase platformButton, Thickness padding, Thickness? defaultPadding = null)
		{
		}


	}
}