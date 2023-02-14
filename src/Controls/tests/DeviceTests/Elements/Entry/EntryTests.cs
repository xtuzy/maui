﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.DeviceTests.Stubs;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using Xunit;

namespace Microsoft.Maui.DeviceTests
{
	[Category(TestCategory.Entry)]
	public partial class EntryTests : ControlsHandlerTestBase
	{
		[Theory(DisplayName = "Text is Transformed Correctly at Initialization")]
		[ClassData(typeof(TextTransformCases))]
		public async Task InitialTextTransformApplied(string text, TextTransform transform, string expected)
		{
			var control = new Entry() { Text = text, TextTransform = transform };
			var platformText = await GetPlatformText(await CreateHandlerAsync<EntryHandler>(control));
			Assert.Equal(expected, platformText);
		}

		[Theory(DisplayName = "Text is Transformed Correctly after Initialization")]
		[ClassData(typeof(TextTransformCases))]
		public async Task TextTransformUpdated(string text, TextTransform transform, string expected)
		{
			var control = new Entry() { Text = text };
			var handler = await CreateHandlerAsync<EntryHandler>(control);
			await InvokeOnMainThreadAsync(() => control.TextTransform = transform);
			var platformText = await GetPlatformText(handler);
			Assert.Equal(expected, platformText);
		}

#if WINDOWS
		// Only Windows needs the IsReadOnly workaround for MaxLength==0 to prevent text from being entered
		[Fact]
		public async Task MaxLengthIsReadOnlyValueTest()
		{
			Entry entry = new Entry();

			await InvokeOnMainThreadAsync(() =>
			{
				var handler = CreateHandler<EntryHandler>(entry);
				var platformControl = GetPlatformControl(handler);

				entry.MaxLength = 0;
				Assert.True(platformControl.IsReadOnly);
				entry.IsReadOnly = false;
				Assert.True(platformControl.IsReadOnly);

				entry.MaxLength = 10;
				Assert.False(platformControl.IsReadOnly);
				entry.IsReadOnly = true;
				Assert.True(platformControl.IsReadOnly);
			});
		}


		[Fact(DisplayName = "Unfocus will work when page is shown a 2nd time")]
		public async Task UnFocusOnEntryAfterPagePop()
		{
			int unfocused = 0;
			EnsureHandlerCreated(builder =>
			{
				builder.ConfigureMauiHandlers(handlers =>
				{
					handlers.AddHandler(typeof(Toolbar), typeof(ToolbarHandler));
					handlers.AddHandler(typeof(NavigationPage), typeof(NavigationViewHandler));
					handlers.AddHandler<Page, PageHandler>();
					handlers.AddHandler(typeof(Window), typeof(WindowHandlerStub));
					handlers.AddHandler(typeof(Entry), typeof(EntryHandler));

				});
			});
			AutoResetEvent _focused = new AutoResetEvent(false);
			AutoResetEvent _unFocused = new AutoResetEvent(false);
			var entry = new Entry();
			entry.Unfocused += (s, e) =>
			{
				if (!e.IsFocused)
				{
					unfocused++;
				}
				_unFocused.Set();
			};
			var navPage = new NavigationPage(new ContentPage { Content = entry });
			var window = new Window(navPage);

			await CreateHandlerAndAddToWindow<WindowHandlerStub>(window, async (handler) =>
			{
				await Task.Run(() =>
				{
					InvokeOnMainThreadAsync(() =>
					{
						entry.Focused += (s, e) => _focused.Set();
						entry.Focus();
					});
					_focused.WaitOne();
					_focused.Reset();
					InvokeOnMainThreadAsync(async () =>
					{
						entry.Unfocus();
						await navPage.PushAsync(new ContentPage());
						await navPage.PopAsync();
						entry.Focus();
					});
					_focused.WaitOne();
					_unFocused.Reset();
					InvokeOnMainThreadAsync(() =>
					{
						entry.Unfocus();
					});
					_unFocused.WaitOne();
					Assert.True(unfocused == 2);
				});
			});
		}
#endif

		[Theory(DisplayName = "CursorPosition Initializes Correctly")]
		[InlineData(2)]
		public async Task CursorPositionInitializesCorrectly(int initialPosition)
		{
			var entry = new Entry
			{
				Text = "This is TEXT!",
				CursorPosition = initialPosition
			};

			await ValidatePropertyInitValue<int, EntryHandler>(
				entry,
				() => entry.CursorPosition,
				GetPlatformCursorPosition,
				initialPosition);
		}

		[Theory(DisplayName = "CursorPosition Updates Correctly")]
		[InlineData(2, 5)]
		public async Task CursorPositionUpdatesCorrectly(int setValue, int unsetValue)
		{
			string text = "This is TEXT!";

			var entry = new Entry
			{
				Text = text
			};

			await ValidatePropertyUpdatesValue<int, EntryHandler>(
				entry,
				nameof(ITextInput.CursorPosition),
				GetPlatformCursorPosition,
				setValue,
				unsetValue
			);
		}

		[Theory(DisplayName = "CursorPosition is Capped to Text's Length")]
		[InlineData(30)]
		public async Task CursorPositionIsCapped(int initialPosition)
		{
			string text = "This is TEXT!";

			var entry = new Entry
			{
				Text = text,
				CursorPosition = initialPosition
			};

			await ValidatePropertyInitValue<int, EntryHandler>(
				entry,
				() => entry.CursorPosition,
				GetPlatformCursorPosition,
				text.Length);
		}

		[Theory(DisplayName = "Unset CursorPosition is kept at zero at initialization")]
		[InlineData("This is a test!!!")]
		[InlineData("a")]
		[InlineData("")]
		[InlineData(" ")]
		public async Task UnsetCursorPositionIsKeptAtZeroAtInitialization(string text)
		{
			var entry = new Entry
			{
				Text = text
			};

			await ValidatePropertyInitValue<int, EntryHandler>(
				entry,
				() => entry.CursorPosition,
				GetPlatformCursorPosition,
				0);
		}

		[Theory(DisplayName = "CursorPosition moves to the end on text change by code after initialization"
#if WINDOWS
			, Skip = "For some reason, the PlatformView events are not being fired on tests after the handler is created, something is swallowing them. " +
					 "This was tested on a real app and it's working correctly."
#endif
			)]
		[InlineData("This is a test!!!")]
		[InlineData("a")]
		[InlineData("")]
		[InlineData(" ")]
		public async Task CursorPositionMovesToTheEndOnTextChangeAfterInitialization(string text)
		{
			var entry = new Entry
			{
				Text = "Test"
			};

			await SetValueAsync<string, EntryHandler>(entry, text, (h, s) => h.VirtualView.Text = s);

			Assert.Equal(text.Length, entry.CursorPosition);
		}

		[Theory(DisplayName = "SelectionLength Initializes Correctly")]
		[InlineData(2)]
		public async Task SelectionLengthInitializesCorrectly(int initialLength)
		{
			var entry = new Entry
			{
				Text = "This is TEXT!",
				SelectionLength = initialLength
			};

			await ValidatePropertyInitValue<int, EntryHandler>(
				entry,
				() => entry.SelectionLength,
				GetPlatformSelectionLength,
				initialLength);
		}

		[Theory(DisplayName = "SelectionLength Updates Correctly")]
		[InlineData(2, 5)]
		public async Task SelectionLengthUpdatesCorrectly(int setValue, int unsetValue)
		{
			string text = "This is TEXT!";

			var entry = new Entry
			{
				Text = text,
			};

			await ValidatePropertyUpdatesValue<int, EntryHandler>(
				entry,
				nameof(IEntry.SelectionLength),
				GetPlatformSelectionLength,
				setValue,
				unsetValue
			);
		}

		[Theory(DisplayName = "SelectionLength is Capped to Text Length")]
		[InlineData(30)]
		public async Task SelectionLengthIsCapped(int selectionLength)
		{
			string text = "This is TEXT!";

			var entry = new Entry
			{
				Text = text,
				SelectionLength = selectionLength
			};

			await ValidatePropertyInitValue<int, EntryHandler>(
				entry,
				() => entry.SelectionLength,
				GetPlatformSelectionLength,
				text.Length);
		}

		[Theory(DisplayName = "Unset SelectionLength is kept at zero at initialization")]
		[InlineData("This is a test!!!")]
		[InlineData("a")]
		[InlineData("")]
		[InlineData(" ")]
		public async Task UnsetSelectionLengthIsKeptAtZeroAtInitialization(string text)
		{
			var entry = new Entry
			{
				Text = text
			};

			await ValidatePropertyInitValue<int, EntryHandler>(
				entry,
				() => entry.SelectionLength,
				GetPlatformSelectionLength,
				0);
		}

		[Theory(DisplayName = "SelectionLength is kept at zero on text change by code after initialization"
#if WINDOWS
			, Skip = "For some reason, the PlatformView events are not being fired on tests after the handler is created, something is swallowing them. " +
					 "This was tested on a real app and it's working correctly."
#endif
			)]
		[InlineData("This is a test!!!")]
		[InlineData("a")]
		[InlineData("")]
		[InlineData(" ")]
		public async Task SelectionLengthMovesToTheEndOnTextChangeAfterInitialization(string text)
		{
			var entry = new Entry
			{
				Text = "Test"
			};

			await SetValueAsync<string, EntryHandler>(entry, text, (h, s) => h.VirtualView.Text = s);

			Assert.Equal(0, entry.SelectionLength);
		}
	}
}
