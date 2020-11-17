using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Xero.Api.Core;
using Xero.Api.Core.Model;
using Xero.Api.Example.MVC.Helpers;

namespace Xero.Api.Example.MVC.Controllers
{
    [EnableCors("*", "*", "*")]
    public class XeroApiController : ApiController
    {
        public IXeroCoreApi api = XeroApiHelper.CoreApi();
        // GET api/XeroApi
        #region GET
        public IEnumerable<Account> GetAccounts(string id = null)
        {
            if (string.IsNullOrEmpty(id))
                return api.Accounts.Find();
            else
                return api.Accounts.Find().Where(a => a.Id.ToString() == id);
        }
        public IEnumerable<Contact> GetContacts(string id = null)
        {
            if (string.IsNullOrEmpty(id))
                return api.Contacts.Find();
            else
                return api.Contacts.Find().Where(a => a.Id.ToString() == id);
        }
        public IEnumerable<Invoice> GetInvoices(string id = null)
        {
            if (string.IsNullOrEmpty(id))
                return api.Invoices.Find();
            else
                return api.Invoices.Find().Where(a => a.Id.ToString() == id);
        }
        public IEnumerable<PurchaseOrder> GetPurchaseOrders(string id = null)
        {
            if (string.IsNullOrEmpty(id))
                return api.PurchaseOrders.Find();
            else
                return api.PurchaseOrders.Find().Where(a => a.Id.ToString() == id);
        }
        #endregion GET

        #region POST
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateContact(Contact contact)
        {
            try
            {
                var saveddata = contact.Id == Guid.Empty ? api.Create(contact) : api.Update(contact);

                return Request.CreateResponse(HttpStatusCode.Created, new { ID = saveddata.Id, iSError = false, SavedData = saveddata });
            }
            catch (Exception ex) { return Request.CreateResponse(new { ID = ex.Message, iSError = true }); }
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreatePurchaseOrder(PurchaseOrder purchaseorder)
        {
            try
            {
                var saveddata = purchaseorder.Id == Guid.Empty ? api.Create(purchaseorder) : api.Update(purchaseorder);
                return Request.CreateResponse(HttpStatusCode.Created, new { ID = saveddata.Id, iSError = false, SavedData = saveddata });
            }
            catch (Exception ex) { return Request.CreateResponse(new { ID = ex.Message, iSError = true }); }
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateInvoice(Invoice invoice)
        {
            try
            {
                var saveddata = api.Create(invoice);
                return Request.CreateResponse(HttpStatusCode.Created, new { ID = saveddata.Id, iSError = false, SavedData = saveddata });
            }
            catch (Exception ex) { return Request.CreateResponse(new { ID = ex.Message, iSError = true }); }
        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateAccount(Account account)
        {
            try
            {
                var saveddata = api.Create(account);
                return Request.CreateResponse(HttpStatusCode.Created, new { ID = saveddata.Id, iSError = false, SavedData = saveddata });
            }
            catch (Exception ex) { return Request.CreateResponse(new { ID = ex.Message, iSError = true }); }
        }
        #endregion POST
    }
}