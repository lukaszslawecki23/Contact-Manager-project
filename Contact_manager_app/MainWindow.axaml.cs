using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Contact_manager_app.Views;

namespace Contact_manager_app.Views;

public partial class MainWindow : Window
{
    private Logic _logic = new Logic();
    private ObservableCollection<Contact> contacts;
    
    public MainWindow()
    {
        InitializeComponent();
        
        _logic.LoadFromFile();
    }

    private void ButtonnAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        AddingContactSpace.Content = new WindowAddContact(_logic);
    }
    
    private void ButtonnShow_OnClick(object? sender, RoutedEventArgs e)
    {
        contacts = _logic.GetContacts();
        Console.WriteLine(contacts.Count);
        AddingContactSpace.Content = new WindowShowContact(contacts, _logic);
    }
}