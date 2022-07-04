using System;

namespace Microsoft.Maui.Handlers
{
	public partial class ProgressBarHandler : ViewHandler<IProgress, Microsoft.AspNetCore.Components.ComponentBase>
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView() => throw new NotImplementedException();

		public static void MapProgress(IProgressBarHandler handler, IProgress progress) { }
		public static void MapProgressColor(IProgressBarHandler handler, IProgress progress) { }
	}
}