using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Threading;

namespace MSR.LST.RTDocuments
{
    /// <summary>
    /// Navigation commands for RTObjects.
    /// </summary>

    [Serializable]
    public class RTNodeChanged
    {
        public Guid OrganizationNodeIdentifier;
        public object Extension;

        public RTNodeChanged ( Guid organizationNodeIdentifier, DateTime changedTime, object extension )
        {
            OrganizationNodeIdentifier = organizationNodeIdentifier;
            Extension = extension;
        }

        public override string ToString()
        {
            return "RTNodeChanged " +
                "{ OrganizationNodeIdentifier: " + OrganizationNodeIdentifier.ToString() +
                " }";
        }
    }

    [Serializable]
    public class RTPageAdd
    {
        public RTPageAdd() {}
        public RTPageAdd(Page page)
        {
            TOCNode = new TOCNode();
            TOCNode.ResourceIdentifier = page.Identifier;
            TOCNode.Resource = page;
            TOCNode.Title = "New Page";
            // Not adding in here for now to keep out RTDocumentHelper dependency
            // Should move GetThumbnailFromImage over to another utility library than RTDocumentUtilities...
            //TOCNode.Thumbnail = RTDocumentHelper.GetThumbnailFromImage(page.Image);
            Page = page;
        }

        public TOCNode TOCNode;
        public Page Page;

        /// <summary>
        /// Parent TOCNode where add takes place.  Call ParentTOCNode.Children.Add
        /// </summary>
        /// <remarks>
        /// This should be Guid.Empty for a new page at the root level, which should always be so for a flat TOC.
        /// </remarks>
        public Guid ParentTOCNodeIdentifier = Guid.Empty;
        /// <summary>
        /// Position in relation to the sibling nodes in the hierarchy.  If this is set as Guid.Empty, the page is added at the end of the current level of hierarchy.
        /// </summary>
        public Guid PreviousSiblingIdentifier = Guid.Empty;

        public override string ToString()
        {
            return "RTPageAdd " +
                "{ TOCNode.Identifier: " + TOCNode.Identifier.ToString() +
                ", Page.Identifier: " + Page.Identifier.ToString() +
                ", ParentTOCNodeIdentifier: " + ParentTOCNodeIdentifier.ToString() +
                ", PreviousSiblingIdentifier: " + PreviousSiblingIdentifier.ToString() +
                " }";
        }
    }

    /// <summary>
    /// RTPageErase is a object that inform to erase all the strokes on a given page 
    /// </summary>
    [Serializable]
    public class RTPageErase
    {
        #region Members
        /// <summary>
        /// Unique identifier of page. 
        /// </summary>
        private Guid pageIdentifierMember = Guid.Empty;
        #endregion Members

        #region Constructor
        /// <summary>
        /// Ctor of RTPageErase that uses a page identifier.
        /// </summary>
        /// <param name="pageIdentifier">Unique identifier of page in which you want to erase all the strokes</param>
        RTPageErase ( Guid pageIdentifier )
        {
            pageIdentifierMember = pageIdentifier;
        }
        #endregion Constructor

        #region Public
        /// <summary>
        /// Accessor of the PageIdentifier 
        /// </summary>
        public Guid PageIdentifier
        {
            get{return pageIdentifierMember;}
            set{pageIdentifierMember = value;}
        }
        #endregion Public

        /// <summary>
        /// Give the information about RTPageErase
        /// </summary>
        /// <returns>A string containing the page identifier</returns>
        public override string ToString()
        {
            return "RTPageErase { PageIdentifier: " + pageIdentifierMember.ToString() + " }";
        }
    }

    /* Future messages, not included in v1.0 of RTObjects
    RTNavigationScrollLayer ( Guid pageIdentifier, Guid layerIdentifier, double position, double extent )
    RTNavigationEraseLayer ( Guid pageIdentifier, Guid layerIdentifier )
    RTNavigationErasePage ( Guid pageIdentifier) // all layers on page
    RTNavigationEraseAll() // all layers & pages
    RTNavigationScreenConfiguration ( ? ) // scale to show notes on side
    */


}
