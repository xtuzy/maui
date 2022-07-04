using System;

namespace Microsoft.Maui.Handlers
{
	public partial class GraphicsViewHandler : ViewHandler<IGraphicsView, Microsoft.AspNetCore.Components.ComponentBase>
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView() => throw new NotImplementedException();

		public static void MapDrawable(IGraphicsViewHandler handler, IGraphicsView graphicsView) { }
		public static void MapFlowDirection(IGraphicsViewHandler handler, IGraphicsView graphicsView) { }

		public static void MapInvalidate(IGraphicsViewHandler handler, IGraphicsView graphicsView, object? arg) { }
	}
}