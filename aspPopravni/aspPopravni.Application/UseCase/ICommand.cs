using aspPopravni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.UseCase
{
    public interface ICommand<TData> : IUseCase
    {
        void Execute(TData data);
    }
}
