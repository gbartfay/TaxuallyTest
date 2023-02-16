namespace Taxually.TechnicalTest.Components.Clients.Interfaces;

public interface ITaxuallyQueueClient
{
    public Task EnqueueAsync<TPayload>(string queueName, TPayload payload);
}