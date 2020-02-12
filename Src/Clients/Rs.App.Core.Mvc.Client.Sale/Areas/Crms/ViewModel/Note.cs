using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Areas.Crms.ViewModel
{
    public class Note
    {
        public Guid ContactId { get; set; }
        public string ShortNote { get; set; }
        public Guid? ParentNoteId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool? IsDeleted { get; set; } = true;
    }
}
