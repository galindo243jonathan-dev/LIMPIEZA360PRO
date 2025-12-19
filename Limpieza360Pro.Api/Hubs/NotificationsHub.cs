using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Limpieza360Pro.Api.Hubs
{
    public class NotificationsHub : Hub
    {
        // Enviar notificación a todos los clientes conectados
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
