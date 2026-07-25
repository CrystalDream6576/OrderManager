using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Abstractions
{
    /// <summary>
    /// Provides a non-generic interface that the registry and mediator can use.
    /// </summary>
    public interface IHandlerAdapter
    {
        object Handle(object request);
    }
}
