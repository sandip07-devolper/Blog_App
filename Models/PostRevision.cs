//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostRevision
    {
        public int RevisionID { get; set; }
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime EditedDate { get; set; }
    
        public virtual BlogPost BlogPost { get; set; }
    }
}
