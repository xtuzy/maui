using System;
using System.Threading.Tasks;

using PlatformView = Microsoft.AspNetCore.Components.ComponentBase;

namespace Microsoft.Maui.Platform
{
	public static partial class ViewExtensions
	{
		public static void UpdateIsEnabled(this PlatformView platformView, IView view) { }

		public static void Focus(this PlatformView platformView, FocusRequest request) { }

		public static void Unfocus(this PlatformView platformView, IView view) { }

		public static void UpdateVisibility(this PlatformView platformView, IView view) { }

		public static Task UpdateBackgroundImageSourceAsync(this PlatformView platformView, IImageSource? imageSource, IImageSourceServiceProvider? provider)
			=> Task.CompletedTask;

		public static void UpdateBackground(this PlatformView platformView, IView view) { }

		public static void UpdateClipsToBounds(this PlatformView platformView, IView view) { }

		public static void UpdateAutomationId(this PlatformView platformView, IView view) { }

		public static void UpdateClip(this PlatformView platformView, IView view) { }

		public static void UpdateShadow(this PlatformView platformView, IView view) { }

		public static void UpdateBorder(this PlatformView platformView, IView view) { }

		public static void UpdateOpacity(this PlatformView platformView, IView view) { }

		public static void UpdateSemantics(this PlatformView platformView, IView view) { }

		public static void UpdateFlowDirection(this PlatformView platformView, IView view) { }

		public static void UpdateTranslationX(this PlatformView platformView, IView view) { }

		public static void UpdateTranslationY(this PlatformView platformView, IView view) { }

		public static void UpdateScale(this PlatformView platformView, IView view) { }

		public static void UpdateRotation(this PlatformView platformView, IView view) { }

		public static void UpdateRotationX(this PlatformView platformView, IView view) { }

		public static void UpdateRotationY(this PlatformView platformView, IView view) { }

		public static void UpdateAnchorX(this PlatformView platformView, IView view) { }

		public static void UpdateAnchorY(this PlatformView platformView, IView view) { }

		public static void InvalidateMeasure(this PlatformView platformView, IView view) { }

		public static void UpdateWidth(this PlatformView platformView, IView view) { }

		public static void UpdateHeight(this PlatformView platformView, IView view) { }

		public static void UpdateMinimumHeight(this PlatformView platformView, IView view) { }

		public static void UpdateMaximumHeight(this PlatformView platformView, IView view) { }

		public static void UpdateMinimumWidth(this PlatformView platformView, IView view) { }

		public static void UpdateMaximumWidth(this PlatformView platformView, IView view) { }

		internal static Graphics.Rect GetPlatformViewBounds(this IView view) => view.Frame;

		internal static System.Numerics.Matrix4x4 GetViewTransform(this IView view) => new System.Numerics.Matrix4x4();

		internal static Graphics.Rect GetBoundingBox(this IView view) => view.Frame;

		internal static PlatformView? GetParent(this PlatformView? view)
		{
			return null;
		}

		internal static IWindow? GetHostedWindow(this IView? view)
			=> null;

		public static void UpdateInputTransparent(this PlatformView nativeView, IViewHandler handler, IView view) { }

		public static void UpdateBackgroundLayerFrame(this PlatformView view)
		{
		}

		internal static IDisposable OnUnloaded(this PlatformView uiView, Action action)
		{
			throw new NotImplementedException();
		}

		internal static IDisposable OnLoaded(this PlatformView uiView, Action action)
		{
			throw new NotImplementedException();
		}
	}
}