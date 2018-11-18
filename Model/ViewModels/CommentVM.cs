using System.ComponentModel.DataAnnotations;

namespace moneygoes.Models.ViewModels
{
    public class CommentVM : IViewModel
    {
        [MaxLength(255)]
        public string Theme { get; set; }
        public string Text { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}