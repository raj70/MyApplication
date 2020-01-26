/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/26/2020 8:12:09 PM
*/
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Domain;
using Rs.App.Core.Pm.Exceptions;
using Rs.App.Core.Pm.Infra.Domain;
using Rs.App.Core.Pm.Infra.Repository;
using Rs.App.Core.Pm.Spec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Stock> GetStockAsync(Guid productId)
        {
            var stock = await Task.Run(() => {
                return GetStock(productId);
            });

            return stock;
        }

        public Stock GetStock(Guid productId)
        {
            var stockSpecification = StockExistSpecification.Create(productId);
            var stock = _stockRepository.Find(stockSpecification).FirstOrDefault();

            return stock;
        }

        public async Task<Result> UpdateAsync(Guid id, StockUpdateDto stockReduce)
        {
            var result = await Task.Run(() => {
                var result = new Result();

                var existStock = _stockRepository.Get(id);
                if(existStock != null)
                {
                    try
                    {
                        existStock = stockReduce.Update(existStock);
                        _stockRepository.Update(id, existStock);
                    }
                    catch(PmException ex)
                    {
                        result.IsError = true;
                        result.Message = ex.Message;
                        result.StatuCode = 500;
                    }
                }
                else
                {
                    result.IsError = true;
                    result.Message = "Stock does not exist for give Id";
                    result.StatuCode = 400;
                }

                return result;
            });

            return result;
        }
    }
}

