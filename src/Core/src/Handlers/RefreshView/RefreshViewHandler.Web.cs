using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Maui.Handlers
{
	public partial class RefreshViewHandler : ViewHandler<IRefreshView, Microsoft.AspNetCore.Components.ComponentBase>
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView() => throw new NotImplementedException();

		public static void MapIsRefreshing(IRefreshViewHandler handler, IRefreshView refreshView)
		{
		}

		public static void MapContent(IRefreshViewHandler handler, IRefreshView refreshView)
		{
		}

		public static void MapRefreshColor(IRefreshViewHandler handler, IRefreshView refreshView)
		{
		}

		public static void MapRefreshViewBackground(IRefreshViewHandler handler, IView view)
		{
		}
	}
}
