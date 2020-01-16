/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/16/2020 6:59:31 AM
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
    public class TitleService : ITitleService
    {
        private ITitleRepository _titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            var titles = await Task.Run(() => _titleRepository.GetAll());

            return titles;
        }

        public async Task<Title> GetAsync(Guid id)
        {
            var title = await Task.Run(() => _titleRepository.Get(id));

            return title;
        }
    }
}

