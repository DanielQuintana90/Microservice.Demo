﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Microservices.Demo.Report.API.Infrastructure.Data.Entities
{
    public partial class PolicyStatus
    {
        public PolicyStatus()
        {
            Policy = new HashSet<Policy>();
        }

        public int PolicyStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Policy> Policy { get; set; }
    }
}