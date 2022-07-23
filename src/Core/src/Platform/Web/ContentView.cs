using System;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Microsoft.Maui.Platform
{
	public class ContentView : MauiView
	{
		IView? content;
		IElementHandler? contentHandler;
		internal Func<double, double, Size>? CrossPlatformMeasure { get; set; }
		internal Func<Rect, Size>? CrossPlatformArrange { get; set; }

		[Parameter] public IViewHandler? ContentViewHandler { get; set; }

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (ContentViewHandler == null)
				throw new InvalidOperationException($"{nameof(ContentViewHandler)} must be set to create a {nameof(ContentView)}");
			// ContentViewHandler.SetVirtualView(this);
			ContentViewHandler.SetPlatformView(this);
		}

		public void SetContent(IView content, IMauiContext context)
		{
			if (content is not null)
				ClearContent();

			this.content = content;
			this.contentHandler = content?.ToHandler(context);
			ThreadSafeStateHasChanged();
		}

		public void ClearContent()
		{
			content = null;
			ThreadSafeStateHasChanged();
		}

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			var seq = 0;
			// We open a div
			builder.OpenElement(seq, "div");
			// Then add some content to that the div, in this case the passed in Name parameter.
			if (this.contentHandler is Microsoft.Maui.Handlers.IHasPlatformViewType hasType) {
				var platformViewType = hasType.PlatformViewType;
				builder.OpenComponent(++seq, platformViewType);
				// builder.AddAttribute(++seq, "maui-context", MauiContext);
				builder.CloseComponent();
			}
			else if (this.contentHandler is not null) {
				throw new NotSupportedException($"ContentView does not support {this.contentHandler.GetType()}.");
			}
			// We then close the currently open element.
			builder.CloseElement();
		}
	}
}