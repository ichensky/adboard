using Application.Configuration.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InvalidCommandException).Assembly;
    }
}
