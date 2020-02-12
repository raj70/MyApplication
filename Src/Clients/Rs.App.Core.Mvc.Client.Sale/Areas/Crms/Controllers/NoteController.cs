using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Rs.App.Core.Mvc.Client.Sale.Areas.Crms.ViewModel;
using Rs.App.Core.Mvc.Client.Sale.Utilities;

namespace Rs.App.Core.Mvc.Client.Sale.Areas.Crms.Controllers
{
    public class NoteController : Controller
    {
        private readonly IConfiguration _configuration;
        public NoteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> GetAll(Guid customerId)
        {
            IEnumerable<Note> notes = new List<Note>();
            var apiClient = await HttpContext.CreateHttpAsync();
            var responseMessage = await apiClient.GetAsync(_configuration.CrmNotes(customerId));

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = responseMessage.Content.ReadAsStringAsync();
                notes = JsonConvert.DeserializeObject<IEnumerable<Note>>(values.Result);
            }
            else
            {
                //Todo: fix this
                return BadRequest("Error has encountered");
            }
            return PartialView("/Areas/Crms/Views/Shared/_Notes.cshtml", notes);
        }
    }
}