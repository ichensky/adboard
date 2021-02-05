using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdBoard.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {

        public CustomExceptionFilter()
        {
        }

        public void OnException(ExceptionContext context)
        {
        }
    }
}
