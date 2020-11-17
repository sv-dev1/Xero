using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xero.Api.Example.MVC.Helpers
{
    public class JSONHelper
    {
    }
    public class Rootobject
    {
        public string ID { get; set; }
        public bool iSError { get; set; }
        public Saveddata SavedData { get; set; }
    }

    public class Saveddata
    {
        public string InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public Contact1 Contact { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public int LineAmountTypes { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public float SubTotal { get; set; }
        public float TotalTax { get; set; }
        public float Total { get; set; }
        public string CurrencyCode { get; set; }
        public float CurrencyRate { get; set; }
        public float AmountDue { get; set; }
        public float AmountPaid { get; set; }
        public string Reference { get; set; }
        public Lineitem[] LineItems { get; set; }
        public bool SentToContact { get; set; }
        public object[] Prepayments { get; set; }
        public object[] Overpayments { get; set; }
        public DateTime UpdatedDateUTC { get; set; }
        public object[] Warnings { get; set; }
    }

    public class Contact1
    {
        public string ContactID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string BankAccountDetails { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCustomer { get; set; }
        public object[] SalesTrackingCategories { get; set; }
        public object[] PurchasesTrackingCategories { get; set; }
        public object[] ContactPersons { get; set; }
        public Address[] Addresses { get; set; }
        public Phone[] Phones { get; set; }
        public object[] ContactGroups { get; set; }
        public DateTime UpdatedDateUTC { get; set; }
    }

    public class Address
    {
        public int AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class Phone
    {
        public int PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneAreaCode { get; set; }
        public string PhoneCountryCode { get; set; }
    }

    public class Lineitem
    {
        public string Description { get; set; }
        public float Quantity { get; set; }
        public float UnitAmount { get; set; }
        public string TaxType { get; set; }
        public float TaxAmount { get; set; }
        public float LineAmount { get; set; }
        public object[] Tracking { get; set; }
        public string LineItemID { get; set; }
        public object[] ValidationErrors { get; set; }
    }

}