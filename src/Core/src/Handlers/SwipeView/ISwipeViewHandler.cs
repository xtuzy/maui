#if __IOS__ || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiSwipeView;
#elif MONOANDROID
using PlatformView = Microsoft.Maui.Platform.MauiSwipeView;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.SwipeControl;
#elif TIZEN
using PlatformView = ElmSharp.EvasObject;
#elif WEB
using PlatformView = Microsoft.AspNetCore.Components.ComponentBase;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN && !WEB)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Handlers
{
	public partial interface ISwipeViewHandler : IViewHandler
	{
		new ISwipeView VirtualView { get; }
		new PlatformView PlatformView { get; }
	}
}
