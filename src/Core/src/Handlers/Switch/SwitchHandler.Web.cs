using System;

namespace Microsoft.Maui.Handlers
{
	public partial class SwitchHandler : ViewHandler<ISwitch, Microsoft.AspNetCore.Components.ComponentBase>
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView() => throw new NotImplementedException();

		public static void MapIsOn(ISwitchHandler handler, ISwitch view) { }
		public static void MapTrackColor(ISwitchHandler handler, ISwitch view) { }
		public static void MapThumbColor(ISwitchHandler handler, ISwitch view) { }
	}
}