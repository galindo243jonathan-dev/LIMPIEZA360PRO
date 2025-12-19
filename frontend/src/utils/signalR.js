import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

let connection = null;

export function startNotificationsHub(onNotification) {
  if (connection) return;
  connection = new HubConnectionBuilder()
    .withUrl('https://localhost:5001/hubs/notifications')
    .configureLogging(LogLevel.Information)
    .build();

  connection.on('ReceiveNotification', onNotification);

  connection.start().catch(err => console.error('SignalR error:', err));
}

export function stopNotificationsHub() {
  if (connection) {
    connection.stop();
    connection = null;
  }
}
