#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	Utils.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au), Rajkumar Buyya (raj@csse.unimelb.edu.au) , and Krishna Nadiminti (kna@csse.unimelb.edu.au) 
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Alchemi.Core.Utility
{
	public enum DateTimeInterval
	{
		Tick,
		Millisecond,
		Second,
		Minute,
		Hour,
		Day,
		Week,
		Fortnight,
		Month,
		Quarter,
		Year
	}

	/// <summary>
	/// This class contains some convenient utility function used in various classes in the Alchemi framework
	/// </summary>
    public class Utils
    {
		/// <summary>
		/// Prints the message with a stack trace to the console.
		/// </summary>
		/// <param name="msg">message to be printed</param>
        public static void Trace(string msg)
        {
            StackTrace st = new StackTrace();
            Console.WriteLine("{0}.{1} :: {2}", st.GetFrame(1).GetMethod().ReflectedType, st.GetFrame(1).GetMethod().Name, msg);
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Serializes an object graph to an in-memory byte-array using the binary formatter.
		/// </summary>
		/// <param name="objGraph">The object / object graph to be serialized</param>
		/// <returns>byte-array after serialization</returns>
        public static byte[] SerializeToByteArray(Object objGraph)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objGraph);
            return stream.ToArray();
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Desserializes a byte array using the binary formatter to return the object after deserialization.
		/// </summary>
		/// <param name="buffer">byte array to be deserialized</param>
		/// <returns>result object after deserialization</returns>
        public static Object DeserializeFromByteArray(byte[] buffer) 
        {
            Stream stream = new MemoryStream(buffer);
            BinaryFormatter formatter = new BinaryFormatter();
            return(formatter.Deserialize(stream));
        }
    
        //-----------------------------------------------------------------------------------------------    
    
		/// <summary>
		/// Write the given byte-array to a file
		/// </summary>
		/// <param name="fileLocation">file name to write the data to</param>
		/// <param name="byteArray">byte-array to be written into the file</param>
        public static void WriteByteArrayToFile(string fileLocation, byte[] byteArray)
        {
            Stream stream = new FileStream (fileLocation, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(byteArray, 0, byteArray.Length);
            writer.Close();
            stream.Close();
        }

        //-----------------------------------------------------------------------------------------------        
    
		/// <summary>
		/// Reads the file at the specified location and returns a byte-array.
		/// </summary>
		/// <param name="fileLocation">location of the file to read</param>
		/// <returns>byte-array representing the contents of the file</returns>
        public static byte[] ReadByteArrayFromFile(string fileLocation)
        {
            byte[] Contents;
            FileStream file = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
            int size = (int) file.Length;
            BinaryReader reader = new BinaryReader(file);
            Contents = new byte[size];
            reader.Read(Contents, 0, size);
            reader.Close(); 
            file.Close();
            return Contents;
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Serializes an object graph to a disk file.
		/// </summary>
		/// <param name="objGraph">The object / objectGraph to be serialized</param>
		/// <param name="fileLocation">filename to store the serialized object graph</param>
        public static void SerializeToFile(object objGraph, string fileLocation)
        {
            WriteByteArrayToFile(fileLocation, SerializeToByteArray(objGraph));
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Desserializes a file using the binary formatter to return the object after deserialization.
		/// Throws an Exception if the File cannot be found / read.
		/// </summary>
		/// <param name="fileLocation">location of file to be deserialized</param>
		/// <returns>result object after deserialization</returns>
        public static object DeserializeFromFile(string fileLocation)
        {
			return DeserializeFromByteArray(ReadByteArrayFromFile(fileLocation));
        }
    
        //-----------------------------------------------------------------------------------------------    
		/// <summary>
		/// Converts the input boolean val to an int value, used in SQL queries.
		/// </summary>
		/// <param name="val">value to be converted to int</param>
		/// <returns></returns>
        public static int BoolToSqlBit(bool val)
        {
            return (val ? 1 : 0);
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Writes the given base64-data  to a file
		/// Throws an Exception if the File cannot written.
		/// </summary>
		/// <param name="fileLocation">filename to write the data to</param>
		/// <param name="base64EncodedData">the base64-encoded data to be written into the file</param>
        public static void WriteBase64EncodedToFile(string fileLocation, string base64EncodedData)
        {
            WriteByteArrayToFile(fileLocation, Convert.FromBase64String(base64EncodedData));
        }
    
        //-----------------------------------------------------------------------------------------------    
    
		/// <summary>
		/// Reads a base64-encoded file and returns the contents as a string.
		/// </summary>
		/// <param name="fileLocation">location of the file to read</param>
		/// <returns></returns>
        public static string ReadBase64EncodedFromFile(string fileLocation)
        {
            return Convert.ToBase64String(ReadByteArrayFromFile(fileLocation));
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Reads a text file and returns the contents as a string
		/// </summary>
		/// <param name="fileLocation">location of the file to read</param>
		/// <returns>string representing the file contents</returns>
        public static string ReadStringFromFile(string fileLocation)
        {
            string contents;
            using (StreamReader sr = new StreamReader(fileLocation)) 
            {
                contents = sr.ReadToEnd();
            }
            return contents;
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Gets the version of the current assembly.
		/// </summary>
        public static string AssemblyVersion
        {
            get
            {
                Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return v.Major + "." + v.Minor + "." + v.Build;
            }
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Prompts the user for a value, reads it from the console and returns it 
		/// </summary>
		/// <param name="prompt">Prompt given to the user</param>
		/// <param name="defaultVal">default value is none is input by the user</param>
		/// <returns></returns>
        public static string ValueFromConsole(string prompt, string defaultVal)
        {
            Console.Write("{0} [default={1}] : ", prompt, defaultVal);
            string val = Console.ReadLine();
            if (val == "")
            {
                return defaultVal;
            }
            else
            {
                return val;
            }
        }


		/// <summary>
		/// same common params similar to the VBScript DateDiff: 
		/// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/script56/html/vsfctdatediff.asp
		///   /*
		///    * Sample Code:
		///    * System.DateTime dt1 = new System.DateTime(1974,12,16);
		///    * System.DateTime dt2 = new System.DateTime(1973,12,16);
		///    * double diff = DateDiff(DateTimeInterval.Day, dt1, dt2);
		///    * 
		///    */
		/// </summary>
		/// <param name="howtocompare"></param>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <returns></returns>
		//adapted from http://authors.aspalliance.com/nothingmn/default.aspx?whichpoll=nothingmn_117&aid=117
		public static double DateDiff(DateTimeInterval howtocompare, System.DateTime startDate, System.DateTime endDate) 
		{
			double diff=0;
			try 
			{
				System.TimeSpan TS = new System.TimeSpan(startDate.Ticks-endDate.Ticks);
				switch (howtocompare) 
				{
					case DateTimeInterval.Tick:
						diff = Convert.ToDouble(TS.Ticks);
						break;
					case DateTimeInterval.Millisecond:
						diff = Convert.ToDouble(TS.TotalMilliseconds);
						break;
					case DateTimeInterval.Second:
						diff = Convert.ToDouble(TS.TotalSeconds);
						break;
					case DateTimeInterval.Minute:
						diff = Convert.ToDouble(TS.TotalMinutes);
						break;
					case DateTimeInterval.Hour:
						diff = Convert.ToDouble(TS.TotalHours);
						break;
					case DateTimeInterval.Day:
						diff = Convert.ToDouble(TS.TotalDays);
						break;
					case DateTimeInterval.Week:
						diff = Convert.ToDouble(TS.TotalDays/7);
						break;
					case DateTimeInterval.Fortnight:
						diff = Convert.ToDouble(TS.TotalDays/15);
						break;
					case DateTimeInterval.Month:
						diff = Convert.ToDouble((TS.TotalDays/365)/12);
						break;
					case DateTimeInterval.Quarter:
						diff = Convert.ToDouble((TS.TotalDays/365)/4);
						break;
					case DateTimeInterval.Year:
						diff = Convert.ToDouble(TS.TotalDays/365);
						break;
				}

			} 
			catch 
			{
				diff = -1;
			}
			return diff;
		}

		public static string MakeSqlSafe(string inString)
		{
			return inString.Replace("'","").Replace("\"","");
		}

		public static bool IsSqlSafe(string text)
		{
			//if the result returned by MakeSqlSafe is same as the original string, then it is safe.
			return (text == MakeSqlSafe(text));
		}

		public static object GetDbValue(object value)
		{
			object val = null;
			if (val!=DBNull.Value)
				val = value;
			return val;
		}
    }
}
