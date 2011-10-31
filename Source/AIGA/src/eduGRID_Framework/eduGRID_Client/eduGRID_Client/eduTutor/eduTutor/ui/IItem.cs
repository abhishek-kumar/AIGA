using System;
using System.Collections.Generic;
using System.Text;

namespace eduTutor.UI
{
    /// <summary>
    /// A generealization of an item with a <c>Description</c> and <c>Title</c>.
    /// Any implmentation of IItem can be rendered using the ItemListView and ItemDescriptionView types.
    /// </summary>
    public interface IItem
    {
        string Description { get; }
        string Title { get; }
    }
}
