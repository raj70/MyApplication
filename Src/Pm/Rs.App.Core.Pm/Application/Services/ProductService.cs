/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/21/2020 5:38:55 PM
*/
using Microsoft.Extensions.DependencyInjection;
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Domain;
using Rs.App.Core.Pm.Events;
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
    public class ProductService : IProductService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProductRepository _productRepository;
        private readonly IAuditRepository _auditRepository;
        private readonly IStockRepository _stockRepository;

        public ProductService(IServiceProvider serviceProvider, IProductRepository productRepository,
            IAuditRepository auditRepository,
            IStockRepository stockRepository)
        {
            _serviceProvider = serviceProvider;
            _productRepository = productRepository;
            _auditRepository = auditRepository;
            _stockRepository = stockRepository;
        }


        public async Task<Result> AddAsync(Dtos.ProductAddDto productDto)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();

                // add product
                var new_product = productDto.CreateProduct();
                var exist_Product_Spec = new ProductExistSpecification(new_product);
                var new_stock = productDto.CreateStock(new_product.Id);

                // is specification satisfied?
                var isStaisfy = exist_Product_Spec.IsSatisfiedBy(new_product);
                if (isStaisfy)
                {
                    var exist_product = _productRepository.Find(exist_Product_Spec).FirstOrDefault();
                    if (exist_product == null)
                    {
                        _productRepository.Add(new_product);
                        _productRepository.Complete();

                        var add_product_event = _serviceProvider.GetRequiredService<IDomainEvent<ProductAddDto>>();
                        add_product_event.Raise(new_product);
                    }
                    else
                    {
                        result.IsError = true;
                        result.Message = "Product exist already";
                        result.StatuCode = 400;
                    }
                }

                if (!result.IsError)
                {
                    // add stock
                    var stock_Spec = new StockExistSpecification(new_stock);
                    var exist_Stock = _stockRepository.Find(stock_Spec).FirstOrDefault();

                    // always statify ATM
                    var isSatisfy = stock_Spec.IsSatisfiedBy(new_stock);
                    if (isSatisfy)
                    {
                        if (exist_Stock == null)
                        {
                            _stockRepository.Add(new_stock);
                            _stockRepository.Complete();

                            var add_stock_event = _serviceProvider.GetRequiredService<IDomainEvent<StockAddDto>>();
                            add_stock_event.Raise(new_stock);
                        }
                        else
                        {
                            result.IsError = true;
                            result.Message = "Stock exist already";
                            result.StatuCode = 400;
                            return result;
                        }
                    }
                }

                return result;
            });

            return result;
        }

        public async Task<Result> RemoveAsync(ProductRemoveDto productDto)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();

                return result;
            });

            return result;
        }
    }
}

