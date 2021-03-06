﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Rs.App.Core.Mvc.Client.Sale.Areas.Crms.ViewModel;
using Rs.App.Core.Mvc.Client.Sale.Utilities;

namespace Rs.App.Core.Mvc.Client.Sale.Areas.Crms.Controllers
{
    [Area("Crms")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            IEnumerable<CustomerDetail> contacts = new List<CustomerDetail>();
            var apiClient = await HttpContext.CreateHttpAsync();
            var responseMessage = await apiClient.GetAsync(_configuration.CrmGetContacts());

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = responseMessage.Content.ReadAsStringAsync();
                contacts = JsonConvert.DeserializeObject<IEnumerable<CustomerDetail>>(values.Result);
            }
            return View(contacts);
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var c = new CustomerDetail();
            var apiClient = await HttpContext.CreateHttpAsync();
            var responseMessage = await apiClient.GetAsync(_configuration.CrmGetContact(id));

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = responseMessage.Content.ReadAsStringAsync();
                c = JsonConvert.DeserializeObject<CustomerDetail>(values.Result);
            }

            return View(c);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
    }
}