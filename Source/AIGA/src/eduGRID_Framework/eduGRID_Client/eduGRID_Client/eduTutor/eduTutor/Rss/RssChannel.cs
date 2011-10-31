using System;
using System.Collections.Generic;
using System.Xml;

namespace eduTutor.Rss
{
    /// <remarks>
    /// Representation of a Channel element in an RSS 2.0 XML document.
    /// One or more RssChannels are contained in an RssFeed.
    /// </remarks>
    public class RssChannel
    {
        private readonly string title;
        private readonly string link;
        private List<RssItem> items;

        public string Title { get { return title; } }
        public string Link { get { return link; } }
        public IList<RssItem> Items { get { return items.AsReadOnly(); } }

        /// <summary>
        /// Build an RSSChannel from an XmlNode representing a Channel element inside an RSS 2.0 XML document.
        /// </summary>
        /// <param name="channelNode"></param>
        internal RssChannel(XmlNode channelNode)
        {
            items = new List<RssItem>();
            title = channelNode.SelectSingleNode("title").InnerText;
            link = channelNode.SelectSingleNode("link").InnerText;

            XmlNodeList itemNodes = channelNode.SelectNodes("item");
            foreach (XmlNode itemNode in itemNodes)
            {
                items.Add(new RssItem(itemNode));
            }
        }
    }
}
