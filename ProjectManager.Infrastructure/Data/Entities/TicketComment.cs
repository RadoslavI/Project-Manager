﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Infrastructure.Data.Entities
{
    public class TicketComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CommentConstants.MessageMaxLength)]
        public string Message { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CommenterId { get; set; }

        [ForeignKey(nameof(CommenterId))]
        public Employee Commenter { get; set; }

        [Required]
        public Guid TicketId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
