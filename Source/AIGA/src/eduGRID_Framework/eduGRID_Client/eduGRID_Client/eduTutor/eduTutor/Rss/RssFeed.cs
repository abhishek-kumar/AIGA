using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace eduTutor.Rss
{
    /// <summary>
    /// Representation of an RSS element in a RSS 2.0 XML document
    /// </summary>
    public class RssFeed
    {
        private List<RssChannel> channels;
        public IList<RssChannel> Channels { get { return channels.AsReadOnly(); } }
        public RssChannel MainChannel { get { return Channels[0]; } }

        /// <summary>
        /// Private constructor to be used with factory pattern.  
        /// </summary>
        /// <param name="xmlNode">An XML block containing the RSSFeed content.</param>
        private RssFeed(XmlNode xmlNode)
        {
            channels = new List<RssChannel>();

            // Read the <rss> tag
            XmlNode rssNode = xmlNode.SelectSingleNode("rss");

            // For each <channel> node in the <rss> node
            // add a channel.
            XmlNodeList channelNodes = rssNode.ChildNodes;
            foreach (XmlNode channelNode in channelNodes)
            {
                RssChannel newChannel = new RssChannel(channelNode);
                channels.Add(newChannel);
            }
        }

        /// <summary>
        /// Factory that constructs RSSFeed objects from a uri pointing to a valid RSS 2.0 XML file.
        /// </summary>
        /// <exception cref="System.Net.WebException">Occurs when the uri cannot be located on the web.</exception>
        /// <param name="uri">The URL to read the RSS feed from.</param>
        public static RssFeed FromUri(string uri)
        {
            XmlDocument xmlDoc;
            WebClient webClient = new WebClient();
            using (Stream rssStream = webClient.OpenRead(uri))
            {
                TextReader textReader = new StreamReader(rssStream);
                XmlTextReader reader = new XmlTextReader(textReader);
                xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);
            }
            return new RssFeed(xmlDoc);
        }

        /// <summary>
        /// Factory that constructs RssFeed objects from the text of an RSS 2.0 XML file.
        /// </summary>
        /// <param name="rssText">A string containing the XML for the RSS feed.</param>
        public static RssFeed FromText(string rssText)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rssText);
            return new RssFeed(xmlDoc);
        }
    }
}