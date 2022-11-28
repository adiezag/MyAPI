using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
namespace MyNewAPI.Models
{
    public class TypesOfAdditive_
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeOfAdditive { get; set; }
    }
}
