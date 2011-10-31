#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	Utils.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright � 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  David Cumps, Krishna Nadiminti (kna@csse.unimelb.edu.au)
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
using System.Security.Cryptography;
using System.Text;

namespace Alchemi.Core.Utility {

	// from the tutorial at http://www.developerfusion.co.uk/show/4601/
	// original author blog: http://weblogs.asp.net/CumpsD

	/// <summary>Class used to generate and check hashes.</summary>
	public class HashUtil {
		/// <summary></summary>
		public HashUtil() { }
		
		#region Hash Choices
		/// <summary>The wanted hash function.</summary>
		public enum HashType :int {
			/// <summary>MD5 Hashing</summary>
			MD5,
			/// <summary>SHA1 Hashing</summary>
			SHA1,
			/// <summary>SHA256 Hashing</summary>
			SHA256,
			/// <summary>SHA384 Hashing</summary>
			SHA384,
			/// <summary>SHA512 Hashing</summary>
			SHA512
		} /* HashType */
		#endregion
		
		#region Public Methods
		/// <summary>Generates the hash of a text.</summary>
		/// <param name="strPlain">The text of which to generate a hash of.</param>
		/// <param name="hshType">The hash function to use.</param>
		/// <returns>The hash as a hexadecimal string.</returns>
		public static string GetHash(string strPlain, HashType hshType) {
			string strRet;
			switch (hshType) {
				case HashType.MD5: strRet = GetMD5(strPlain);	break;
				case HashType.SHA1: strRet = GetSHA1(strPlain);	break;
				case HashType.SHA256: strRet = GetSHA256(strPlain); break;
				case HashType.SHA384: strRet = GetSHA384(strPlain); break;
				case HashType.SHA512: strRet = GetSHA512(strPlain); break;
				default: strRet = "Invalid HashType"; break;
			}
			return strRet;
		} /* GetHash */
		
		/// <summary>Checks a text with a hash.</summary>
		/// <param name="strOriginal">The text to compare the hash against.</param>
		/// <param name="strHash">The hash to compare against.</param>
		/// <param name="hshType">The type of hash.</param>
		/// <returns>True if the hash validates, false otherwise.</returns>
		public static bool CheckHash(string strOriginal, string strHash, HashType hshType) {
			string strOrigHash = GetHash(strOriginal, hshType);
			return (strOrigHash == strHash);
		} /* CheckHash */
		#endregion
		
		#region Hashers
		private static string GetMD5(string strPlain) {
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			MD5 md5 = new MD5CryptoServiceProvider();
			string strHex = "";
			
			HashValue = md5.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) {
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} /* GetMD5 */
		
		private static string GetSHA1(string strPlain) {
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA1Managed SHhash = new SHA1Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) {
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} /* GetSHA1 */
		
		private static string GetSHA256(string strPlain) {
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA256Managed SHhash = new SHA256Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) {
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} /* GetSHA256 */
		
		private static string GetSHA384(string strPlain) {
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA384Managed SHhash = new SHA384Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) {
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} /* GetSHA384 */
		
		private static string GetSHA512(string strPlain) {
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
			SHA512Managed SHhash = new SHA512Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash(MessageBytes);
			foreach(byte b in HashValue) {
				strHex += String.Format("{0:x2}", b);
			}
			return strHex;
		} /* GetSHA512 */
		#endregion
	} /* Hash */
} /* Hash */