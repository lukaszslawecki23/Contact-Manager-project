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
}