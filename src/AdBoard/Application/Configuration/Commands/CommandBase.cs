﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration.Commands
{
    public class CommandBase : ICommand
    {
        public Guid Id { get; }

        public CommandBase()
        {
            this.Id = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            this.Id = id;
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        /// <summary>
        /// Command Id
        /// </summary>
        public Guid Id { get; }

        protected CommandBase()
        {
            this.Id = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            this.Id = id;
        }
    }
}
