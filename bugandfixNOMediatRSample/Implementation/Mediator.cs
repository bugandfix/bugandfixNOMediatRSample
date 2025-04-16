using bugandfixNOMediatRSample.Abstractions;

namespace bugandfixNOMediatRSample.Implementation;

public class Mediator(IServiceProvider provider) : IMediator
{
    public async Task<TResult> SendCommandAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResult>
    {
        var handler = provider.GetService<ICommandHandler<TCommand, TResult>>();
        if (handler == null)
        {
            throw new InvalidOperationException($"No handler registered for {typeof(TCommand).Name}");
        }

        var behaviors = provider.GetServices<IPipelineBehavior<TCommand, TResult>>().Reverse();

        Func<Task<TResult>> handlerDelegate = () => handler.HandleAsync(command, cancellationToken);
        foreach (var behavior in behaviors)
        {
            var next = handlerDelegate;
            handlerDelegate = () => behavior.HandleAsync(command, next, cancellationToken);
        }

        return await handlerDelegate();
    }

    public async Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery<TResult>
    {
        var handler = provider.GetService<IQueryHandler<TQuery, TResult>>();
        if (handler == null)
        {
            throw new InvalidOperationException($"No handler registered for {typeof(TQuery).Name}");
        }

        var behaviors = provider.GetServices<IPipelineBehavior<TQuery, TResult>>().Reverse();
        Func<Task<TResult>> handlerDelegate = () => handler.HandleAsync(query, cancellationToken);
        foreach (var behavior in behaviors)
        {
            var next = handlerDelegate;
            handlerDelegate = () => behavior.HandleAsync(query, next, cancellationToken);
        }

        return await handlerDelegate();
    }
}