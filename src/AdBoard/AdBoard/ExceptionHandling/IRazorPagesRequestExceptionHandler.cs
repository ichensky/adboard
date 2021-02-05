using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace AdBoard.ExceptionHandling
{
    public interface IRazorPagesRequestExceptionHandler
    {
        Task Execute<TResult>(ModelStateDictionary modelState, IRequest<TResult> request);
    }
}