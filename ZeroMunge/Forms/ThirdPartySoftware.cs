using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using System.Windows.Forms;
using Markdig;
using MSHTML;
using Newtonsoft.Json;

namespace ZeroMunge
{
	public partial class ThirdPartySoftware : Form
	{
		public const string RESOURCE_LIB_NAME = "ZeroMunge.ThirdPtyDocs";
		SoftwareList softwareList = new SoftwareList();
		
		public ThirdPartySoftware()
		{
			InitializeComponent();

			// Get the list of software from our software.json resource file
			ResourceManager res = new ResourceManager(RESOURCE_LIB_NAME, typeof(ZeroMunge).Assembly);
			string jsonStr = (string)res.GetObject("software");

			// Deserialize the json into our SoftwareList class, set the license for each software, and sort the list alphabetically
			softwareList = JsonConvert.DeserializeObject<SoftwareList>(jsonStr);
			softwareList.SetLicenses();
			softwareList.Software.Sort();
		}


		// When the Form has finished loading:
		// Generate the HTML for the web page. (It'll be styled in wb_Licenses_DocumentCompleted)
		private void ThirdPartySoftware_Load(object sender, EventArgs e)
		{
			SetToolTips();

			wb_Licenses.DocumentText = GenerateWebPage();
			wb_Licenses.Document.Focusing += wb_Licenses_Document_Enter;
		}


		// When the OK button is clicked:
		// Close the dialog.
		private void btn_Accept_Click(object sender, EventArgs e)
		{
			Close();
		}


		// When the WebBrowser control enters focus:
		// Set the rightClickedControl.
		private void wb_Licenses_Document_Enter(object sender, EventArgs e)
		{
			Debug.WriteLine("wb_Licenses_Document_Enter() entered");

			//rightClickedControl = (WebBrowser)sender;
		}


		// When the WebBrowser control's document is fully loaded:
		// Style the web page with Resources/styles.css and add LinkClicked event handlers to all the hyperlinks.
		private void wb_Licenses_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			// Get our styles.css resource
			ResourceManager res = new ResourceManager(RESOURCE_LIB_NAME, typeof(ZeroMunge).Assembly);
			string stylesheet = (string)res.GetObject("stylesheet");

			// Set the web page's stylesheet
			IHTMLDocument2 doc = (IHTMLDocument2)wb_Licenses.Document.DomDocument;
			IHTMLStyleSheet ss = doc.createStyleSheet("", 0);
			ss.cssText = @stylesheet;


			// Add LinkClicked event handlers to all the links in the page
			foreach (HtmlElement link in wb_Licenses.Document.Links)
			{
				link.Click += wb_Licenses_LinkClicked;
			}
		}


		// When a hyperlink on the web page is clicked:
		// Open the link in the user's default web browser.
		private void wb_Licenses_LinkClicked(object sender, HtmlElementEventArgs e)
		{
			//Trace.WriteLine("wb_Licenses_LinkClicked");
			HtmlElement link = sender as HtmlElement;

			if (link.OuterHtml.ToLower().StartsWith("<a "))
			{
				string href = Utilities.ExtractHtmlAttributes(link.OuterHtml)["href"];
				Process.Start(href);
			}
		}


		/// <summary>
		/// Sets the form's tooltips.
		/// </summary>
		private void SetToolTips()
		{
			FormTooltips.AutoPopDelay = Properties.Settings.Default.TooltipPopDelay;

			// Third Party Software
			FormTooltips.SetToolTip(btn_Accept, Tooltips.ThirdPartySoftware.OK);
		}


		/// <summary>
		/// Generates HTML for the web page.
		/// </summary>
		/// <returns>HTML text for the web page.</returns>
		private string GenerateWebPage()
		{
			string html = "";

			// Generate the preamble text
			ResourceManager res = new ResourceManager(RESOURCE_LIB_NAME, typeof(ZeroMunge).Assembly);
			html += Markdown.ToHtml((string)res.GetObject("preamble"));

			// Generate list of software
			string list = "";
			foreach (SoftwareInfo software in softwareList.Software)
			{
				// TODO: look into linking to the anchored headings on the page instead of the software urls
				list += string.Format("- [{0}]({1}) by {2}\n", software.Name, software.Url, software.Author);
			}

			html += Markdown.ToHtml(list);


			// Generate list of licenses
			foreach (SoftwareInfo software in softwareList.Software)
			{
				// Software name
				html += Markdown.ToHtml("# " + software.Name);

				// Hyperlink to the software's web page
				html += Markdown.ToHtml(string.Format("[{0}]({0})", software.Url));

				// Licensing information for the software
				html += Markdown.ToHtml(software.License);
			}

			//Trace.WriteLine(html);
			return html;
		}


		#region Text Context Menu

		Control rightClickedControl = null;

		// When the Text context menu is opened:
		// Set the rightClickedControl.
		private void cmenu_Text_Opened(object sender, EventArgs e)
		{
			rightClickedControl = cmenu_Text.SourceControl;
		}


		// When the user clicks the Copy button in the text context menu:
		// Copy the selected text in the textbox.
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("copyToolStripMenuItem_Click() entered");

			// Try to cast the sender to a ToolStripItem
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				if (menuItem.Owner is ContextMenuStrip owner)
				{
					// Get the control that is displaying this context menu
					//Control rightClickedControl = owner.SourceControl;

					if (rightClickedControl is WebBrowser)
					{
						Debug.WriteLine("Control is WebBrowser");

						var wb = (WebBrowser)rightClickedControl;
						wb.Document.ExecCommand("Copy", false, new object());
					}
				}
			}
		}


		// When the user clicks the Select All button in the text context menu:
		// Select all of the textbox's contents.
		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("selectAllToolStripMenuItem_Click() entered");

			// Try to cast the sender to a ToolStripItem
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
				{
					// Get the control that is displaying this context menu
					//Control rightClickedControl = owner.SourceControl;

					if (rightClickedControl is WebBrowser wb)
					{
						Debug.WriteLine("Control is WebBrowser");
						
						wb.Document.ExecCommand("SelectAll", false, new object());
					}
				}
			}
		}

		#endregion Text Context Menu
	}

	// Representation of a single piece of software.
	class SoftwareInfo : IComparable<SoftwareInfo>
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string Url { get; set; }
		public string License { get; set; }
		public string LicenseResource { get; set; }

		public int CompareTo(SoftwareInfo other)
		{
			return Name.CompareTo(other.Name);
		}

		/// <summary>
		/// Gets and sets the License based on the associated license resource file.
		/// </summary>
		public void SetLicense()
		{
			ResourceManager res = new ResourceManager(ThirdPartySoftware.RESOURCE_LIB_NAME, typeof(ZeroMunge).Assembly);
			License = (string)res.GetObject(LicenseResource);
		}
	}

	class SoftwareList
	{
		public List<SoftwareInfo> Software { get; set; }

		/// <summary>
		/// Go through and call each Software's SetLicense method.
		/// </summary>
		public void SetLicenses()
		{
			foreach (SoftwareInfo s in Software)
			{
				s.SetLicense();
			}
		}
	}
}
