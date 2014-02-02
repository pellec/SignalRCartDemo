using System;
using Microsoft.AspNet.SignalR.Client;

namespace ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var con = new HubConnection("http://localhost/SignalRDemo");

			var adminHub = con.CreateHubProxy("admin");

			con.Start().ContinueWith(t => Console.WriteLine("Connected")).Wait();

			adminHub.On<dynamic>("orderReceived", order => Console.WriteLine(order));

			Console.Read();
			con.Stop();
		}
	}
}
