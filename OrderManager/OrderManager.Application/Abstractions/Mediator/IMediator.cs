using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Abstractions.Mediator
{
    public interface IMediator
    {
        TResult Send<TResult>(IRequest<TResult> request);
    }
}
