using System;
using System.Windows;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
    
namespace WPFClient;
public partial class MainWindow : Window
{
    HubConnection connection;
    public MainWindow()
    {
        InitializeComponent();

        connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7139/chathub")
            .WithAutomaticReconnect()
            .Build();

        connection.Reconnecting += (sender) => 
        {
            this.Dispatcher.Invoke(() =>
            {
                var newMessage = "Попытка переподключиться...";
                messages.Items.Add(newMessage);
            });

            return Task.CompletedTask;
        };
    }
}
