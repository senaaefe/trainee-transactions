//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_SEFE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class admin
    {
        [Required(ErrorMessage = "Kullan�c� girin!")]
        public string kullanici { get; set; }

        [Required(ErrorMessage = "�ifre girin!")]
        public string sifre { get; set; }
    }
}
