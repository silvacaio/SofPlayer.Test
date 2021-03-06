﻿using SoftPlayer.Domain.Interest.Commands;
using SoftPlayer.Domain.Interest.Handlers;
using SoftPlayer.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlayer.Application.Handlers.Interest
{
    public class CalculateInterestCommandHandler :
      ICalculateInterestRateHandler
    {
        private readonly IGetInterestRateCommandHandler _getInterestRateHandler;

        public CalculateInterestCommandHandler(IGetInterestRateCommandHandler getInterestRateHandler)
        {
            _getInterestRateHandler = getInterestRateHandler;
        }

        public async Task<Event<decimal>> Handler(CalculateInterestCommand command)
        {
            if (!command.IsValid())
                return Event<decimal>.CreateError("Valores inválidos.");

            var interestRate = await _getInterestRateHandler.Handler(GetInterestRateCommand.GetInterestRateCommandFactory.Create(command.UrlInterestRate));
            if (!interestRate.Valid)
                return Event<decimal>.CreateError(interestRate.Error);

            var interest = (decimal)Math.Pow((double)(1 + interestRate.Value), command.Time);
            var result = command.Value * interest;
            result = Math.Truncate(result * 100) / 100; //trunc            

            return Event<decimal>.CreateSuccess(result);
        }
    }
}
