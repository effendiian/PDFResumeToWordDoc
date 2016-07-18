using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDFParserService.Parser
{
	public partial class Download : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			string path = Server.MapPath("~/");
			DirectoryInfo dir = new DirectoryInfo(path);
			DirectoryInfo[] dirs = dir.GetDirectories();

			DirectoryInfo modify = dirs[0];

			foreach (DirectoryInfo d in dirs)
			{
				if (d.Name == "Data")
				{
					modify = d;
				}
			}

			foreach (FileInfo files in modify.GetFiles())
			{
				DropDownList1.Items.Add(files.Name);
			}

			Span1.Text = "";
			Span2.Text = "";

			if (!Page.IsPostBack)
			{
				DropDownList1.SelectedIndex = 0;
				DropDownList1.DataBind();
			}

			Submit1.ServerClick += Submit1_ServerClick;
			DropDownList1.SelectedIndexChanged += DropDownList1_SelectedIndexChanged;
		}

		protected void Submit1_ServerClick(object sender, EventArgs e)
		{
			string filepath = Server.MapPath("~/Data/") + "\\";
			string request = DropDownList1.SelectedItem.Text;

			string rqt = filepath + request;
			string requestString = rqt.Replace("\\\\", "\\");
			Span1.Text = "Downloading: " + rqt;
			Span2.Text = requestString;

			FileDownload(request, requestString);
		}

		private void FileDownload(string filename, string filepath)
		{
			HttpResponse response = HttpContext.Current.Response;

			string contentType = MimeMapping.GetMimeMapping(filename);
			string header = "attachment; filename=" + filename;

			FileInfo filedownload = new FileInfo(filepath);

			response.ClearContent();
			response.Clear();
			response.ContentType = contentType;
			response.AddHeader("Content-Disposition", header);
			response.WriteFile(filedownload.FullName);
			response.End();
		}
		
		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			DropDownList1.DataBind();
		}
	}
}