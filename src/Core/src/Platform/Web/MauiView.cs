using Microsoft.AspNetCore.Components;

namespace Microsoft.Maui.Platform
{
	public abstract class MauiView : ComponentBase
	{
		public IView? View { get; set; }

		protected bool HasBeenRendered { get; private set; }

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRender(firstRender);
			HasBeenRendered = true;
		}

		protected void ThreadSafeStateHasChanged()
		{
			if (HasBeenRendered) {
				this.InvokeAsync(() => StateHasChanged()).ContinueWith(t =>
				{
					if (t.IsFaulted)
					{
						throw t.Exception;
					}
				});
			}
		}
	}
}