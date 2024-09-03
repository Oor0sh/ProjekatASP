using aspPopravni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.UseCase
{
    public interface IQuery<TResult, TSearch> : IUseCase
        where TResult : class
    {
        TResult Execute(TSearch search);
    }
}
