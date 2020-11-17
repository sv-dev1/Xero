
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using Xero.Api.Core;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Example.MVC.Helpers;

namespace Xero.Api.Example.MVC.Controllers
{
    public class OrganisationController : Controller
    {
        public ActionResult Index()
        {
            var api = XeroApiHelper.CoreApi();
            try
            {
                var organisation = api.Organisation;

                var accountList = api.Accounts;
                return View(organisation);
            }
            catch (RenewTokenException e)
            {
                return RedirectToAction("Connect", "Home");
            }
        }
        public IXeroCoreApi api = XeroApiHelper.CoreApi();
        public Guid ContactId
        {
            get
            {
                return api.Contacts.Find().First().Id;
            }
        }

        //Create Contact
        //localhost:61795/Organisation/CreateContact?Name=abc&FirstName=def&ContactNumber=8888999966&EmailAddress=test2222@gmafffil.com
        public ActionResult CreateContact(string Name, string FirstName, string LastName, string ContactNumber, string EmailAddress)
        {
            try
            {
                var contact = new Contact
                {
                    Name = Name,
                    FirstName = FirstName,
                    LastName = LastName,
                    ContactNumber = ContactNumber,
                    EmailAddress = EmailAddress
                };
                var submitteddata = api.Create(contact);
                return Json(submitteddata, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { }
            return Json(null);
        }
        //Create Invoice
        //localhost:61795/Organisation/CreateInvoice?ContactName=TestContactName&AccountCode=0252&Description=TestDescription&UnitAmount=111&Quantity=5
        public ActionResult CreateInvoice(string ContactName, string AccountCode, string Description, decimal UnitAmount, decimal Quantity)
        {
            try
            {
                var invoice = new Invoice
                {
                    Contact = new Contact { Name = ContactName },
                    Type = Core.Model.Types.InvoiceType.AccountsReceivable,
                    LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            AccountCode = AccountCode,
                            Description = Description,
                            UnitAmount = UnitAmount,
                            Quantity = Quantity
                        }
                    }
                };
                var submitteddata = api.Create(invoice);
                return Json(submitteddata, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { }
            return Json(null);
        }
        //Create PurchaseOrder
        //localhost:61795/Organisation/CreatePurchaseOrder?Description=TestDescription&UnitAmount=111&Quantity=5
        public ActionResult CreatePurchaseOrder(string Description, decimal UnitAmount, decimal Quantity)
        {
            try
            {
                var purchaseorder = new PurchaseOrder
                {
                    Status = Core.Model.Status.PurchaseOrderStatus.Authorised,
                    Date = DateTime.Today,
                    Contact = new Contact { Id = ContactId },
                    LineItems = new List<LineItem>()
                    {
                        new LineItem
                        {
                            Description = Description,
                            UnitAmount = UnitAmount,
                            Quantity = Quantity,
                        }
                    }
                };
                var submitteddata = api.Create(purchaseorder);
                return Json(submitteddata, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error Occured :\n" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
