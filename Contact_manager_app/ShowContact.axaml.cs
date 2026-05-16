using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Contact_manager_app.Views;

public partial class WindowShowContact : UserControl
{
    public WindowShowContact(object sendContacts)
    {
        InitializeComponent();

        lstContacts.ItemsSource = (System.Collections.IEnumerable)sendContacts;
    }
}