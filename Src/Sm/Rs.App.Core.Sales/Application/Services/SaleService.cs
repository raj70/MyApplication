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
using Microsoft.Extensions.DependencyInjection;
using Rs.App.Core.Sales.Application.Dtos;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Events;
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
        private readonly IServiceProvider _serviceProvider;
        private readonly ISaleRepository _saleRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalePersonRepository _salePersonRepository;

        public SaleService(IServiceProvider serviceProvider
            , ISaleRepository repository
            , IOrderProductRepository orderProductRepository
            , IOrderRepository orderRepository
            , ICustomerRepository customerRepository
            , IProductRepository productRepository
            , ISalePersonRepository salePersonRepository)
        {
            _serviceProvider = serviceProvider;
            _saleRepository = repository;
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _salePersonRepository = salePersonRepository;
        }

        public async Task<Result> AddAsync(SaleAddDto dto)
        {
            var result = new Result();

            var newSale = await GetAsync(dto);
            if (newSale == null)
            {
                // customer
                var exist_customer = await _customerRepository.FindAsync(x => x.ContactId == dto.CustomerId);
                if (exist_customer == null)
                {
                    await _customerRepository.AddAsync(dto.Customer());
                    await _customerRepository.CompleteAsync();
                }

                // sale-person
                var exist_person = await _salePersonRepository.FindAsync(x => x.ContactId == dto.SalePersonId);
                if (exist_person == null)
                {
                    await _salePersonRepository.AddAsync(dto.SalePerson());
                    await _salePersonRepository.CompleteAsync();
                }

                // sale
                var createSale = await _saleRepository.AddAsync(newSale);
                await _saleRepository.CompleteAsync();

                // sale event
                var sale_added_event = AbstractDomainEvent<SaleAddDto>.Create(_serviceProvider);
                await sale_added_event.RaiseAsync(createSale);

                // order
                var order = new Order()
                {
                    SaleId = createSale.Id
                };
                var createdOrder = await _orderRepository.AddAsync(order);
                await _orderRepository.CompleteAsync();

                //sale event
                var orderAddedEvent = AbstractDomainEvent<OrderAddDto>.Create(_serviceProvider);
                await orderAddedEvent.RaiseAsync(createdOrder);

                // product
                dto.ProductIds.ForEach(async p =>
                {
                    var existproduct = await _productRepository.FindAsync(x => x.ProductId == p);
                    if (existproduct == null)
                    {
                        await _productRepository.AddAsync(dto.Product(p));
                    }

                    // order-product
                    var orderProduct = dto.CreateOrderProduct(createdOrder.Id, p);
                    var createOrderProduct = await _orderProductRepository.AddAsync(orderProduct);
                });

                await _productRepository.CompleteAsync();
                await _orderProductRepository.CompleteAsync();

                result.Value = newSale.ToString();
            }
            else
            {
                result.IsError = true;
                result.Message = "Sale does exist";
                result.StatuCode = 400;
            }

            return result;
        }

        public async Task<IEnumerable<Sale>> GetAllSaleAsync(bool isActive = true)
        {
            var sales = await _saleRepository.FindAsync(x => x.IsActive == isActive);
            return sales;
        }

        public async Task<Sale> GetSaleAsync(Guid id)
        {
            var sale = await _saleRepository.GetAsync(id);
            return sale;
        }

        public async Task<Result> UpdateSale(SaleUpdateDto saleUpdateDto)
        {
            var result = new Result();
            var existedSales = await _saleRepository.FindAsync(x => x.Id == saleUpdateDto.SaleId);

            var existedSale = existedSales.FirstOrDefault();
            if (existedSale != null)
            {
                existedSale.UpdateDate = saleUpdateDto.UpdateDate;
                existedSale.TotalCost = saleUpdateDto.TotalCost ?? existedSale.TotalCost;
                existedSale.IsActive = saleUpdateDto.IsActive;
                // udpate
                await _saleRepository.UpdateAsync(saleUpdateDto.SaleId, existedSale);
                await _saleRepository.CompleteAsync();
                // event
                await SaleUdpateEvent(existedSale);
            }
            else
            {
                result.IsError = true;
                result.Message = "Sale does not exist";
                result.StatuCode = 400;
            }

            return result;
        }

        public async Task<Result> ChangeActiveAsync(Guid id)
        {
            var result = new Result();
            var exist_sale = await _saleRepository.GetAsync(id);

            if (exist_sale == null)
            {
                result.IsError = true;
                result.Message = "Sale dose not exist";
                result.StatuCode = 400;
            }
            else
            {
                exist_sale.IsActive = !exist_sale.IsActive;
                exist_sale.UpdateDate = DateTime.UtcNow;
                // update
                await _saleRepository.UpdateAsync(id, exist_sale);
                await _salePersonRepository.CompleteAsync();
                result.Value = exist_sale;
                // event
                await SaleUdpateEvent(exist_sale);
            }

            return result;
        }

        private async Task SaleUdpateEvent(Sale exist_sale)
        {
            var saleUpdateEvent = AbstractDomainEvent<SaleUpdateDto>.Create(_serviceProvider);
            await saleUpdateEvent.RaiseAsync(exist_sale);
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

