using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace MyAPI.Models
{
    public class Additive
    {
        public int Id { get; set; }
        public string AdditiveName { get; set; }
        public bool WaterBased { get; set; }
        public bool OilBased { get; set; }
        public string Info { get; set; }

        //public AdditiveType? AdditiveType { get; set; }


        public int AdditiveTypeId { get; set; }
        
        private AdditiveType? AdditiveType { get; set; }
    }

}
