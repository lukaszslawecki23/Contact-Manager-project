using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Contact_manager_app
{
    public class Logic
    {
        private string _fileName = "contact_data.json";

        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();

        public ObservableCollection<Contact> GetContacts()
        {
            return _contacts;
        }

        public (bool IsSuccess, List<string> Errors) AddContact(Contact newContact)
        {
            ValidationContext context = new ValidationContext(newContact);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(newContact, context, results, true);

            if (isValid)
            {
                _contacts.Add(newContact);
                SaveToFile();
                return (true, new List<string>());
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (ValidationResult error in results)
                {
                    errors.Add(error.ErrorMessage);
                }
                return (false, errors);
            }
        }

        public void DeleteContact(int index)
        {
            if (index >= 0 && index < _contacts.Count)
            {
                _contacts.RemoveAt(index);
                SaveToFile();
            }
        }

        public (bool IsSuccess, List<string> Errors) EditContact(int index, Contact updatedContact)
        {
            ValidationContext context = new ValidationContext(updatedContact);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(updatedContact, context, results, true);

            if (isValid && index >= 0 && index < _contacts.Count)
            {
                _contacts[index] = updatedContact;
                SaveToFile();
                return (true, new List<string>());
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (ValidationResult error in results)
                {
                    errors.Add(error.ErrorMessage);
                }
                return (false, errors);
            }
        }

        private void SaveToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string convertedString = JsonSerializer.Serialize(_contacts, options);
            File.WriteAllText(_fileName, convertedString);
        }

        public void LoadFromFile()
        {
            if (File.Exists(_fileName))
            {
                string jsonString = File.ReadAllText(_fileName);
                var loadedContacts = JsonSerializer.Deserialize<ObservableCollection<Contact>>(jsonString) ?? new ObservableCollection<Contact>();

                if (loadedContacts != null)
                {
                    _contacts.Clear();
                    foreach (var contact in loadedContacts)
                    {
                        _contacts.Add(contact);
                    }
                }
            }
        }
    }
}