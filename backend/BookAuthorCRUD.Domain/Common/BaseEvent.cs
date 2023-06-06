using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Common
{
    public abstract class BaseEvent<T> : INotification where T : class
    {
        public T Entity { get; } = default!;
        public BaseEvent(T entity)
        {
            Entity = entity;
        }

    }
}
