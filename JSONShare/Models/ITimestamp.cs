using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONShare.Models
{
    public interface ITimestamp
    {
        DateTime? Created { get; set; }
        DateTime? Updated { get; set; }
        DateTime? Viewed { get; set; }
    }
}
