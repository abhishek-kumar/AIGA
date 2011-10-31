using System;
using System.IO;

namespace Alchemi.Updater
{
	//**************************************************************
	// UpdateLog Class
	// Used to write the updater log file, which records update 
	// successes & failures to assist debugging. 
	//**************************************************************
	internal class UpdateLog
	{
		const string LogFileName = "AppUpdate.log";

		//**************************************************************
		// UpdateLog()	
		//**************************************************************
		internal UpdateLog()
		{
			string FullLogFilePath = Path.Combine(GetLogFilePath(), LogFileName);
			if (!File.Exists(FullLogFilePath))
			{
				File.Create(FullLogFilePath);
				File.SetAttributes(FullLogFilePath,FileAttributes.Hidden);
			}
		}

		//**************************************************************
		// AddSuccess()	
		//**************************************************************
		internal void AddSuccess(string versionNumber)
		{
			string FullLogFilePath = Path.Combine(GetLogFilePath(), LogFileName);
			FileStream LogStream = File.Open(FullLogFilePath,FileMode.Append);
			StreamWriter SW = new StreamWriter(LogStream);

			string StringToWrite;
			StringToWrite = DateTime.Now.ToString() + ":  Successful update to version:  " + versionNumber;

			SW.WriteLine(StringToWrite);
			SW.Close();
		}

		//**************************************************************
		// AddError()	
		//**************************************************************
		internal void AddError(string errorMessage)
		{
			string FullLogFilePath = Path.Combine(GetLogFilePath(), LogFileName);
			FileStream LogStream = File.Open(FullLogFilePath,FileMode.Append);
			StreamWriter SW = new StreamWriter(LogStream);

			string StringToWrite;
			StringToWrite = DateTime.Now.ToString() + ":  UPDATE FAILED with the following error message:";
			SW.WriteLine(StringToWrite);
			StringToWrite = errorMessage;
			SW.WriteLine(StringToWrite);
			SW.Close();
		}

		//**************************************************************
		// GetLogFilePath()	
		//**************************************************************
		private string GetLogFilePath()
		{
			DirectoryInfo DI = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
			return (DI.Parent.Parent.FullName + @"\");
		}

	}
}
