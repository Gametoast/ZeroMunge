using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using System.Windows.Forms;
using Markdig;
using mshtml;

namespace ZeroMunge
{
	public partial class ThirdPartySoftware : Form
	{
		static string resourceLibName = "ZeroMunge.ThirdPtyDocs";

		List<Software> software = new List<Software>()
		{
			new Software("license_NewtonsoftJson")
			{
				Name = "Json.NET",
				Author = "James Newton-King",
				Url = "https://www.newtonsoft.com/json"
			},

			new Software("license_markdig")
			{
				Name = "Markdig",
				Author = "Alexandre Mutel",
				Url = "https://github.com/lunet-io/markdig"
			},

			new Software("license_prettybin")
			{
				Name = "PrettyBin",
				Author = "Andrey Ershov",
				Url = "https://github.com/slmjy/PrettyBin"
			},

			new Software("license_WindowsAPICodePack")
			{
				Name = "Windows API Code Pack for Microsoft .NET Framework",
				Author = "Microsoft",
				Url = "https://github.com/aybe/Windows-API-Code-Pack-1.1"
			}
		};

		public ThirdPartySoftware()
		{
			InitializeComponent();
		}

		private void ThirdPartySoftware_Load(object sender, EventArgs e)
		{
			// Generate the HTML for the web page - it'll be styled in wb_Licenses_DocumentCompleted
			wb_Licenses.DocumentText = GenerateWebPage();
		}


		/// <summary>
		/// Generates HTML for the web page.
		/// </summary>
		/// <returns>HTML text for the web page.</returns>
		private string GenerateWebPage()
		{
			string html = "";

			// Generate the preamble text
			ResourceManager res = new ResourceManager(resourceLibName, typeof(ZeroMunge).Assembly);
			html += Markdown.ToHtml((string)res.GetObject("preamble"));

			// Generate list of software
			string list = "";
			foreach (Software s in software)
			{
				// TODO: look into linking to the anchored headings on the page instead of the software urls
				list += string.Format("- [{0}]({1}) by {2}\n", s.Name, s.Url, s.Author);
			}

			html += Markdown.ToHtml(list);


			// Generate list of licenses
			foreach (Software s in software)
			{
				// Software name
				html += Markdown.ToHtml("# " + s.Name);

				// Hyperlink to the software's web page
				html += Markdown.ToHtml(string.Format("[{0}]({0})", s.Url));

				// Licensing information for the software
				html += Markdown.ToHtml(s.License);
			}

			//Console.WriteLine(html);
			return html;
		}


		// When the WebBrowser control's document is fully loaded:
		// Style the web page with Resources/styles.css and add LinkClicked event handlers to all the hyperlinks.
		private void wb_Licenses_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			// Get our styles.css resource
			ResourceManager res = new ResourceManager(resourceLibName, typeof(ZeroMunge).Assembly);
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
			//Console.WriteLine("wb_Licenses_LinkClicked");
			HtmlElement link = sender as HtmlElement;

			if (link.OuterHtml.ToLower().StartsWith("<a "))
			{
				string href = Utilities.ExtractHtmlAttributes(link.OuterHtml)["href"];
				Process.Start(href);
			}
		}


		// When the OK button is clicked:
		// Close the dialog.
		private void btn_Accept_Click(object sender, EventArgs e)
		{
			Close();
		}


		// Representation of a single piece of software.
		class Software
		{
			public string Name { get; set; }
			public string Author { get; set; }
			public string Url { get; set; }
			public string License { get; }
			public string LicenseResource { get; }

			public Software(string licenseResourceName)
			{
				LicenseResource = licenseResourceName;

				ResourceManager res = new ResourceManager(resourceLibName, typeof(ZeroMunge).Assembly);
				License = (string)res.GetObject(LicenseResource);
			}
		}
	}
}
