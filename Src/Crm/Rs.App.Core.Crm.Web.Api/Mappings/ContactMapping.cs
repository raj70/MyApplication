using AutoMapper;
using Rs.App.Core.Crm.Application.ClientModel;
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Web.Api.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            
            CreateMap<Contact, ContactDetail>();
            // CreateMap<IEnumerable<Contact>, IEnumerable<ContactDetail>>(); // bad line throw exception from AutoMapper
        }
    }
}
