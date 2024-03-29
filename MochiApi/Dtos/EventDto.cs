﻿using MochiApi.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace MochiApi.Dtos
{
    public class EventDto : BaseEntityDto
    {
        public EventDto()
        {
            Name = null!;
            Icon = null!;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public long SpentAmount { get; set; }
        public DateTime? EndDate { get; set; }
        public int CreatorId { get; set; }
        public UserDto? Creator { get; set; }
        public int? WalletId { get; set; }
        public WalletDto? Wallet { get; set; }
        public bool IsFinished { get; set; }
    }
}
