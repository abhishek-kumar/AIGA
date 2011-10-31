using System;
using System.Xml;
using eduTutor.UI;

namespace eduTutor.Rss
{
    /// <summary>
    /// Representation of an Item element in an RSS 2.0 XML document.
    /// Zero or more RssItems are contained in an RssChannel.
    /// </summary>
    public class RssItem : IItem
    {
        private readonly string title;
        private readonly string description;
        private readonly string link;

        public string Title { get { return title; } }
        public string Description { get { return description; } }
        public string Link { get { return link; } }


        /// <summary>
        /// Build an RSSItem from an XmlNode representing an Item element inside an RSS 2.0 XML document.
        /// </summary>
        /// <param name="itemNode"></param>
        internal RssItem(XmlNode itemNode)
        {
            XmlNode selected;
            selected = itemNode.SelectSingleNode("title");
            if (selected != null)
                title = selected.InnerText;

            selected = itemNode.SelectSingleNode("description");
            if (selected != null)
                description = selected.InnerText;

            selected = itemNode.SelectSingleNode("link");
            if (selected != null)
                link = selected.InnerText;
        }
    }
}