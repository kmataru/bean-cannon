using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeanCannon.Presentation.MaterializedDesktopUI.Components;
using System.Net;
using System.Globalization;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class TargetControl : UserControl
	{
		public TargetControl()
		{
			InitializeComponent();

			//this.BackColor = Color.White;
			this.Load += Page1Component_Load;

			// Add dummy data to the listview
			seedListView();

			this.listViewPaths.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
			//textFieldUrlOrIp.TextChanged
		}

		private void Page1Component_Load(object sender, EventArgs e)
		{
			this.BackColor = Parent.BackColor;
		}

		private void seedListView()
		{
			//Define
			var data = new[]
			{
				new []{ "/path/1", "666", "0" },
				new []{ "/path/2", "666", "7" },
				new []{ "/path/3", "666", "3" },
				new []{ "/path/4", "666", "7" },
				new []{ "/path/5", "666", "6" },
				new []{ "/path/6", "666", "5" }
			};

			//Add
			foreach (string[] version in data)
			{
				var item = new ListViewItem(version);
				listViewPaths.Items.Add(item);
			}

			//materialListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			//materialListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void SetErrorMessage(string message)
		{
			materialLabel1.ForeColor = Color.DarkRed;
			materialLabel1.Text = message;
		}

		private void textFieldUrlOrIp_TextChanged(object sender, EventArgs e)
		{
			timerTextFieldUrlOrIp.Stop();
			timerTextFieldUrlOrIp.Start();
		}

		private void timerTextFieldUrlOrIp_Tick(object sender, EventArgs e)
		{
			timerTextFieldUrlOrIp.Stop();

			var text = textFieldUrlOrIp.Text;
			bool canGetHostInfo = false;

			if (text.Contains(Uri.SchemeDelimiter))
			{
				canGetHostInfo = ProcessText(ref text);
			}
			else if (text.Contains("/") || (text.Count(w => w == '.') != 3))
			{
				text = $"{Uri.UriSchemeHttp}{Uri.SchemeDelimiter}{text}";

				canGetHostInfo = ProcessText(ref text);
			}
			else
			{
				if (!text.Contains(":"))
				{
					text = $"{text}:80";
				}

				canGetHostInfo = TryCreateIpEndPoint(text, out IPEndPoint ipEndPoint);
				if (canGetHostInfo)
				{
					text = ipEndPoint.Address.ToString();
				}
			}

			if (canGetHostInfo)
			{
				try
				{
					IPHostEntry hostInfo = Dns.GetHostEntry(text);

					materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
					//materialLabel1.Text = String.Join("; ", hostInfo.AddressList.Select(w => w.ToString()));
					materialLabel1.Text = hostInfo.AddressList[0].ToString();
				}
				catch (Exception ex)
				{
					SetErrorMessage($"Something horrible happened: {ex.Message}");
				}
			}

			/*
			bool isValidUri = Uri.TryCreate(textFieldUrlOrIp.Text, UriKind.Absolute, out Uri uriResult)
				&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

			if (isValidUri)
			{
				//
				//
			}
			else
			{
				if (!IPAddress.TryParse(textFieldUrlOrIp.Text, out IPAddress ipAddress))
				{
				}
			}
			*/
		}

		private bool ProcessText(ref string text)
		{
			bool isValidUri = Uri.TryCreate(text, UriKind.Absolute, out Uri uriResult);

			if (isValidUri)
			{
				bool hasValidScheme = (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
				if (hasValidScheme)
				{
					//text = $"{uriResult.Host}:{uriResult.Port}";
					text = uriResult.Host;
				}
				else
				{
					SetErrorMessage("Invalid scheme");
					return false;
				}
			}
			else
			{
				SetErrorMessage("Invalid URL");
				return false;
			}

			return true;
		}

		/// <summary>
		/// Handles IPv4 and IPv6 notation.
		/// FROM https://stackoverflow.com/questions/2727609/best-way-to-create-ipendpoint-from-string/35357209
		/// </summary>
		/// <param name="endPoint"></param>
		/// <param name="ipEndPoint"></param>
		/// <returns></returns>
		public bool TryCreateIpEndPoint(string endPoint, out IPEndPoint ipEndPoint)
		{
			ipEndPoint = null;

			string[] ep = endPoint.Split(':');
			if (ep.Length < 2)
			{
				return false;
			}

			IPAddress ip;

			if (ep.Length > 2)
			{
				if (!IPAddress.TryParse(string.Join(":", ep, 0, ep.Length - 1), out ip))
				{
					SetErrorMessage("Invalid IP address");
					return false;
				}
			}
			else
			{
				if (!IPAddress.TryParse(ep[0], out ip))
				{
					SetErrorMessage("Invalid IP address");
					return false;
				}
			}

			if (!int.TryParse(ep[ep.Length - 1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out int port))
			{
				SetErrorMessage("Invalid port");
				return false;
			}

			if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
			{
				SetErrorMessage("Invalid port range");
				return false;
			}

			ipEndPoint = new IPEndPoint(ip, port);

			return true;
		}
	}
}
