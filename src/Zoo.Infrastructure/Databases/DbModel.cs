using System;
using System.Collections.Generic;

namespace Zoo.Infrastructure.Databases
{
    internal abstract class DbModel
    {
        public virtual Guid Id { get; set; }
    }
}