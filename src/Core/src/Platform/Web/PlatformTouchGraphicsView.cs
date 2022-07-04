using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;

namespace Microsoft.Maui.Platform
{
	public class PlatformTouchGraphicsView : Microsoft.AspNetCore.Components.ComponentBase
	{
		IGraphicsView? graphicsView;

		public void Connect(IGraphicsView graphicsView)
		{
		}
		public void Disconnect()
		{
		}
	}
}