using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Contact_manager_app.Views;

public partial class EditContactWindow : Window
{
    private Logic _logic;
    private int _index;
    private Contact _chosenContact;
    
    public EditContactWindow(int index, Contact chosenContact, Logic sharedLogic)
    {
        InitializeComponent();

        this.DataContext = chosenContact;

        _logic = sharedLogic;
        _index = index;
        _chosenContact = chosenContact;
    }

    private void EditContactButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Contact updatedContact = new Contact()
        {
            FirstName = string.IsNullOrWhiteSpace(txtFirstName.Text) ? _chosenContact.FirstName : txtFirstName.Text,
            LastName = string.IsNullOrWhiteSpace(txtLasttName.Text) ? _chosenContact.LastName : txtLasttName.Text,
            PhoneNumber = string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? _chosenContact.PhoneNumber : txtPhoneNumber.Text,
            EmailAddress = string.IsNullOrWhiteSpace(txtEmailAddress.Text) ? _chosenContact.EmailAddress : txtEmailAddress.Text,
            HomeAddress = string.IsNullOrWhiteSpace(txtHomeAddress.Text) ? _chosenContact.HomeAddress : txtHomeAddress.Text,
            OptionalNote = string.IsNullOrWhiteSpace(txtOptionalNote.Text) ? _chosenContact.OptionalNote : txtOptionalNote.Text
        };

        _logic.EditContact(_index, updatedContact);
        
        this.Close();
    }
}