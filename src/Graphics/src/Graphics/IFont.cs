namespace Microsoft.Maui.Graphics
{
	public interface IFont
	{
		string Name { get; }
		int Weight { get; }
		FontStyleType StyleType { get; }
#if IOS || MACCATALYST || MACOS
		public CoreGraphics.CGFont PlatformFont { get; }
#endif
	}
}
