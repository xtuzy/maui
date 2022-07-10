using System;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.AspNetCore.Components;

namespace Microsoft.Maui.Platform
{
	public class ContentView : MauiView
	{
		internal Func<double, double, Size>? CrossPlatformMeasure { get; set; }
		internal Func<Rect, Size>? CrossPlatformArrange { get; set; }

		public void SetContent(ComponentBase content)
		{
			throw new NotImplementedException($"ContentView does not support {content.GetType()} content.");
		}

		public void ClearContent()
		{
		}
	}
}