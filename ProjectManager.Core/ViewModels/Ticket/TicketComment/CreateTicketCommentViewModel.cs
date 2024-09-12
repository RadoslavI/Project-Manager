using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.Constants;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Core.ViewModels.Ticket.TicketComment
{
    public class CreateTicketCommentViewModel
    {
        [Required]
        public Guid TicketId { get; set; }

        [Required]
        [StringLength(CommentConstants.MessageMaxLength,
            MinimumLength = CommentConstants.MessageMinLength)]
        [RegularExpression(ValidationRegex.DescriptionAndMessageRegex,
            ErrorMessage = "Contains unallowed characters")]
        public string Message { get; set; }
    }
}
