using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using MSR.LST.RTDocuments;


namespace MSR.LST.RTDocuments.Utilities
{
    /// <summary>
    /// Summary description for PPTConversion.
    /// </summary>
    public class PPTConversion
    {
        private static BinaryFormatter bf = new BinaryFormatter();
        private static System.CodeDom.Compiler.TempFileCollection tfc = new System.CodeDom.Compiler.TempFileCollection();

        public static RTDocument PPT2RTDocument(string pptFilename)
        {
            //Pri2: Investigate where BasePath is and where we should be putting it in more depth.
            //      Concerned that we're creating directories there that never get cleaned up...
            if (!Directory.Exists(tfc.BasePath))
                Directory.CreateDirectory(tfc.BasePath);
            // Initialize PowerPoint app
            ApplicationClass ppt = new ApplicationClass();

            // Open the PPT file
            Presentation presentation = ppt.Presentations.Open(pptFilename, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
            Slides slides = presentation.Slides;

            // Set up the document
            RTDocument rtDoc = new RTDocument();
            rtDoc.Identifier = Guid.NewGuid();
            rtDoc.Metadata.Title = GetPresentationProperty(presentation, "Title");
            rtDoc.Metadata.Creator = GetPresentationProperty(presentation, "Author");

            // Create shared MemoryStream to minimize mem usage
            MemoryStream ms = new MemoryStream();

            //Iterate through the pages
            int i = 0;
            foreach(Slide s in slides)
            {
                // Set the page properties
                Page p = new Page();
                p.Identifier = Guid.NewGuid();
                p.Image = GetSlideImage(s, ms);
                if (p.Image is Metafile)
                {
                    p.MimeType = "image/x-wmf";
                }
                if (p.Image is Bitmap)
                {
                    p.MimeType = "image/png";
                }
                rtDoc.Resources.Pages.Add(p.Identifier, p);

                // TODO, slice in RegionBuilder code from Presenter work...

                // Set the TOCNode properties for the page
                TOCNode tn = new TOCNode();
                tn.Title = GetSlideTitle(s);
                tn.Resource = p;
                tn.ResourceIdentifier = p.Identifier;
                //Pri2: Shouldn't this be a byte[] containing the PNG stream instead of a System.Drawing.Image?
                tn.Thumbnail = RTDocumentHelper.GetThumbnailFromImage(p.Image);
                rtDoc.Organization.TableOfContents.Add(tn);
                i++;
            }

            // Close PPT
            presentation.Close();
            if (ppt.Presentations.Count == 0)
            {
                ppt.Quit();
            }

            ppt = null;

            tfc.Delete();

            return rtDoc;
        }

        private static string GetPresentationProperty(Presentation pres, string propertyName)
        {
            // Get the Document Properties
            object oDocBuiltInProps = pres.BuiltInDocumentProperties;

            // Get the property object
            Type typeDocBuiltInProps = oDocBuiltInProps.GetType();
            object oDocProp = typeDocBuiltInProps.InvokeMember("Item", 
                BindingFlags.Default | 
                BindingFlags.GetProperty, 
                null,oDocBuiltInProps, 
                new object[] {propertyName} );

            // Get the property value and return it
            Type typeDocProp = oDocProp.GetType();
            return typeDocProp.InvokeMember("Value", 
                BindingFlags.Default |
                BindingFlags.GetProperty,
                null,oDocProp,
                new object[] {} ).ToString();
        }

        private static string GetSlideTitle(Slide s)
        {
            // If the slide has a Title shape, use that text
            if (s.Shapes.HasTitle == Microsoft.Office.Core.MsoTriState.msoTrue)
                return CleanString(s.Shapes.Title.TextFrame.TextRange.Text);
            else
            {
                if (s.Shapes.Count > 0)
                {
                    Microsoft.Office.Interop.PowerPoint.Shapes shapes = s.Shapes;
                    IEnumerator iEN = shapes.GetEnumerator();
                    // Return the first shape that has a TextFrame
                    while (iEN.MoveNext())
                    {
                        Microsoft.Office.Interop.PowerPoint.Shape shape = (Microsoft.Office.Interop.PowerPoint.Shape)iEN.Current;
                        if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                        {
                            if (shape.TextFrame.TextRange.Text != "")
                                return CleanString(shape.TextFrame.TextRange.Text);
                        }
                    }
                }

                // If there are no shapes with a Text Frame
                // -or- If there are no Shapes in the Slide at all, 
                //   return the Slide Name
                return s.Name;
            }
        }

        /// <summary>
        ///  Make sure all characters in a string are printable; replace any out of range characters by a space
        /// </summary>
        private static string CleanString(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (! (Char.IsLetterOrDigit(c) || Char.IsPunctuation(c) || Char.IsSymbol(c)))
                    sb[i] = ' ';

            }
            return sb.ToString();
        }


        private static Image GetSlideImage(Slide s, MemoryStream ms)
        {
            // Export the slide to a temporary file
            string filename = tfc.BasePath + "\\" + Guid.NewGuid().ToString() + ".emf";
            tfc.AddFile(filename, false);
            s.Export(filename, "EMF", 0, 0);

            // Create a Metafile from that file and serialize it for transport
            // Pri2: Shouldn't this just be the EMF stream bytes, more cross platform?
            Image image = Image.FromFile(filename);

            // Check for size overage and downconvert to JPG if EMF is too large
            // Note: By default EMF is the best, but we switch to JPG after a larger size

            // TODO: The max EMF size should be read from the UI or config file
            if (ImageSize(image, ms) > 250000)
            {
                image.Dispose();

                filename = tfc.BasePath + "\\" + Guid.NewGuid().ToString() + ".jpeg";
                tfc.AddFile(filename, false);
                // TODO: The width/height should be read from the UI or config file
                s.Export(filename, "JPG", 1200, 900);
                image = Image.FromFile(filename);

                // TODO: EMF is better quality than JPG, so we have to ensure that we are not 
                // creating a bigger file with less quality
            }

            return image;
        }

        private static long ImageSize(Image image, MemoryStream ms)
        {
            // Now we need to know how big this is when it is serialized
            ms.Position = 0;
            bf.Serialize(ms, new RTImage(image));
            return ms.Position;
        }

    }
}
