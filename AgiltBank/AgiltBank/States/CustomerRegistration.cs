using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class CustomerRegistration : State
    {
        public CustomerRegistration(Context context) : base(context, "Namn?", "* Skapa kund *")
        {
            Customer = new AgiltBankLibrary.Models.Customer();
            while (Customer.Id < 1)
            {
                Customer.Id = Guid.NewGuid().GetHashCode();
            }

            AssignProperty = AssignName;

            Console.WriteLine(Header);
            Read();
        }

        public delegate void AssigningPropertyHandler(string propertyValue);

        public AgiltBankLibrary.Models.Customer Customer { get; set; }
        public AssigningPropertyHandler AssignProperty { get; set; }

        protected override void ProcessLine(string line)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                AssignProperty(line);
            }
            else
            {
                Read();
            }
        }

        private void AssignName(string name)
        {
            Customer.Name = name;
            AssignProperty = AssignOrganisationNumber;
            Prompt = "Organisationsnummer?";
            Read();
        }

        private void AssignOrganisationNumber(string organisationNumber)
        {
            Customer.OrganisationNumber = organisationNumber;
            AssignProperty = AssignStreetAddress;
            Prompt = "Gatuadress?";
            Read();
        }

        private void AssignStreetAddress(string streetAddress)
        {
            Customer.StreetAddress = streetAddress;
            AssignProperty = AssignCity;
            Prompt = "Stad?";
            Read();
        }

        private void AssignCity(string city)
        {
            Customer.City = city;
            AssignProperty = AssignState;
            Prompt = "Stat?";
            Read();
        }

        private void AssignState(string state)
        {
            Customer.State = state;
            AssignProperty = AssignPostalCode;
            Prompt = "Postkod?";
            Read();
        }

        private void AssignPostalCode(string postalCode)
        {
            Customer.PostalCode = postalCode;
            AssignProperty = AssignCountry;
            Prompt = "Land?";
            Read();
        }

        private void AssignCountry(string country)
        {
            Customer.Country = country;
            AssignProperty = AssignPhoneNumber;
            Prompt = "Telefonnummer?";
            Read();
        }

        private void AssignPhoneNumber(string phoneNumber)
        {
            Customer.PhoneNumber = phoneNumber;

            Context.BankData.AddCustomer(Customer);
            Console.WriteLine($"Kund skapad. Kundnumret är {Customer.Id}.");

            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadKey(true);
            Console.WriteLine();
            Context.State = new Home(Context);
        }
    }
}
