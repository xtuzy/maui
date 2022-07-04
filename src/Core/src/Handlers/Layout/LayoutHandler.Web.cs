using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Maui.Handlers
{
	public partial class LayoutHandler : ViewHandler<ILayout, Microsoft.AspNetCore.Components.ComponentBase>
	{
		public void Add(IView view) => throw new NotImplementedException();
		public void Remove(IView view) => throw new NotImplementedException();
		public void Clear() => throw new NotImplementedException();
		public void Insert(int index, IView view) => throw new NotImplementedException();
		public void Update(int index, IView view) => throw new NotImplementedException();
		public void UpdateZIndex(IView view) => throw new NotImplementedException();

		protected override Microsoft.AspNetCore.Components.ComponentBase CreatePlatformView() => throw new NotImplementedException();
	}
}
