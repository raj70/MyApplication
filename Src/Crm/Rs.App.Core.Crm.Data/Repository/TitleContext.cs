/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/13/2020 1:00:29 AM
*/

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
	public class TitleContext : AbstractDataContext<TitleContext>
	{
		public TitleContext(IConfiguration configuration, DbContextOptions<TitleContext> options)
			: base(configuration, options)
		{
		}

		public virtual DbSet<Title> Titles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration<Title>(new TitleEntityConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}

