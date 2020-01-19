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
using Rs.App.Core.Crm.Application.ClientModel;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Exceptions;
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ITitleRepository _titleRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IAddressRepository _addressRepository;

        public ContactService(IContactRepository contactRepository,
            IAddressRepository addressRepository,
            ITitleRepository titleRepository,
            INoteRepository noteRepository)
        {
            _contactRepository = contactRepository;
            _titleRepository = titleRepository;
            _noteRepository = noteRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            var contact = await Task.Run(() =>
           {
               var contact = _contactRepository.Get(id);
               if (!contact.IsDeliverSameAsHomeAddress)
               {
                   contact.DeliveryAddress = GetDeliveryAddress(contact);
               }
               return _contactRepository.Get(id);
           });
            return contact;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var contacts = await Task.Run(() =>
            {
                var cs = _contactRepository.GetAll();
                return cs;
            });

            // TODO: need to think
            await Task.Run(() => contacts.ToList().ForEach(x => GetDeliveryAddress(x)));

            return contacts;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync(int pageIndex, int pageSize = 10)
        {
            var contacts = await Task.Run(() => _contactRepository.GetAll(pageIndex, pageSize));

            // TODO: need to think: how to include deliveryaddress from repository; so that I can remove this line
            await Task.Run(() => contacts.ToList().ForEach(x => GetDeliveryAddress(x)));

            // throw new Exception("Mate this is just a test");
            return contacts;
        }

        public async Task<Result> AddedAsync(ContactClient contactClient)
        {
            var result = new Result();
            await Task.Run(() =>
            {
                var existed_title = _titleRepository.Exist(new Title() { Name = contactClient.Title });

                var title = new Title()
                {
                    Name = contactClient.Name
                };

                Address new_address = contactClient.GetAddress();
                var existed_address = _addressRepository.Exist(new_address);

                Address new_deliveryAddress = contactClient.GetDeliveryAdress();
                Address existed_deliveryAddress = null;
                if (!contactClient.IsDeliverSameAsHomeAddress)
                {
                    existed_deliveryAddress = _addressRepository.Exist(new_deliveryAddress);
                    if (existed_deliveryAddress == null)
                    {
                        _addressRepository.Add(new_deliveryAddress);
                        _addressRepository.Complete();
                    }
                }

                var contact = contactClient.GetContact();
                contact.TitleId = existed_title == null ? title.Id : existed_title.Id;
                contact.Title = existed_title == null ? title : null;

                contact.HomeAddress = existed_address == null ? new_address : null; /* we don't want to add existed address again (fail) */
                contact.AddressId = existed_address == null ? new_address.Id : existed_address.Id;

                contact.DeliveryAddressId = contactClient.IsDeliverSameAsHomeAddress
                                            ? new_address.Id
                                            : (existed_deliveryAddress != null ? existed_deliveryAddress.Id : new_deliveryAddress.Id);


                var existed_contact = _contactRepository.Exist(contact);
                if (existed_contact == null)
                {
                    _contactRepository.Add(contact);
                }
                else
                {
                    result.Message = "Client exist, no new contact is created";
                    result.IsError = true;
                }
            });

            _contactRepository.Complete();

            return result;
        }

        /// <summary>
        /// return null if the Delivery Address same As Home Address
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        private Address GetDeliveryAddress(Contact contact)
        {
            Address delAddress = null;
            if (!contact.IsDeliverSameAsHomeAddress)
            {
                delAddress = _addressRepository.Get(contact.DeliveryAddressId);
            }
            return delAddress;
        }

        public async Task<Result> UpdateAsync(Guid id, ContactUpdate contact)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();
                var existed_contact = _contactRepository.Get(id);
                if (existed_contact == null)
                {
                    result.IsError = true;
                    result.Message = "Contact does not exist for give Id";
                    result.StatuCode = 400;
                }
                else
                {
                    var c = contact.GetContact();

                    var title = _titleRepository.Find(x => x.Name == contact.Title).FirstOrDefault();

                    if (title == null)
                    {
                        var titles = _titleRepository.GetAll();
                        result.Message = $"Provided title is not supported: Supported titles: {string.Join(", ", titles)}";
                        result.StatuCode = 400;                        
                    }
                    else
                    {
                        // c.Title = title;
                        c.TitleId = title.Id;
                        c.Id = id;
                        try
                        {
                            _contactRepository.Update(id, c);
                        }
                        catch(CrmException ex)
                        {
                            result.IsError = true;
                            result.Message = ex.Message;
                            result.StatuCode = 400;
                        }
                        catch(Exception)
                        {
                            throw;
                        }
                    }
                }

                return result;
            });

            return result;
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();

                var contact = _contactRepository.Get(id);
                if (contact == null)
                {
                    result.IsError = false;
                    result.Message = "Contact does not exist";
                    result.StatuCode = 400;
                }
                else
                {
                    //TODO: will be a issue when note is deleted
                    _contactRepository.Remove(id);
                    _contactRepository.Complete();
                }

                return result;
            });

            return result;
        }

    }
}
