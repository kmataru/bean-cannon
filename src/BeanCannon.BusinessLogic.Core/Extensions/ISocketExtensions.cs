using BeanCannon.BusinessLogic.Core.Net.Interfaces;
using BeanCannon.BusinessLogic.Core.Services;
using BeanCannon.BusinessLogic.Core.Wrappers;
using Org.Mentalis.Network.ProxySocket;
using System;
using System.Net;
using System.Net.Sockets;

namespace BeanCannon.BusinessLogic.Core.Extensions
{
	static class ISocketExtensions
	{
		public static void WrappedConnect(this ISocket socket, EndPoint remoteEP)
		{
			var invalidateInStoreProxy = false;

			try
			{
				socket.Connect(remoteEP);
			}
			catch (SocketException ex)
			{
				if (ex.SocketErrorCode == SocketError.ConnectionReset ||
					ex.SocketErrorCode == SocketError.TimedOut)
				{
					invalidateInStoreProxy = true;
				}

				throw ex;
			}
			catch (Exception ex) when (ex is ProxyException || ex is ProtocolViolationException)
			{
				invalidateInStoreProxy = true;

				throw ex;
			}
			finally
			{
				if (invalidateInStoreProxy)
				{
					socket.InvalidateInStoreProxy();
				}
			}
		}

		public static void InvalidateInStoreProxy(this ISocket socket)
		{
			if (socket is ProxySocket)
			{
				var proxySocket = (socket as ProxySocket);
				var proxyDatum = proxySocket.ProxyDatum;

				ProxyTester.SetTestValidity(
					proxyDatum,
					socket.AddressFamily, socket.SocketType, socket.ProtocolType, proxySocket.ProxyType,
					ProxyTester.InvalidProxyConnectionTime
					);
			}
		}

		public static byte[] ReadFixed(this Socket socket, int size)
		{
			//The size of the amount of bytes you want to recieve, eg 1024
			var bytes = new byte[size];
			var total = 0;

			do
			{
				var read = socket.Receive(bytes, total, size - total, SocketFlags.None);

				// TODO : Put a nice description here
				if (read == 0)
				{
					//If it gets here and you received 0 bytes it means that the Socket has Disconnected gracefully (without throwing exception) so you will need to handle that here

					return bytes;
				}
				total += read;
				//If you have sent 1024 bytes and Receive only 512 then it wil continue to recieve in the correct index thus when total is equal to 1024 you will have recieved all the bytes
			} while (total != size);

			return bytes;
		}
	}
}
