﻿/** 
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
        private readonly IStockRepository _stockRepository;

        public ProductService(IServiceProvider serviceProvider,
            IProductRepository productRepository,
            IStockRepository stockRepository)
        {
            _serviceProvider = serviceProvider;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
        }

        public async Task<Result> AddAsync(Dtos.ProductAddDto productDto)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();

                // add product
                var new_product = productDto.CreateProduct();
                var new_stock = productDto.CreateStock(new_product.Id);
                var exist_Product_Spec = new ProductSameExistSpecification(new_product);

                // is specification satisfied?
                var isStaisfy = exist_Product_Spec.IsSatisfiedBy(new_product);
                if (isStaisfy)
                {
                    var exist_product = _productRepository.Find(exist_Product_Spec).FirstOrDefault();
                    if (exist_product == null)
                    {
                        _productRepository.Add(new_product);
                        _productRepository.Complete();

                        var add_product_event = AbstractDomainEvent<ProductAddDto>.Create(_serviceProvider);
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

                            var add_stock_event = AbstractDomainEvent<StockAddDto>.Create(_serviceProvider);
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

        public async Task<Result> DeleteAsync(ProductRemoveDto removeDto)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();

                var exist_product = _productRepository.Get(removeDto.ProductId);
                if (exist_product != null)
                {
                    var stockSpec = StockExistSpecification.Create(removeDto.ProductId);
                    var exist_stock = _stockRepository.Find(stockSpec).FirstOrDefault();

                    if (exist_stock != null)
                    {
                        _stockRepository.Remove(exist_stock.Id);
                        _stockRepository.Complete();

                        var stockRemovedEvent = AbstractDomainEvent<StockRemoveDto>.Create(_serviceProvider);
                        stockRemovedEvent.Raise(exist_stock);

                        _productRepository.Remove(removeDto.ProductId);
                        _productRepository.Complete();

                        var prodRemovedEvent = AbstractDomainEvent<ProductRemoveDto>.Create(_serviceProvider);
                        prodRemovedEvent.Raise(exist_product);
                    }
                    else
                    {
                        result.IsError = true;
                        result.Message = "Stock not found";
                        result.StatuCode = 400;
                    }
                }
                else
                {
                    result.IsError = true;
                    result.Message = "Product not found";
                    result.StatuCode = 400;
                }
                return result;
            });

            return result;
        }

        public async Task<Product> GetAsync(Guid productId)
        {
            var product = await Task.Run(() =>
            {
                var product = _productRepository.Get(productId);
                return product;
            });

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await Task.Run(() =>
            {
                var products = _productRepository.GetAll();

                return products;
            });

            return products;
        }

        public async Task<Result> RemoveAsync(ProductRemoveDto productDto)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();
                var stock_Spec = new StockExistSpecification(productDto.CreateStock(productDto.ProductId));
                var exist_stock = _stockRepository.Find(stock_Spec).FirstOrDefault();

                if (exist_stock != null)
                {
                    _stockRepository.Remove(exist_stock.Id);
                    _stockRepository.Complete();

                    var exist_Product_Spec = new ProductExistSpecification(productDto.ProductId);
                    var exist_Product = _productRepository.Find(exist_Product_Spec);

                    if (exist_Product != null)
                    {
                        _productRepository.Remove(productDto.ProductId);
                        _productRepository.Complete();
                    }
                    else
                    {
                        result.IsError = true;
                        result.Message = "Product does not exist";
                        result.StatuCode = 400;
                    }
                }
                else
                {
                    result.IsError = true;
                    result.Message = "Product does not exist";
                    result.StatuCode = 400;
                }



                return result;
            });

            return result;
        }
    }
}

