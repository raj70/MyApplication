using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Rs.App.Core.Mvc.Client.Sale.Areas.Crms.ViewModel;
using Rs.App.Core.Mvc.Client.Sale.Utilities;

namespace Rs.App.Core.Mvc.Client.Sale.Areas.Crms.Controllers
{
    public class AddressController : Controller
    {
        private readonly IConfiguration _configuration;

        public AddressController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        

        // GET: Address/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var address = new Address();
            var apiClient = await HttpContext.CreateHttpAsync();
            var responseMessage = await apiClient.GetAsync(_configuration.CrmAddress(id));

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = responseMessage.Content.ReadAsStringAsync();
                address = JsonConvert.DeserializeObject<Address>(values.Result);
            }
            else
            {
                //Todo: fix this
                return BadRequest("Error has encountered");
            }
            return PartialView("/Areas/Crms/Views/Shared/_Address.cshtml", address);
        }

        /*
        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Address/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}