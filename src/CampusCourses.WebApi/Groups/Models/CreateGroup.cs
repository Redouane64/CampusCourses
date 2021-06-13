using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCourses.WebApi.Groups.Models
{
    public class CreateGroup
    {
        [Required]
        public string Name { get; set; }
    }
}
