using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Application.Services;

namespace Rs.App.Core.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet("{id}", Name = "GetTitle")]
        public async Task<Title> Get(Guid id)
        {
            var title = await _titleService.GetAsync(id);

            return title;
        }

        [HttpGet(Name = "GetTitles")]
        public async Task<IEnumerable<Title>> GetAll()
        {
            var titles = await _titleService.GetAllAsync();

            return titles;
        }
    }
}