/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 6:53:28 PM
*/
using Rs.App.Core.Sales.Application.Dtos;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Domain;
using Rs.App.Core.Sales.Infra.Exceptions;
using Rs.App.Core.Sales.Infra.Repository;
using Rs.App.Core.Sales.Spec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Application.Services
{

    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalePersonRepository _salePersonRepository;

        public SaleService(ISaleRepository repository
            , IOrderProductRepository orderProductRepository
            , IOrderRepository orderRepository
            , ICustomerRepository customerRepository
            , IProductRepository productRepository
            , ISalePersonRepository salePersonRepository)
        {
            _saleRepository = repository;
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _salePersonRepository = salePersonRepository;
        }

        public async Task<Sale> GetSaleAsync(Guid id)
        {
            var sale = await _saleRepository.GetAsync(id);
            return sale;
        }

        public async Task<Result> UpdateAsync(Guid id, SaleAddDto dto)
        {
            var result = new Result();

            var existed_Sale = await _saleRepository.GetAsync(id);
            if (existed_Sale != null)
            {
                try
                {
                    //var sale = dto.Create();
                    //_repository.Update(sale);
                }
                catch (GeneralException ex)
                {
                    result.IsError = true;
                    result.Message = ex.Message;
                    result.StatuCode = 500;
                }
            }
            else
            {
                result.IsError = true;
                result.Message = "Sale does not exist for give Id";
                result.StatuCode = 400;
            }

            return result;

        }

        public async Task<Result> AddAsync(SaleAddDto dto)
        {
            var result = new Result();

            var newSale = await GetAsync(dto);
            if (newSale == null)
            {
                //customer
                var exist_customer = await _customerRepository.FindAsync(x => x.ContactId == dto.CustomerId);
                if (exist_customer == null)
                {
                    await _customerRepository.AddAsync(dto.Customer());
                }
                // saleperson
                var exist_person = await _salePersonRepository.FindAsync(x => x.ContactId == dto.SalePersonId);
                if(exist_person == null)
                {
                    await _salePersonRepository.AddAsync(dto.SalePerson());
                }
                //product
                var exist_product = await _productRepository.FindAsync(x => x.ProductId == dto.ProductId);
                if(exist_product == null)
                {
                    await _productRepository.AddAsync(dto.Product());
                }

                //sale
                var createSale = await _saleRepository.AddAsync(newSale);
                await _saleRepository.CompleteAsync();

                var order = new Order()
                {
                    SaleId = createSale.Id
                };

                var createdOrder = await _orderRepository.AddAsync(order);
                await _orderRepository.CompleteAsync();

                var orderProduct = dto.CreateOrderProduct(createdOrder.Id);
                var createOrderProduct = await _orderProductRepository.AddAsync(orderProduct);
                await _orderProductRepository.CompleteAsync();
            }
            else
            {
                result.IsError = true;
                result.Message = "Sale does exist";
                result.StatuCode = 400;
            }

            return result;
        }


        private async Task<Sale> GetAsync(SaleAddDto dto)
        {
            var newSale = dto.Create();

            var exist_Spec = SaleExistSpecification.Create(newSale);
            var exist_Sales = await _saleRepository.FindAsync(exist_Spec.ToExpression());
            var exist_Sale = exist_Sales.FirstOrDefault();

            return exist_Sale;
        }
    }
}

