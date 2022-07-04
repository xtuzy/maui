using System;

namespace Microsoft.Maui.Handlers
{
	public partial class CheckBoxHandler : ViewHandler<ICheckBox, Microsoft.AspNetCore.Components.ComponentBase>
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView() => throw new NotImplementedException();

		public static void MapIsChecked(ICheckBoxHandler handler, ICheckBox check) { }

		public static void MapForeground(ICheckBoxHandler handler, ICheckBox check) { }
	}
}