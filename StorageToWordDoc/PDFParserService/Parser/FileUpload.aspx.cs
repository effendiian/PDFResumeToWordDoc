using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using CsvHelper;
using ClosedXML;
using DocumentFormat.OpenXml;
using ClosedXML.Excel;
using CsvHelper.Excel;
using System.Diagnostics;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;

namespace PDFParserService.Parser
{
	public partial class FileUpload : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
			Delete1.ServerClick += new EventHandler(Delete1_ServerClick);
		}

		private void Delete1_ServerClick(object sender, EventArgs e)
		{
			// Get the list of files in Data.
			string clearDir = Server.MapPath("~/Data/");

			if (System.IO.Directory.Exists(clearDir))
			{
				string[] files = System.IO.Directory.GetFiles(clearDir);

				if (files.Length > 0)
				{
					foreach (string file in files)
					{
						if ((File.Exists(file)) && !IsFileLocked(file))
						{
							System.IO.File.Delete(file);
							Response.Write("File: " + file + " has been deleted.");
						}
						else
						{
							Response.Write("File: " + file + " has not been deleted.");
						}
					}
				}
				else
				{
					Response.Write("No files to delete.");
				}
			}
		}

		protected void Submit1_ServerClick(object sender, EventArgs e)
		{
			string filepath = Server.MapPath("~/Data/") + "\\";
			HttpFileCollection files = Request.Files;
			Span1.Text = string.Empty;
			
			if(files == null || files.Count <= 0) {
				Span1.Text = "Please select a file to upload.";
				return;
			}

			for (int i = 0; i < files.Count; i++)
			{
				HttpPostedFile postedFile = files[i];

				try
				{
					// When clicked, upload.
					if ((postedFile != null) && (postedFile.ContentLength > 0))
					{
						Span1.Text += "<u>File #" + (i + 1) + "</u><br />";
						Span1.Text += "File Content Type: " + postedFile.ContentType + " | " + "( " + postedFile.ContentLength + "kb )" + " | " + " - " + postedFile.FileName + "<br />";
						postedFile.SaveAs(filepath + Path.GetFileName(postedFile.FileName));
						Span1.Text += "Location where saved: " + filepath + "\\" + Path.GetFileName(postedFile.FileName) + "<p>";
					}

					string ext = Path.GetExtension(postedFile.FileName).ToLower();

					// If was csv, convert and save as xlsx.
					if (ext == ".csv" || ext == ".xlsx")
					{
						Span1.Text += "Starting Excel.";
						ProcessStartInfo startInfo = new ProcessStartInfo();
						startInfo.FileName = "excel.exe";
						startInfo.Arguments = filepath + "\\" + Path.GetFileName(postedFile.FileName);
						Process.Start(startInfo);
					}
					else if (ext == ".txt")
					{
						Span1.Text += "Starting Notepad.";
						ProcessStartInfo startInfo = new ProcessStartInfo();
						startInfo.FileName = "notepad.exe";
						startInfo.Arguments = filepath + "\\" + Path.GetFileName(postedFile.FileName);
						Process.Start(startInfo);
					}
					else if (ext == ".doc" || ext == ".docx" || ext == ".rtf")
					{
						Span1.Text += "Starting Word.";
						ProcessStartInfo startInfo = new ProcessStartInfo();
						startInfo.FileName = "winword.exe";
						startInfo.Arguments = filepath + "\\" + Path.GetFileName(postedFile.FileName);
						Process.Start(startInfo);
					}

				}
				catch (Exception xe)
				{
					Span1.Text += "There was an error: " + xe.Message;
				}
			}
		}

		public bool IsFileLocked(string filePath)
		{
			try
			{
				using (File.Open(filePath, FileMode.Open)) { }
			}
			catch (IOException e)
			{
				var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);

				return errorCode == 32 || errorCode == 33;
			}

			return false;
		}
	}
}