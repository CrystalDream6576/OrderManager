using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Abstractions
{
    public interface IMediator
    {
        TResult Send<TResult>(IRequest<TResult> request);
    }
}
