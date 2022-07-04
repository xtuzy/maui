#if __IOS__ || MACCATALYST
using PlatformView = UIKit.UIButton;
#elif MONOANDROID
using PlatformView = Google.Android.Material.ImageView.ShapeableImageView;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.Button;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.MauiImageButton;
#elif WEB
using PlatformView = Microsoft.AspNetCore.Components.ComponentBase;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN && !WEB)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Handlers
{
	public interface IImageButtonHandler : IImageHandler
	{
		new IImageButton VirtualView { get; }
		new PlatformView PlatformView { get; }
	}
}