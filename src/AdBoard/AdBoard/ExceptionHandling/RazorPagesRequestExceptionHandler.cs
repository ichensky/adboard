using Application.Configuration.Commands;
using Application.Configuration.Queries;
using Application.Configuration.Validation;
using Application.UserProfiles.UpdateUserProfileContactInformation;
using Domain.Core.BusinessRules;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdBoard.ExceptionHandling
{
    public class RazorPagesRequestExceptionHandler : IRazorPagesRequestExceptionHandler
    {
        private readonly IMediator mediator;

        public RazorPagesRequestExceptionHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task Execute<TResult>(ModelStateDictionary modelState, IRequest<TResult> request)
        {
            try
            {
                await mediator.Send(request);
            }
            catch (BusinessRuleValidationException ex)
            {
                modelState.AddModelError(string.Empty, ex.Message);
            }
            catch (InvalidCommandException ex)
            {
                modelState.AddModelError(string.Empty, "Invalid input data.");
            }
            catch (Exception ex)
            {
                modelState.AddModelError(string.Empty, "Please, contact admin.");
            }
        }
    }
}
