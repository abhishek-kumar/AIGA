using System;
using System.Collections.Generic;
using System.Text;

namespace eduGRID_ManagerApp.UI
{
    /// <summary>
    /// A generealization of an item with a <c>Description</c> and <c>Title</c>.
    /// Any implmentation of IItem can be rendered using the ItemListView and ItemDescriptionView types.
    /// </summary>
    public class IItem
    {

        public string description;
        public string title;
        
        public string Description 
        { 
            get { return description; }
            set { description = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public IItem(string T, String D)
        {
            description = D;
            title = T;
        }
    }
}
