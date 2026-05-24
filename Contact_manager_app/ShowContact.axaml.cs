using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Contact_manager_app.Views;

public partial class WindowShowContact : UserControl
{
    private Logic _logic;
    
    public WindowShowContact(object sendContacts, Logic sharedLogic)
    {
        InitializeComponent();
        
        _logic = sharedLogic;

        lstContacts.ItemsSource = (System.Collections.IEnumerable)sendContacts;
    }

    private void DeleteContact(object? sender, RoutedEventArgs e)
    {
        _logic.DeleteContact(lstContacts.SelectedIndex);
    }

    private async void EditContact(object? sender, RoutedEventArgs e)
    {
        if (lstContacts.SelectedItem is Contact selectedContact && lstContacts.SelectedIndex is int index)
        {
            var editWindow = new EditContactWindow(index, selectedContact, _logic);
            var parentWindow = TopLevel.GetTopLevel(this) as Window;

            if (parentWindow != null)
            {
                await editWindow.ShowDialog(parentWindow);
            }
        }
    }
}