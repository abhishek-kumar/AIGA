#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	XmlStringWriter.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
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
using System.Xml;
using System.IO;

namespace Alchemi.Core.Utility
{
	/// <summary>
	/// This class is used to read in / write out XML data from / in memory.
	/// </summary>
    public class XmlStringWriter
    {
        private MemoryStream _Ms;
        private XmlTextWriter _Writer;

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Creates an instance of the XML writer capable of writing text
		/// </summary>
        public XmlTextWriter Writer
        {
            get { return _Writer; } 
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Creates an instance of an XML writer capable of writing ASCII text with indented format.
		/// </summary>
        public XmlStringWriter()
        {
            _Ms = new MemoryStream();
            _Writer = new XmlTextWriter(_Ms, System.Text.Encoding.ASCII);
            _Writer.Formatting = Formatting.Indented;
            _Writer.Indentation = 2;
        }
    
        //-----------------------------------------------------------------------------------------------    
    
		/// <summary>
		///	Returns the XML written to memory (so far) by the writer.
		/// </summary>
		/// <returns></returns>
        public string GetXmlString()
        {
            _Writer.Flush();
            _Ms.Position = 0;

            return (new StreamReader(_Ms)).ReadToEnd();
        }
    }
}
