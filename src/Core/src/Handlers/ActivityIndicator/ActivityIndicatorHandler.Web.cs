using System;

namespace Microsoft.Maui.Handlers
{
	public partial class ActivityIndicatorHandler : ViewHandler<IActivityIndicator, Microsoft.AspNetCore.Components.ComponentBase>
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView() => throw new NotImplementedException();

		public static void MapIsRunning(IActivityIndicatorHandler handler, IActivityIndicator activityIndicator) { }
		public static void MapColor(IActivityIndicatorHandler handler, IActivityIndicator activityIndicator) { }
	}
}