using MediatR;
using Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing.Commands.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing.Commands
{
    public class CalculatePriceCommand 
    {
        public string ProductCode { get; set; }
        public DateTimeOffset PolicyFrom { get; set; }
        public DateTimeOffset PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<QuestionAnswer> Answers { get; set; }
    }
}
