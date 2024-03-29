﻿using MochiApi.Models;
using System.ComponentModel.DataAnnotations;
using static MochiApi.Common.Enum;
using static System.Net.WebRequestMethods;

namespace MochiApi.Dtos
{
    public class NotificationDto
    {
        public NotificationDto()
        {
            Description = null!;
        }
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public NotificationType Type { get; set; }
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public int? WalletId { get; set; }
        public WalletDto? Wallet { get; set; }
        public int? TransactionId { get; set; }
        public TransactionDto? Transaction { get; set; }
        public int? BudgetId { get; set; }
        public bool IsSeen{ get; set; }
        public BudgetDto? Budget { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
