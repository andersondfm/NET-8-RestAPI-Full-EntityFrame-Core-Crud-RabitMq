namespace ANDERSONDFM.Integracao
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
