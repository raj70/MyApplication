/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/16/2020 3:29:11 PM
* 
* [%clrversion%]
*/
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> AllNotUsed()
        {
            var addresses = await Task.Run(() => _addressRepository.AllNotUsed());
            return addresses;
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var result = await Task.Run(() => {
                var result = new Result();

                var addresses = _addressRepository.AllNotUsed();
                var existed_NotUsed_address = addresses.Where(x => x.Id == id).FirstOrDefault();
                if (existed_NotUsed_address == null)
                {
                    result.IsError = true;
                    result.Message = "Not able to delete the address, make sure the address is not used";
                    result.StatuCode = 400;
                }
                else
                {
                    _addressRepository.Remove(id);
                    _addressRepository.Complete();
                }

                return result;
            });

            return result;
        }

        public async Task<Address> GetAddress(Guid id)
        {
            var address = await Task.Run(() => _addressRepository.Get(id));

            return address;
        }
    }
}
