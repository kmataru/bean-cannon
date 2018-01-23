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
using static System.Windows.Forms.ListViewItem;

namespace BeanCannon.Presentation.MaterializedDesktopUI.Controls
{
	public partial class TargetControl : UserControl, IBeanControl
	{
		private ControlsStore beanControls;

		public TargetControl()
		{
			InitializeComponent();

			//this.BackColor = Color.White;
			this.Load += Page1Component_Load;

			this.listViewPaths.SizeChanged += CommonEvents.MaterialListView_SizeChanged;
		}

		public void RegisterControlsStore(ControlsStore beanControls)
		{
			this.beanControls = beanControls;
		}

		private void Page1Component_Load(object sender, EventArgs e)
		{
			this.BackColor = Parent.BackColor;
		}

		private void SetErrorMessage(string message)
		{
			labelTargetIp.ForeColor = Color.DarkRed;
			labelTargetIp.Text = message;
		}

		private void textFieldUrlOrIp_TextChanged(object sender, EventArgs e)
		{
			timerTextFieldUrlOrIp.Stop();
			timerTextFieldUrlOrIp.Start();

			(beanControls.TabAttackOptions as Control).Enabled = false;
			panelCrawler.Enabled = false;
		}

		private void timerTextFieldUrlOrIp_Tick(object sender, EventArgs e)
		{
			timerTextFieldUrlOrIp.Stop();

			var testText = textFieldUrlOrIp.Text;
			var fineUrlText = textFieldUrlOrIp.Text;

			bool canGetHostInfo = false;

			if (testText.Contains(Uri.SchemeDelimiter))
			{
				canGetHostInfo = ProcessText(ref testText);
			}
			else if (testText.Contains("/") || (testText.Count(w => w == '.') != 3))
			{
				testText = $"{Uri.UriSchemeHttp}{Uri.SchemeDelimiter}{testText}";

				canGetHostInfo = ProcessText(ref testText);

				if (canGetHostInfo)
				{
					fineUrlText = $"{Uri.UriSchemeHttp}{Uri.SchemeDelimiter}{fineUrlText}";
				}
			}
			else
			{
				if (!testText.Contains(":"))
				{
					testText = $"{testText}:80";
				}

				canGetHostInfo = TryCreateIpEndPoint(testText, out IPEndPoint ipEndPoint);
				if (canGetHostInfo)
				{
					testText = ipEndPoint.Address.ToString();
				}
			}

			if (canGetHostInfo)
			{
				try
				{
					IPHostEntry hostInfo = Dns.GetHostEntry(testText);

					labelTargetIp.ForeColor = Color.FromArgb(222, 0, 0, 0);
					//materialLabel1.Text = String.Join("; ", hostInfo.AddressList.Select(w => w.ToString()));
					labelTargetIp.Text = hostInfo.AddressList[0].ToString();

					(beanControls.TabAttackOptions as Control).Enabled = true;
					panelCrawler.Enabled = true;
					AddOrUpdateToListViewContent(fineUrlText, 0);
				}
				catch (Exception ex)
				{
					(beanControls.TabAttackOptions as Control).Enabled = false;
					panelCrawler.Enabled = false;

					SetErrorMessage($"Something horrible happened: {ex.Message}");
				}
			}
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

		private void checkBoxEnableCrawler_CheckedChanged(object sender, EventArgs e)
		{
			(sender as CheckBox).Enabled = false;
			buttonLockOn.PerformClick();
		}

		private void AddOrUpdateToListViewContent(string path, int? forceIndex = null)
		{
			ListViewItem currentListViewItem;

			if (forceIndex.HasValue && listViewPaths.Items.Count > 0)
			{
				currentListViewItem = listViewPaths.Items[forceIndex.Value];
			}
			else
			{
				currentListViewItem = listViewPaths.Items.Cast<ListViewItem>()
					.FirstOrDefault(w => w.Text == path);
			}

			var listViewItemExists = null != currentListViewItem;

			listViewPaths.BeginUpdate();

			if (!listViewItemExists)
			{
				var item = new ListViewItem(path);
				var data = new[] {
					"0",
					"0",
				};

				item.SubItems.AddRange(data);
				listViewPaths.Items.Add(item);
			}
			else
			{
				ListViewSubItemCollection subItems = currentListViewItem.SubItems;

				subItems[0].Text = path;
			}

			listViewPaths.EndUpdate();
		}

		private void buttonLockOn_Click(object sender, EventArgs e)
		{
			textFieldUrlOrIp.Enabled = false;
		}
	}
}
