﻿using ProjectManager.Core.ViewModels.Ticket.TicketChange;
using ProjectManager.Core.ViewModels.Ticket.TicketComment;

namespace ProjectManager.Core.ViewModels.Ticket
{
    public class TicketDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SubmitterId { get; set; }

        public string Submitter { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid ProjectId { get; set; }

        public string Project { get; set; }

        public string AssignedEmployeeId { get; set; }

        public string AssignedEmployee { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public ICollection<TicketCommentViewModel> Comments { get; set; }

        public ICollection<TicketChangeViewModel> History { get; set; }
    }
}
