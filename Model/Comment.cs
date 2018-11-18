using System;
using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models
{
    public class Comment : BaseEntity
    {
        [MaxLength(255)]
        public string Theme { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}