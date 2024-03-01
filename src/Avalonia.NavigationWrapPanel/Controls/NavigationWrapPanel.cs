using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;

namespace Avalonia.Controls;

public class NavigationWrapPanel : WrapPanel
{
    protected override void OnKeyDown(KeyEventArgs e)
    {
        var currentFocused = Children.SingleOrDefault(i => ((ContentPresenter)i).Child!.IsFocused);

        if (currentFocused == null || !Children.Any())
        {
            currentFocused = ((ContentPresenter)Children.First()).Child;
            currentFocused?.Focus();
        }

        switch (e.Key)
        {
            case Key.Up:
                MoveFocusUp(currentFocused!);
                break;
            case Key.Down:
                MoveFocusDown(currentFocused!);
                break;
            case Key.Left:
                MoveFocusLeft(currentFocused!);
                break;
            case Key.Right:
                MoveFocusRight(currentFocused!);
                break;
        }
        
        base.OnKeyDown(e);
        
    }
    
    private void MoveFocusUp(Control currentFocused)
    {
        Control? itemUp = Children.LastOrDefault(i =>
            Math.Abs(i.Bounds.Left - currentFocused.Bounds.Left) < 1
            && i.Bounds.Top < currentFocused.Bounds.Top);

        FocusControl(itemUp);
    }

    private void MoveFocusDown(Control currentFocused)
    {
        Control? itemDown = Children.FirstOrDefault(i =>
            Math.Abs(i.Bounds.Left - currentFocused.Bounds.Left) < 1
            && i.Bounds.Top > currentFocused.Bounds.Top);

        FocusControl(itemDown);
    }

    private void MoveFocusLeft(Control currentFocused)
    {
        Control? itemLeft = Children.LastOrDefault(i =>
            i.Bounds.Left < currentFocused.Bounds.Left
            && Math.Abs(i.Bounds.Top - currentFocused.Bounds.Top) < 1);

        FocusControl(itemLeft);
    }

    private void MoveFocusRight(Control currentFocused)
    {
        Control? itemToTheRight = Children.FirstOrDefault(i =>
            i.Bounds.Left > currentFocused.Bounds.Left
            && Math.Abs(i.Bounds.Top - currentFocused.Bounds.Top) < 1);

        FocusControl(itemToTheRight);
    }

    private static void FocusControl(Control? control)
    {
        ContentPresenter? contentControl = control as ContentPresenter;
        contentControl?.Child?.Focus();
    }
}