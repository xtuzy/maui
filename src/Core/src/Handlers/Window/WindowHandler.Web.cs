using System;

namespace Microsoft.Maui.Handlers
{
	public partial class WindowHandler : ElementHandler<IWindow, Microsoft.AspNetCore.Components.ComponentBase>
	{
		public static void MapTitle(IWindowHandler handler, IWindow window) { }

		public static void MapContent(IWindowHandler handler, IWindow window) { }

		public static void MapRequestDisplayDensity(IWindowHandler handler, IWindow window, object? args) { }
	}
}