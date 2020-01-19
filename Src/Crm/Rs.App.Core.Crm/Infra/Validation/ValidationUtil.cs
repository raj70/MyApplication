/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/16/2020 4:20:49 PM
*/
using Rs.App.Core.Crm.Application.ClientModel;
using System.Text.RegularExpressions;

namespace Rs.App.Core.Crm.Infra.Validation
{
    public static class ValidationUtil
    {
        public static bool IsSameAddress(ContactClient contact, string v)
        {
            return contact.IsDeliverSameAsHomeAddress;
        }

        public static bool IsCheckLength(ContactUpdate contact, string number)
        {
            // not empty
            var mpn = !string.IsNullOrWhiteSpace(contact.MobileNumber);
            var pn = !string.IsNullOrWhiteSpace(contact.PhoneNumber);

            // if phone number or mobile number is not empty
            var isOk = OnePhoneNumberIsRequired(contact, number);
            if (isOk && mpn)
            {
                isOk = contact.MobileNumber.Length >= 7 && contact.MobileNumber.Length <= 16;
            }

            if (isOk && pn)
            {
                isOk = contact.PhoneNumber.Length >= 7 && contact.PhoneNumber.Length <= 16;
            }

            return isOk;
        }

        public static bool OnePhoneNumberIsRequired(ContactUpdate contact, string number)
        {
            var mpn = contact.MobileNumber;
            var pn = contact.PhoneNumber;

            var isEmpty = !string.IsNullOrWhiteSpace(mpn);

            if (!isEmpty)
            {
                isEmpty = !string.IsNullOrWhiteSpace(pn);
            }

            return !string.IsNullOrWhiteSpace(mpn) || !string.IsNullOrWhiteSpace(pn);
        }

        public static bool IsValidNumber(ContactUpdate instance, string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return true;
            }

            var pn = number.Trim().Replace(" ", "").Replace("-", "");
            long nu;
            return long.TryParse(pn, out nu);
        }

        public static bool IsValidEmailAddress(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
        }
    }
}

