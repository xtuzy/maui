using System;

namespace Microsoft.Maui.Handlers
{
	public partial class MenuBarHandler : ElementHandler<IMenuBar, Microsoft.AspNetCore.Components.ComponentBase>, IMenuBarHandler
	{
		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformElement()
		{
			throw new NotImplementedException();
		}

		public void Add(IMenuBarItem view)
		{
		}

		public void Remove(IMenuBarItem view)
		{
		}

		public void Clear()
		{
		}

		public void Insert(int index, IMenuBarItem view)
		{
		}
	}
}
