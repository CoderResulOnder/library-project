//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace deneme.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bookLocation
    {
        public int barcodeNo { get; set; }
        public int floorNumber { get; set; }
        public string hallNumber { get; set; }
        public string shelfNumber { get; set; }
        public string queueNumber { get; set; }
    
        public virtual book book { get; set; }
    }
}
