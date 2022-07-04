using System;

namespace Microsoft.Maui.Handlers
{
	public partial class ToolbarHandler : ElementHandler<IToolbar, Microsoft.AspNetCore.Components.ComponentBase>
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformElement() => throw new NotImplementedException();

		public static void MapTitle(IToolbarHandler arg1, IToolbar arg2)
		{
		}
	}
}