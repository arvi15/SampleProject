//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class PNL
    {
        public int Id { get; set; }
        public string pnlType { get; set; }
        [Required(ErrorMessage = "Please enter user Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "enter Key ")]
        public string key { get; set; }
        [Required(ErrorMessage = "enter Booking ID")]
        public string booking { get; set; }
        public int FileListId { get; set; }
    
        public virtual FileList FileList { get; set; }
    }
}
