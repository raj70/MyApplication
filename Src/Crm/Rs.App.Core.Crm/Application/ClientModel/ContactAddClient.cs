/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/16/2020 3:00:59 PM
*/
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Application.ClientModel
{
    public sealed class ContactAddClient : ClientModel.ContactUpdate
    {
        public ContactAddClient()
        {

        }
        public string HomeLine1 { get; set; } = string.Empty;
        public string HomeLine2 { get; set; } = string.Empty;
        public string HomeLine3 { get; set; } = string.Empty;
        public string HomeCity { get; set; } = string.Empty;
        public string HomeState { get; set; } = string.Empty;
        public string HomeCountry { get; set; } = string.Empty;
        public string HomePostalCode { get; set; } = string.Empty;
        public bool IsDeliverSameAsHomeAddress { get; set; }
        public string DeliveryLine1 { get; set; } = string.Empty;
        public string DeliveryLine2 { get; set; } = string.Empty;
        public string DeliveryLine3 { get; set; } = string.Empty;
        public string DeliveryCity { get; set; } = string.Empty;
        public string DeliveryState { get; set; } = string.Empty;
        public string DeliveryCountry { get; set; } = string.Empty;
        public string DeliveryPostalCode { get; set; } = string.Empty;

        public Address GetDeliveryAdress()
        {
            return new Address()
            {
                City = DeliveryCity,
                Country = DeliveryCountry,
                Line1 = DeliveryLine1,
                Line2 = DeliveryLine2,
                Line3 = DeliveryLine3,
                PostalCode = DeliveryPostalCode,
                State = DeliveryState
            };
        }

        public Address GetAddress()
        {
            return new Address
            {
                City = HomeCity,
                Country = HomeCountry,
                Line1 = HomeLine1,
                Line2 = HomeLine2,
                Line3 = HomeLine3,
                PostalCode = HomePostalCode,
                State = HomeState
            };
        }       
    }
}

