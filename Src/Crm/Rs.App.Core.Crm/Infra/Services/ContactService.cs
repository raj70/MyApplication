/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/14/2020 6:39:17 PM
*/
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ITitleRepository _titleRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IAddressRepository _addressRepository;

        public ContactService(IContactRepository contactRepository,
            ITitleRepository titleRepository,
            INoteRepository noteRepository,
            IAddressRepository addressRepository)
        {
            _contactRepository = contactRepository;
            _titleRepository = titleRepository;
            _noteRepository = noteRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            var contact = await Task.Run(() => _contactRepository.Get(id));
            return contact;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var contacts = await Task.Run(() => {                
                    var cs =_contactRepository.GetAll();
                    return cs;
                });

            // TODO: need to think
            await Task.Run(() => contacts.ToList().ForEach(x => x.DeliveryAddress = _addressRepository.Get(x.DeliveryAddressId)));

            return contacts;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync(int pageIndex, int pageSize = 10)
        {
            var contacts = await Task.Run(() => _contactRepository.GetAll(pageIndex, pageSize));

            // TODO: need to think: how to include deliveryaddress from repository; so that I can remove this line
            await Task.Run(() => contacts.ToList().ForEach(x => x.DeliveryAddress = _addressRepository.Get(x.DeliveryAddressId)));

            // throw new Exception("Mate this is just a test");
            return contacts;
        }
    }
}
