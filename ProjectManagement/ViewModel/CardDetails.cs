using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectManagement.ViewModel
{
    public class CardDetails
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public string Notes { get; set; }

        public int Column { get; set; }
        public List<SelectListItem> Columns { get; set; } = new List<SelectListItem>();
    }
}
