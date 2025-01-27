using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using Syncfusion.Maui.Toolkit.EffectsView;
using Syncfusion.Maui.Toolkit.Internals;
using PointerEventArgs = Microsoft.Maui.Controls.PointerEventArgs;
using Timer = System.Timers.Timer;

namespace TouchBehavior_repro;

public partial class MainPage : ContentPage, ILongPressGestureListener
{
    private readonly Timer _longPressTimer;
    
    public MainPage()
    {
        ShowContextMenuCommand = new Command(ShowContextMenuHandler);
        _longPressTimer = new(300);
        _longPressTimer.Elapsed += (sender, args) =>
        {
            MainThread.BeginInvokeOnMainThread(() => DisplayAlert("Info", "Long Press", "OK"));
            _longPressTimer.Stop();
        };
        
        InitializeComponent();
        
        var gesture = new GestureDetector(LoanBorder);
        gesture.AddListener(this);
    }

    public ICommand ShowContextMenuCommand { get; }

    private void ShowContextMenuHandler() => DisplayAlert("Info", "ShowContextMenuHandler", "OK");
    
    private void TouchBehavior_OnTouchGestureCompleted(object? sender, TouchGestureCompletedEventArgs e)
    {
        DisplayAlert("Info", "Child element touched!", "OK");
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        DisplayAlert("Info", "Parent element touched!", "OK");
    }

    private void Expander_OnExpandedChanged(object? sender, ExpandedChangedEventArgs e)
    {
        DisplayAlert("Info", "Expander_OnExpandedChanged", "OK");
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        DisplayAlert("Info", "Button_OnClicked", "OK");
    }

    private void PointerGestureRecognizer_OnPointerReleased(object? sender, PointerEventArgs e)
    {
        _longPressTimer.Stop();
    }

    private void PointerGestureRecognizer_OnPointerPressed(object? sender, PointerEventArgs e)
    {
        _longPressTimer.Start();
    }

    public void OnLongPress(LongPressEventArgs e)
    {
        DisplayAlert("Info", "Sf Long Click", "OK");
    }
}