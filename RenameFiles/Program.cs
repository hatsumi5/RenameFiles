using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenameFiles
{
	delegate void SetTextCallback(string text);
	static class Program
	{
		const int port = 824;
		const string serverIP = "localhost";
		static Thread thread;
		static FormRenameFiles form;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			var createdNew = false;
			Process current = Process.GetCurrentProcess();
			using (Mutex mutex = new Mutex(true, current.ProcessName, out createdNew))
			{
				if (!createdNew)
				{
					try
					{
						if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
						{
							send(args[0]);
							return;
						}
					}
					finally
					{
						current.Kill();
					}
				}
				thread = new Thread(new ThreadStart(receive));
				thread.Start();

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				form = new FormRenameFiles();
				if (args.Length > 0) form.DataGridView.Add(args[0]);

				Application.Run(form);
			}
		}

		static void receive()
		{
			TcpListener tcpListener = null;
			IPAddress ipAddress = Dns.GetHostEntry(serverIP).AddressList[0];
			try
			{
				tcpListener = new TcpListener(ipAddress, port);
				tcpListener.Start();
			}
			catch (Exception e)
			{
				var output = "Error: " + e.ToString();
				MessageBox.Show(output);
				return;
			}
			while (true)
			{
				TcpClient tcpClient = null;
				NetworkStream stream = null;
				try
				{
					tcpClient = tcpListener.AcceptTcpClient();

					stream = tcpClient.GetStream();
					var qtd = stream.ReadByte();
					byte[] bytes = new byte[qtd];
					stream.Read(bytes, 0, bytes.Length);

					var path = Encoding.UTF8.GetString(bytes);
					if (string.IsNullOrWhiteSpace(path) || path == Environment.NewLine) return;

					var invoke = new SetTextCallback(form.DataGridView.Add);
					form.Invoke(invoke, path);
					SystemUtil.SetForegroundWindows();
				}
				finally
				{
					stream?.Close();
					tcpClient?.Close();
				}
			}
		}
		static void send(string message)
		{
			using (var client = new TcpClient(serverIP, port))
			{
				using (var stream = client.GetStream())
				{
					try
					{
						Byte[] data = Encoding.UTF8.GetBytes(message);
						stream.WriteByte((byte)data.Length);
						stream.Write(data, 0, data.Length);
					}
					catch (ArgumentNullException e)
					{
						var output = "ArgumentNullException: " + e;
						MessageBox.Show(output);
					}
					catch (SocketException e)
					{
						var output = "SocketException: " + e.ToString();
						MessageBox.Show(output);
					}
				}
			}
		}
	}
}