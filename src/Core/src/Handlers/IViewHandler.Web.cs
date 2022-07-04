using Microsoft.AspNetCore.Components;

namespace Microsoft.Maui
{
	public interface IPlatformViewHandler : IViewHandler
	{
		new ComponentBase? PlatformView { get; }
		new ComponentBase? ContainerView { get; }
	}
}