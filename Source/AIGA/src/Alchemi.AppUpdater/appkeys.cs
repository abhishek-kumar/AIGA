using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting;
using System.Threading;
using System.Globalization;

namespace Alchemi.Updater
{
	/// <summary>
	/// Summary description for AppKeys.
	/// </summary>
	//**************************************************************
	// AppKeys Class
	// Used to validate downloaded assemblies.  On initialization, 
	// a list of valid keys is built up by using the main entry
	// point assemblies keys and any keys in the remote AppUpdaterKeys.dll.
	// Validation is done in a seperate appdomain to prevent collision
	// with assemblies already loaded in the current app domain.
	//**************************************************************
	public class AppKeys
	{
		private const string KEYFILENAME = "AppUpdaterKeys.dll";

		private AppDomain AD;
		private byte[][] KeyList;
		private string[] ExceptionList;
		private KeyValidator Validator;
		private string AppUrl;

		public AppKeys(string appUrl)
		{
			AppUrl = appUrl;
		}

		//**************************************************************
		// InitializeKeyCheck()	
		//**************************************************************
		public void InitializeKeyCheck()
		{
			//Clear any previous app domain
			UnInitializeKeyCheck();

			AD = AppDomain.CreateDomain("KeyValidatorDomain");
			
			BindingFlags flags = (BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance);

			ObjectHandle objh = AD.CreateInstance( "AppUpdater", "Microsoft.Samples.AppUpdater.KeyValidator", false,
				               flags, null, null, null, null, null);
							   
			// Unwrap the object
			Object obj = objh.Unwrap();

			// Cast to the actual type
			Validator = (KeyValidator)obj;

			KeyList = GetKeyList(AppUrl.TrimEnd(new char[] {'/'}) + "/" + KEYFILENAME);

		}

		//**************************************************************
		// UnInitializeKeyCheck()	
		//**************************************************************
		public void UnInitializeKeyCheck()
		{
			if (AD != null)
			{
				AppDomain.Unload(AD);
				
				//Gives the async Unload call some time to complete, 
				//only effects whether older versions are cleaned up or not.
				Thread.Sleep(TimeSpan.FromSeconds(2));		
				AD = null;
			}
		}

		//**************************************************************
		// ValidateAssembly()	
		//**************************************************************
		public bool ValidateAssembly(string assemblyLocation)
		{
            //Check the assembly using the Validator object running in 
 		    //the other appdomain
			return (Validator.Validate(assemblyLocation,KeyList,ExceptionList));
		}

		//**************************************************************
		// GetKeyList()	
		//**************************************************************
		public byte[][] GetKeyList(string keyFileUrl)
		{
			byte[][] RemoteKeys = null;

			try 
			{
				//Load the remote key assembly
				AssemblyName AN = new AssemblyName();
				AN.CodeBase = keyFileUrl;
				Assembly KeyAssembly = AD.Load(AN);

				//Validate the Assembly was signed w/ the same public key as the main assembly
				if (KeyValidator.CompareKeys(KeyAssembly.GetName().GetPublicKey(),
					new Byte[][] {Assembly.GetEntryAssembly().GetName().GetPublicKey()}))
				{
					//Get the keys out of the assembly
					Type T = KeyAssembly.GetType("Microsoft.Samples.AppUpdater.KeyList");
					RemoteKeys = (byte[][]) T.GetField("Keys").GetValue(null);

					//Get the list of file exceptions
					ExceptionList = (string[]) T.GetField("ExceptionList").GetValue(null);

				} 
			}
			catch (Exception)
			{
				Debug.WriteLine("APPMANAGER:  No remote keys found.");
			}
			
			byte[][] Keys = null;

			if (RemoteKeys != null)
			{
				Keys = new byte[RemoteKeys.Length+1][];
				Keys[0] = Assembly.GetEntryAssembly().GetName().GetPublicKey();
				RemoteKeys.CopyTo(Keys,1);
			}
			else 
			{
				Keys = new byte[1][];
				Keys[0] = Assembly.GetEntryAssembly().GetName().GetPublicKey();
			}

			return Keys;
		}
	}


	//**************************************************************
	// KeyValidator Class	
	//**************************************************************
	public class KeyValidator : MarshalByRefObject
	{
		//**************************************************************
		// KeyValidator
		//**************************************************************
		public KeyValidator()
		{
		}

		//**************************************************************
		// Validate()
		// Meant to be called in it's own app domain
		//**************************************************************
		public bool Validate(string assemblyLocation, byte[][] keyList, string[] ExceptionList)
		{
			try 
			{
				//If the file is in the exception list, return true;
				if (IsException(assemblyLocation,ExceptionList))
					return true;

				Assembly A = Assembly.LoadFrom(assemblyLocation);
				return (CompareKeys(A.GetName().GetPublicKey(),keyList));
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  Key check failed for : " + assemblyLocation);
				Debug.WriteLine("APPMANAGER:  " + e.ToString());

				//The file isn't an assembly & not in the exception list
				return false;
			}
		}

		//**************************************************************
		// IsException() - static helper function	
		//**************************************************************
		public static bool IsException(string FilePath, string[] ExceptionList)
		{
			//Empty ExceptionList case
			if (ExceptionList == null)
				return false;

			foreach (string exceptionFile in ExceptionList)
			{
				if (Path.GetFileName(FilePath).ToLower(new CultureInfo("en-US"))
					== exceptionFile.ToLower(new CultureInfo("en-US")))
				{
					return true;
				}
			}
			return false;
		}

		//**************************************************************
		// CompareKeys() - static helper function	
		//**************************************************************
		public static bool CompareKeys(byte[] assemblyKey, byte[][]validKeys)
		{
			try 
			{
				ASCIIEncoding AE = new ASCIIEncoding();

				foreach (byte[] Key in validKeys)
				{
					if (AE.GetString(Key) == AE.GetString(assemblyKey))
						return true;
				}
				return false;
			} 
			catch (Exception e)
			{
				Debug.WriteLine("APPMANAGER:  :" + e.ToString());
				return false;
			}
		}
	}
}
