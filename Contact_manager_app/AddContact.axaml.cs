using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Contact_manager_app.Views;

public partial class WindowAddContact : UserControl
{
    private Logic _logic;
    
    public WindowAddContact(Logic sharedLogic)
    {
        InitializeComponent();

        _logic = sharedLogic;
    }

    private void ButtonSave_OnClick(object? sender, RoutedEventArgs e)
    {

        Contact _contact = new Contact()
        {
            FirstName = txtFirstName.Text ?? string.Empty,
            LastName = txtLasttName.Text ?? string.Empty,
            PhoneNumber = txtPhoneNumber.Text ?? string.Empty,
            EmailAddress = txtEmailAddress.Text ?? string.Empty,
            HomeAddress = txtHomeAddress.Text ?? string.Empty,
            OptionalNote = txtOptionalNote.Text ?? string.Empty
        };
        
        var result = _logic.AddContact(_contact);

        if (result.IsSuccess)
        {
            txtFirstName.Text = string.Empty;
            txtLasttName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtHomeAddress.Text = string.Empty;
            txtOptionalNote.Text = string.Empty;
        }
        else
        {
            string allErrors = string.Join("\n", result.Errors);
        
            Console.WriteLine("Errors:\n" + allErrors);
        }
    }
}
