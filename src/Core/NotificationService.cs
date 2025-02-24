namespace desafio.api.Core
{
    public class NotificationService : INotificacaoService
    {
        public async Task SendNotification()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(21));
           
            Console.WriteLine("O Cliente Notificado.");
        }
    }
}
