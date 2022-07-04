using System;

namespace Microsoft.Maui.Handlers
{
	public partial class SwipeItemViewHandler : ViewHandler<ISwipeItemView, Microsoft.AspNetCore.Components.ComponentBase>, ISwipeItemViewHandler
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView()
		{
			throw new NotImplementedException();
		}

		public static void MapContent(ISwipeItemViewHandler handler, ISwipeItemView page)
		{
		}

		public static void MapVisibility(ISwipeItemViewHandler handler, ISwipeItemView view)
		{
		}
	}
}
