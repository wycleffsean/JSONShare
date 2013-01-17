using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JSONShare.Models
{
    public class JsonItem
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Json { get; set; }
    }
}
