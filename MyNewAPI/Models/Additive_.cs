using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyNewAPI.Models
{
    
    public class Additive_
    {

        [Key]
        public int AdditiveId { get; set; }
        public string Additive { get; set; }
        
        public TypesOfAdditive_? TypesofAdditive_ { get; set; }
    }
}



