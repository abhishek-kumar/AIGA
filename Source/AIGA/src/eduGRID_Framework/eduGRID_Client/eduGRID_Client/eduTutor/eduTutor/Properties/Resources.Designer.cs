﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eduTutor.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("eduTutor.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;rss version=&quot;2.0&quot;&gt;&lt;channel&gt;&lt;title&gt;RSS Feed Not Available&lt;/title&gt;&lt;link&gt;http://go.microsoft.com/fwlink/?LinkId=49535&lt;/link&gt;&lt;description&gt;The RSS feed could not be loaded.&lt;/description&gt;&lt;language&gt;en-us&lt;/language&gt;&lt;ttl&gt;1440&lt;/ttl&gt;&lt;item&gt;&lt;title&gt;You may not be connected to the internet.&lt;/title&gt;&lt;description&gt;If you are trying to use an RSS feed on the internet check your Internet connection.&lt;/description&gt;&lt;link&gt;http://go.microsoft.com/fwlink/?LinkId=49535&lt;/link&gt;&lt;/item&gt;&lt;item&gt;&lt;title&gt;Try selecting a different RSS feed.&lt;/ti [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DefaultRSSText {
            get {
                return ResourceManager.GetString("DefaultRSSText", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap SSaverBackground {
            get {
                object obj = ResourceManager.GetObject("SSaverBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap SSaverBackground2 {
            get {
                object obj = ResourceManager.GetObject("SSaverBackground2", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
