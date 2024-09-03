using aspPopravni.Application.DTO;
using aspPopravni.Application.UseCase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation
{
    public class UseCaseHandler
    {
        private readonly IUserUseCase _user;
        private readonly IUseCaseLogger _logger;
        public UseCaseHandler(IUserUseCase user, IUseCaseLogger logger)
        {
            _user = user;
            _logger = logger;
        }
        public void HandleCommand<TData>(ICommand<TData> command, TData data)
        {
            HandleCrossCuttingConcerns(command, data);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            command.Execute(data);
            stopwatch.Stop();
            Console.WriteLine($"Use Case:{command.Id}, {stopwatch.ElapsedMilliseconds} ms");
        }
        public TResult HandleQuery<TResult, TSearch>(IQuery<TResult, TSearch> query, TSearch search)
            where TResult : class
        {
            HandleCrossCuttingConcerns(query, search);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = query.Execute(search);
            stopwatch.Stop();
            Console.WriteLine($"Use Case: {query.Id}, {stopwatch.ElapsedMilliseconds} ms");
            return result;
        }
        private void HandleCrossCuttingConcerns(IUseCase useCase, object data)
        {
            Console.WriteLine(useCase.Id);
            if (!_user.AllowedUseCases.Contains(useCase.Id))
            {
                throw new UnauthorizedAccessException();
            }
            var log = new UseCaseLogDTO(useCase.Id, _user.Id, data);

            _logger.Log(log);
        }
    }
}
