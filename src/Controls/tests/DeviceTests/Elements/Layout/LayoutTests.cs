﻿using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Xunit;
using Xunit.Sdk;

namespace Microsoft.Maui.DeviceTests
{
	[Category(TestCategory.Layout)]
	public partial class LayoutTests : ControlsHandlerTestBase
	{
		[Theory]
		[InlineData(true, true, true)]
		[InlineData(true, false, false)]
		[InlineData(false, true, false)]
		[InlineData(false, false, false)]
		public async Task CascadeInputTransparentAppliesOnAdd(bool inputTransparent, bool cascadeInputTransparent, bool expected)
		{
			var control = new StackLayout() { InputTransparent = inputTransparent, CascadeInputTransparent = cascadeInputTransparent };
			_ = await CreateHandlerAsync<LayoutHandler>(control);

			var child = new Button() { InputTransparent = false };
			_ = await CreateHandlerAsync<ButtonHandler>(child);

			await InvokeOnMainThreadAsync(() => control.Add(child));

			Assert.Equal(expected, child.InputTransparent);
		}

		[Theory]
		[InlineData(true, true, true)]
		[InlineData(true, false, false)]
		[InlineData(false, true, false)]
		[InlineData(false, false, false)]
		public async Task CascadeInputTransparentAppliesOnInsert(bool inputTransparent, bool cascadeInputTransparent, bool expected)
		{
			var control = new StackLayout()
			{
				InputTransparent = inputTransparent,
				CascadeInputTransparent = cascadeInputTransparent
			};

			_ = await CreateHandlerAsync<LayoutHandler>(control);

			var child = new Button() { InputTransparent = false };
			_ = await CreateHandlerAsync<ButtonHandler>(child);

			await InvokeOnMainThreadAsync(() => control.Insert(0, child));

			Assert.Equal(expected, child.InputTransparent);
		}

		[Theory]
		[InlineData(true, true, true)]
		[InlineData(true, false, false)]
		[InlineData(false, true, false)]
		[InlineData(false, false, false)]
		public async Task CascadeInputTransparentAppliesOnUpdate(bool inputTransparent, bool cascadeInputTransparent, bool expected)
		{
			var control = new StackLayout() { InputTransparent = inputTransparent, CascadeInputTransparent = cascadeInputTransparent };
			_ = await CreateHandlerAsync<LayoutHandler>(control);

			var child0 = new Button() { InputTransparent = false };
			_ = await CreateHandlerAsync<ButtonHandler>(child0);

			await InvokeOnMainThreadAsync(() => control.Add(child0));

			var child1 = new Button() { InputTransparent = false };
			_ = await CreateHandlerAsync<ButtonHandler>(child1);

			await InvokeOnMainThreadAsync(() => control[0] = child1);

			Assert.Equal(expected, child1.InputTransparent);
		}

		[Theory]
		[InlineData(true, true, true)]
		[InlineData(true, false, false)]
		[InlineData(false, true, false)]
		[InlineData(false, false, false)]
		public async Task CascadeInputTransparentAppliesOnInit(bool inputTransparent, bool cascadeInputTransparent, bool expected)
		{
			var child = new Button() { InputTransparent = false };
			_ = await CreateHandlerAsync<ButtonHandler>(child);

			var control = new StackLayout() { InputTransparent = inputTransparent, CascadeInputTransparent = cascadeInputTransparent };
			await InvokeOnMainThreadAsync(() => control.Add(child));
			_ = await CreateHandlerAsync<LayoutHandler>(control);

			Assert.Equal(expected, child.InputTransparent);
		}

		[Theory(
#if IOS || MACCATALYST
			Skip = "Not able to debug iOS right now"
#elif ANDROID
			Skip = "Android stopped working in the tests, but works in real life..."
#endif
		)]
		[InlineData(typeof(Grid), LayoutAlignment.Center)]
		[InlineData(typeof(Grid), LayoutAlignment.Start)]
		[InlineData(typeof(Grid), LayoutAlignment.End)]
		[InlineData(typeof(VerticalStackLayout), LayoutAlignment.Center)]
		[InlineData(typeof(VerticalStackLayout), LayoutAlignment.Start)]
		[InlineData(typeof(VerticalStackLayout), LayoutAlignment.End)]
		public async Task UpdatingLayoutOptionsTriggersParentToRepositionControl(Type layoutType, LayoutAlignment layoutAlignment)
		{
			var layoutOptions = new LayoutOptions(layoutAlignment, false);

			// create a layout with the values all set before creating the handler
			CreateLayout(layoutType, out var initialLayout, out var initialLabel);
			initialLabel.HorizontalOptions = layoutOptions;

			// create a layout that will update once attached
			CreateLayout(layoutType, out var updatingLayout, out var updatingLabel);

			await InvokeOnMainThreadAsync(async () =>
			{
				_ = CreateHandler<LabelHandler>(initialLabel);
				var initialHandler = CreateHandler<LayoutHandler>(initialLayout);
				var initialBitmap = await initialHandler.PlatformView.ToBitmap();

				_ = CreateHandler<LabelHandler>(updatingLabel);
				var updatingHandler = CreateHandler<LayoutHandler>(updatingLayout);
				var updatingBitmap = await updatingHandler.PlatformView.AttachAndRun(() =>
				{
					updatingLabel.HorizontalOptions = layoutOptions;

					return updatingHandler.PlatformView.ToBitmap();
				});

				await initialBitmap.AssertEqualAsync(updatingBitmap);
			});

			static void CreateLayout(Type layoutType, out Layout layout, out Label label)
			{
				layout = Activator.CreateInstance(layoutType) as Layout;
				layout.WidthRequest = 200;
				layout.HeightRequest = 100;
				layout.Background = Colors.Red;

				label = new Label
				{
					WidthRequest = 50,
					HeightRequest = 50,
					Text = "Text",
					TextColor = Colors.Blue,
				};

				layout.Add(label);
			}
		}

		[Fact, Category(TestCategory.FlexLayout)]
		public async Task FlexLayoutInVerticalStackLayoutDoesNotCycle() 
		{
			await FlexLayoutInStackLayoutDoesNotCycle(new VerticalStackLayout());
		}

		[Fact, Category(TestCategory.FlexLayout)]
		public async Task FlexLayoutInHorizontalStackLayoutDoesNotCycle()
		{
			await FlexLayoutInStackLayoutDoesNotCycle(new HorizontalStackLayout());
		}

		async Task FlexLayoutInStackLayoutDoesNotCycle(IStackLayout root)
		{
			var flexLayout = new FlexLayout();
			var label = new Label { Text = "Hello" };

			flexLayout.Add(label);
			root.Add(flexLayout);

			await InvokeOnMainThreadAsync(async () =>
			{
				var labelHandler = CreateHandler<LabelHandler>(label);
				var flexLayoutHandler = CreateHandler<LayoutHandler>(flexLayout);
				var layoutHandler = CreateHandler<LayoutHandler>(root);

				// If this can be attached to the hierarchy and make it through a layout 
				// without crashing, then we're good.
				
				await root.ToPlatform(MauiContext).AttachAndRun(() => { });
			});
		}
	}
}
