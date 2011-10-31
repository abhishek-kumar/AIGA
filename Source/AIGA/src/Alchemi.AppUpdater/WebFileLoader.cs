using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System.Collections;
using System.Globalization;

namespace Alchemi.Updater
{
	//**************************************************************
	// WebFileLoader class
	// - Full of static helper methods for network & disk I/O
	//**************************************************************
	public class WebFileLoader
	{

		//**************************************************************
		// CheckForFileUpdate()	
		// - Checks to see if a newer file is on the server
		//**************************************************************
		public static bool CheckForFileUpdate(string url, string filePath)
		{
			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
			Request.Method = "HEAD";
			Request.Credentials = CredentialCache.DefaultCredentials;

			//Set up the last modfied time header
			if (File.Exists(filePath)) 
				Request.IfModifiedSince = LastModFromDisk(filePath);

			HttpWebResponse Response;
			try 
			{
				Response = (HttpWebResponse)Request.GetResponse();
			}
			catch(WebException e) 
			{
				if (e.Response == null)
				{
					Debug.WriteLine("Error accessing Url " + url);
					throw;
				}
			
				HttpWebResponse errorResponse = (HttpWebResponse)e.Response;

				//if the file has not been modified
				if (errorResponse.StatusCode == HttpStatusCode.NotModified)
				{
					e.Response.Close();
					return false;
				}
				else 
				{
					e.Response.Close();
					Debug.WriteLine("Error accessing Url " + url);
					throw;
				}
			} 
			//This case happens if no lastmodedate was specified, but the specified
			//file does exist on the server. 
			Response.Close();
			return true;
		}

		//**************************************************************
		// UpdateFile()	
		// - Copies the newer file on the server to the client
		//**************************************************************
		public static void UpdateFile(string url, string filePath)
		{
			HttpWebResponse Response;
			
			//Retrieve the File
			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
			Request.Headers.Add("Translate: f");
			Request.Credentials = CredentialCache.DefaultCredentials;

			//Set up the last modfied time header
			if (File.Exists(filePath)) 
				Request.IfModifiedSince = LastModFromDisk(filePath);

			try 
			{
				Response = (HttpWebResponse)Request.GetResponse();
			}
			catch(WebException e) 
			{
				if (e.Response == null) 
				{
					Debug.WriteLine("Error accessing Url " + url);
					Exception ex = new Exception("Error accessing url "+url,e);
					throw ex;
				}

				HttpWebResponse errorResponse = (HttpWebResponse)e.Response;
				
				//if the file has not been modified
				if (errorResponse.StatusCode == HttpStatusCode.NotModified)
				{
					e.Response.Close();
					return;
				}
				else 
				{
					e.Response.Close();
					Debug.WriteLine("Error accessing Url " + url);
					Exception ex = new Exception("Error accessing url "+url,e);
					throw ex;
				}
			}
		
			Stream respStream = null;

			try 
			{
				respStream = Response.GetResponseStream();
				CopyStreamToDisk(respStream,filePath);

				DateTime d = System.Convert.ToDateTime(Response.GetResponseHeader("Last-Modified"));
				File.SetLastWriteTime(filePath,d);
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  Error writing to:  " + filePath);
				Exception ex = new Exception("Error writing to file: " + filePath,e);
				throw ex;
			}
			finally 
			{
				if (respStream != null)
					respStream.Close();
				if (Response != null)
					Response.Close();
			}
		}

		//**************************************************************
		// CopyDirectory()	
		// Does a deep copy
		// Returns the number of files copied
		// If keys is null, validates assemblies copied have been signed
		// by one of the provided keys.
		//**************************************************************
		public static int CopyDirectory(string url, string filePath)
		{
			Resource currentResource;
			int FileCount = 0;
			string newFilePath;
			SortedList DirectoryList = WebFileLoader.GetDirectoryContents(url, false);

			foreach(Object r in DirectoryList) 
			{
				currentResource = (Resource)(((DictionaryEntry)r).Value);
	
				//If the directory doesn't exist, create it first
				if (!Directory.Exists(filePath))
					Directory.CreateDirectory(filePath);
		
				//If it's a file than copy the file.
				if (!currentResource.IsFolder)
				{
					FileCount++;
					newFilePath = filePath + currentResource.Name;
			
					//only update the file if it doesn't exist or if the one on the server
					//returned a newer last modtime than the one on disk
					if (!File.Exists(newFilePath))
						UpdateFile(currentResource.Url,newFilePath);
					else
						if (currentResource.LastModified > LastModFromDisk(newFilePath))
							UpdateFile(currentResource.Url,newFilePath);				

				}
				//If it's a folder, download the folder itself.
				else
				{
					newFilePath = filePath + currentResource.Name + "\\";
					FileCount += CopyDirectory(currentResource.Url,newFilePath);
				}	
			}
			return FileCount;
		}

		//**************************************************************
		// GetDirectoryContents()	
		// - Uses HTTP/DAV to get a list of directories
		//**************************************************************
		public static SortedList GetDirectoryContents(string url, bool deep)
		{
			//Retrieve the File
			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
			Request.Headers.Add("Translate: f");
			Request.Credentials = CredentialCache.DefaultCredentials;

			string requestString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"+
				"<a:propfind xmlns:a=\"DAV:\">"+
				"<a:prop>"+
				"<a:displayname/>"+
				"<a:iscollection/>"+
				"<a:getlastmodified/>"+
				"</a:prop>"+
				"</a:propfind>";
			
			Request.Method = "PROPFIND";
			if (deep == true)
				Request.Headers.Add("Depth: infinity");
			else
				Request.Headers.Add("Depth: 1");
			Request.ContentLength = requestString.Length;
			Request.ContentType	= "text/xml";

			Stream requestStream = Request.GetRequestStream();
			requestStream.Write(Encoding.ASCII.GetBytes(requestString),0,Encoding.ASCII.GetBytes(requestString).Length);
			requestStream.Close();

			HttpWebResponse Response;
			StreamReader respStream;
			try 
			{
				Response = (HttpWebResponse)Request.GetResponse();
				respStream = new StreamReader(Response.GetResponseStream());
			}
			catch (WebException e)
			{
				Debug.WriteLine("APPMANAGER:  Error accessing Url " + url);
				Exception ex = new Exception("Error accessing url "+url,e);
				throw ex;
			}

			StringBuilder SB = new StringBuilder(); 
						
			char[] respChar = new char[1024];
			int BytesRead = 0;

			BytesRead = respStream.Read(respChar,0,1024);
			
			while (BytesRead>0)
			{
				SB.Append(respChar,0,BytesRead);
				BytesRead = respStream.Read(respChar,0,1024);				
			}
			respStream.Close();

			XmlDocument XmlDoc = new XmlDocument();
			XmlDoc.LoadXml(SB.ToString());
			      
			//Create an XmlNamespaceManager for resolving namespaces.
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(XmlDoc.NameTable);
			nsmgr.AddNamespace("a", "DAV:");

			XmlNodeList NameList = XmlDoc.SelectNodes("//a:prop/a:displayname",nsmgr);
			XmlNodeList isFolderList = XmlDoc.SelectNodes("//a:prop/a:iscollection",nsmgr);
			XmlNodeList LastModList = XmlDoc.SelectNodes("//a:prop/a:getlastmodified",nsmgr);
			XmlNodeList HrefList = XmlDoc.SelectNodes("//a:href",nsmgr);

			SortedList ResourceList = new SortedList();
			Resource tempResource;

			for (int i=0; i < NameList.Count; i++)
			{
				//This check is needed because the PROPFIND request returns the contents of the folder
				//as well as the folder itself.  Exclude the folder.
				if (HrefList[i].InnerText.ToLower(new CultureInfo("en-US")).TrimEnd(new char[] {'/'}) != url.ToLower(new CultureInfo("en-US")).TrimEnd(new char[] {'/'}))
				{
					tempResource = new Resource();
					tempResource.Name = NameList[i].InnerText;
					tempResource.IsFolder = Convert.ToBoolean(Convert.ToInt32(isFolderList[i].InnerText));
					tempResource.Url = HrefList[i].InnerText;
					tempResource.LastModified = Convert.ToDateTime(LastModList[i].InnerText);
					ResourceList.Add(tempResource.Url,tempResource);
				}
			}

			return ResourceList;
		}

		//**************************************************************
		// UpdateFileList()	
		// - A multi-file UpdateFile
		//**************************************************************
		public static void UpdateFileList(SortedList fileList, string sourceUrl, string destPath)
		{
			Resource currentResource;

			//If the directory doesn't exist, create it first
			if (!Directory.Exists(destPath))
				Directory.CreateDirectory(destPath);

			foreach(Object o in fileList) 
			{
				currentResource = (Resource)(((DictionaryEntry)o).Value);
	
				string url = sourceUrl + currentResource.Name;
				string FilePath = destPath + currentResource.Name;
				WebFileLoader.UpdateFile(url,FilePath); 
			}
		}

		//**************************************************************
		// GetLastModTime()	
		// - Gets the last mode time for a file on the server
		//**************************************************************
		public static DateTime GetLastModTime(string url)
		{
			HttpWebResponse Response;
			
			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
			Request.Method = "HEAD";

			try 
			{
				Response = (HttpWebResponse)Request.GetResponse();
			}
			catch(WebException e) 
			{
				Debug.WriteLine("Error accessing Url " + url);
				if (e.Response != null)
					e.Response.Close();
				throw;
			}
		
			DateTime d = System.Convert.ToDateTime(Response.GetResponseHeader("Last-Modified"));
			return d;

		}

		//**************************************************************
		// LoadFile()	
		// - Returns a stream to a file on a web server
		//**************************************************************
		public static Stream LoadFile(string url)
		{
			HttpWebResponse Response;
			
			//Retrieve the File
			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);

			try 
			{
				Response = (HttpWebResponse)Request.GetResponse();
			}
			catch(WebException) 
			{
				Debug.WriteLine("Error accessing Url " + url);
				throw;
			}
		
			return Response.GetResponseStream();	
		}	
		
		//**************************************************************
		// CheckForFileUpdate()	
		// - Checks if the file on the server is newer than the given date
		//**************************************************************
		public static bool CheckForFileUpdate(string url, DateTime lastModeTime)
		{
			HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
			Request.Method = "HEAD";

			Request.IfModifiedSince = lastModeTime;
			
			HttpWebResponse Response;
			try 
			{
				Response = (HttpWebResponse)Request.GetResponse();
			}
			catch(WebException e) 
			{
				if (e.Response == null)
				{
					Debug.WriteLine("Error accessing Url " + url);
					throw;
				}
			
				HttpWebResponse errorResponse = (HttpWebResponse)e.Response;

				//if the file has not been modified
				if (errorResponse.StatusCode == HttpStatusCode.NotModified)
				{
					e.Response.Close();
					return false;
				}
				else 
				{
					e.Response.Close();
					Debug.WriteLine("Error accessing Url " + url);
					throw;
				}
			}
			//This case happens if no lastmodedate was specified, but the specified
			//file does exist on the server. 
			Response.Close();
			return true;
		}

		//**************************************************************
		// GetFileCount()	
		// - Gets the list of files on the server.  Useful when downloading
		// many files and you need the file count for a progress indicator
		//**************************************************************
		public static int GetFileCount(string filePath)
		{

			string[] directories = Directory.GetDirectories(filePath);
			string[] files = Directory.GetFiles(filePath);
			string name;

			int count=0;
			count = files.Length + directories.Length;

			foreach (string directory in directories)
			{
				name = directory.Remove(0,directory.LastIndexOf("\\")+1);
				
				count = count + GetFileCount(filePath + name + "\\");
			}
			
			return count;
		}

		//**************************************************************
		// CopyStreamToDisk()	
		//**************************************************************
		private static void CopyStreamToDisk(Stream responseStream, String filePath)
		{
			byte[] buffer = new byte[4096];
			int length;
			
			//Copy to a temp file first so that if anything goes wrong with the network
			//while downloading the file, we don't actually update the real on file disk
			//This essentially gives us transaction like semantics.
			Random Rand = new Random();
			string tempPath = Environment.GetEnvironmentVariable("temp") + "\\";
			tempPath += filePath.Remove(0,filePath.LastIndexOf("\\")+1);
			tempPath += Rand.Next(10000).ToString() + ".tmp";

			FileStream AFile = File.Open(tempPath,FileMode.Create,FileAccess.ReadWrite);
			
			length = responseStream.Read(buffer,0,4096);
			while ( length > 0)
			{
				AFile.Write(buffer,0,length);
				length = responseStream.Read(buffer,0,4096);
			}
			AFile.Close();	

			if (File.Exists(filePath))
				File.Delete(filePath);
			File.Move(tempPath,filePath);
		}

		//**************************************************************
		// LastModFromDisk()	
		//**************************************************************
		public static DateTime LastModFromDisk(string filePath)
		{
			FileInfo f = new FileInfo(filePath);
			return (f.LastWriteTime);
		}

		//**************************************************************
		// CopyAndRename()	
		//**************************************************************
		public static void CopyAndRename(string source, string dest)
		{
			string[] directories = Directory.GetDirectories(source);
			string[] files = Directory.GetFiles(source);
			string name;

			//If the directory doesn't exist, create it first
			if (!Directory.Exists(dest))
				Directory.CreateDirectory(dest);

			foreach (string file in files)
			{
				name = file.Remove(0,file.LastIndexOf("\\")+1);
				MessageBox.Show(name);
				
				if (File.Exists(dest+name))
					File.Delete(dest+name);
				
				File.Move(file, dest+name);
			}

			foreach (string directory in directories)
			{
				name = directory.Remove(0,directory.LastIndexOf("\\")+1);
				MessageBox.Show(name);

				if (!Directory.Exists(dest + name + "\\"))
					Directory.CreateDirectory(dest + name + "\\");
				
				CopyAndRename(source + name + "\\", dest + name + "\\");
			}

			Directory.Delete(source,true);
		}

		//**************************************************************
		// CreateHttpsUrl()	
		//**************************************************************
		public static string CreateHttpsUrl(string url)
		{
			url = url.ToLower(new CultureInfo("en-US"));
			if (url.StartsWith("https"))
				return url;
			else
			{
				return url.Insert(4,"s");
			}
		}
	}
}
