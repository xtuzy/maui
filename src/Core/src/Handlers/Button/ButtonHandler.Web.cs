using System;
using System.Threading.Tasks;

namespace Microsoft.Maui.Handlers
{
	public partial class ButtonHandler : ViewHandler<IButton, MauiButton>
	{
		// This appears to be the padding that Xcode has when "Default" content insets are used
		public readonly static Thickness DefaultPadding = new Thickness(12, 7);

		protected override MauiButton CreatePlatformView()
		{
			var button = new MauiButton();
			return button;
		}

		protected override void ConnectHandler(MauiButton platformView)
		{
			// platformView.TouchUpInside += OnButtonTouchUpInside;
			// platformView.TouchUpOutside += OnButtonTouchUpOutside;
			// platformView.TouchDown += OnButtonTouchDown;

			base.ConnectHandler(platformView);
		}

		protected override void DisconnectHandler(MauiButton platformView)
		{
			// platformView.TouchUpInside -= OnButtonTouchUpInside;
			// platformView.TouchUpOutside -= OnButtonTouchUpOutside;
			// platformView.TouchDown -= OnButtonTouchDown;

			base.DisconnectHandler(platformView);
		}

		public static void MapStrokeColor(IButtonHandler handler, IButtonStroke buttonStroke)
		{
			handler.PlatformView?.UpdateStrokeColor(buttonStroke);
		}

		public static void MapStrokeThickness(IButtonHandler handler, IButtonStroke buttonStroke)
		{
			handler.PlatformView?.UpdateStrokeThickness(buttonStroke);
		}

		public static void MapCornerRadius(IButtonHandler handler, IButtonStroke buttonStroke)
		{
			handler.PlatformView?.UpdateCornerRadius(buttonStroke);
		}

		public static void MapText(IButtonHandler handler, IText button)
		{
			handler.PlatformView?.UpdateText(button);

			// Any text update requires that we update any attributed string formatting
			MapFormatting(handler, button);
		}

		public static void MapTextColor(IButtonHandler handler, ITextStyle button)
		{
			handler.PlatformView?.UpdateTextColor(button);
		}

		public static void MapCharacterSpacing(IButtonHandler handler, ITextStyle button)
		{
			handler.PlatformView?.UpdateCharacterSpacing(button);
		}

		public static void MapPadding(IButtonHandler handler, IButton button)
		{
			handler.PlatformView?.UpdatePadding(button, DefaultPadding);
		}

		public static void MapFont(IButtonHandler handler, ITextStyle button)
		{
			var fontManager = handler.GetRequiredService<IFontManager>();

			handler.PlatformView?.UpdateFont(button, fontManager);
		}

		public static void MapFormatting(IButtonHandler handler, IText button)
		{
			// Update all of the attributed text formatting properties
			handler.PlatformView?.UpdateCharacterSpacing(button);
		}

		void OnSetImageSource(object? image)
		{
			if (image != null)
			{
				// PlatformView.SetImage(image);
			}
			else
			{
				// PlatformView.SetImage(null);
			}
		}

		public static void MapImageSource(IButtonHandler handler, IImage image) =>
			MapImageSourceAsync(handler, image).FireAndForget(handler);

		public static Task MapImageSourceAsync(IButtonHandler handler, IImage image)
		{
			if (image.Source == null)
			{
				return Task.CompletedTask;
			}

			return handler.ImageSourceLoader.UpdateImageSourceAsync();
		}

		void OnButtonTouchUpInside(object? sender, EventArgs e)
		{
			VirtualView?.Released();
			VirtualView?.Clicked();
		}

		void OnButtonTouchUpOutside(object? sender, EventArgs e)
		{
			VirtualView?.Released();
		}

		void OnButtonTouchDown(object? sender, EventArgs e)
		{
			VirtualView?.Pressed();
		}
	}
}