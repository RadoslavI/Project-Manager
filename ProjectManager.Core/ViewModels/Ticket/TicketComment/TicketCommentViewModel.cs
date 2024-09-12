namespace ProjectManager.Core.ViewModels.Ticket.TicketComment
{
    public class TicketCommentViewModel
    {
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CommenterId { get; set; } = null!;

        public string Commenter { get; set; } = null!;
    }
}
