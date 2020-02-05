
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs.App.Core.Pm.Infra.Domain;
/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/22/2020 4:00:54 PM
*/
namespace Rs.App.Core.Pm.Infra.Repository
{
    public class AuditContext: AbstractDataContext<AuditContext>
    {
        public AuditContext(IConfiguration configuration, DbContextOptions<AuditContext> options)
            : base(configuration, options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}