﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MochiApi.Common.Enum;

namespace MochiApi.Models
{
    [Table("Notification")]
    public class Notification
    {
        public Notification()
        {
            Description = null!;
            CreatedAt = DateTime.UtcNow;
        }
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public NotificationType Type { get; set; }
        public int UserId{ get; set; }
        public User? User{ get; set; }
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }
        public int? TransactionId { get; set; }
        public Transaction? Transaction { get; set; }
        public int? BudgetId { get; set; }
        public Budget? Budget { get; set; }
        public DateTime CreatedAt{ get; set; }
    }

}
