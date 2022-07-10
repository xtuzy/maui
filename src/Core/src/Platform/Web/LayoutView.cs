using System;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Microsoft.Maui.Platform
{
	public class LayoutView : MauiView
	{
		readonly List<ComponentBase> subviews = new List<ComponentBase>();
		internal Func<double, double, Size>? CrossPlatformMeasure { get; set; }
		internal Func<Rect, Size>? CrossPlatformArrange { get; set; }

		public int SubviewsCount => subviews.Count;

		public void AddSubview(ComponentBase subview)
		{
			subviews.Add(subview);
			ThreadSafeStateHasChanged();
		}

		public void InsertSubview(ComponentBase subview, int index)
		{
			subviews.Insert(index, subview);
			ThreadSafeStateHasChanged();
		}

		public ComponentBase GetSubview(int index)
		{
			return subviews[index];
		}
		public int IndexOfSubview(ComponentBase subview)
		{
			return subviews.IndexOf(subview);
		}

		public void RemoveSubview(ComponentBase subview)
		{
			subviews.Remove(subview);
			ThreadSafeStateHasChanged();
		}

		public void RemoveSubviewAt(int index)
		{
			subviews.RemoveAt(index);
			ThreadSafeStateHasChanged();
		}

		public void ClearSubviews()
		{
			subviews.Clear();
			ThreadSafeStateHasChanged();
		}

	}
}