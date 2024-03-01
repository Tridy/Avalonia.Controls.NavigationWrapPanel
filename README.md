# Avalonia.Controls.NavigationWrapPanel
A wrapper for the original Avalonia WrapPanel that allows navigation between items using cursor keys. It could be helpful for the cases when a panel needs to be navigated with an IR remote control, for instance.

The solution consists of 2 projects.
1. 
2. NavigationWrapPanel - the implementation of the panel control

2. TestUi - a test project for the panel where it is possible to navigate the items using the cursor keys, change the size of the window and test the navigation with the changed layout.

in MainWindow of the TestUI project on Window.Opened event the focus is set on the first item of the panel, so that it would be possible to use the the cursor keys to navigate the items without the need to focus the first item manually.
