using CommunityToolkit.Maui.Core;

namespace TouchBehavior_repro;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

#if IOS
        ChildView.GestureRecognizers.Add(new TapGestureRecognizer());        
#endif
    }

    private void TouchBehavior_OnTouchGestureCompleted(object? sender, TouchGestureCompletedEventArgs e)
    {
        DisplayAlert("Info", "Child element touched!", "OK");
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        DisplayAlert("Info", "Parent element touched!", "OK");
    }
}