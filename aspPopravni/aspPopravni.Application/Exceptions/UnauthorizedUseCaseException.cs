using aspPopravni.Application.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IUserUseCase user)
            : base($"User with an ID of {user.Id} tried to execute {useCase.Name}.")
        {

        }
    }
}
