using bugandfixNOMediatRSample.Abstractions;

namespace bugandfixNOMediatRSample.LoggingBehavior;


public class LoggingBehavior<TInput, TOutput> : IPipelineBehavior<TInput, TOutput>
{
    public async Task<TOutput> HandleAsync(TInput input, Func<Task<TOutput>> next, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Starting: {typeof(TInput).Name}");
        var result = await next();
        Console.WriteLine($"Finished: {typeof(TOutput).Name}");
        return result;
    }
}