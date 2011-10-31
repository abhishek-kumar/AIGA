using System;
using System.Collections.Generic;
using System.Text;

namespace eduGRID_Manager.UI
{
    public class ControlElement : IItem
    {
        public bool on_Focus = false;

        private readonly string title;
        private readonly string description;


        public string Title { get { return title; } }
        public string Description { get { return description; } }

        public ControlElement(string t, string d)
        {
            title = t;
            description = d;
        }

    }
}
