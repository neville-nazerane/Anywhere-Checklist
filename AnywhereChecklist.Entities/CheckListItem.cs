using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnywhereChecklist.Entities
{
    public class CheckListItem
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Content { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public int? CheckListId { get; set; }
        public CheckList CheckList { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
