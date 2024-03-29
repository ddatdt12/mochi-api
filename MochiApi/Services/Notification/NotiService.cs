﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MochiApi.Dtos;
using MochiApi.Dtos.Auth;
using MochiApi.Error;
using MochiApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MochiApi.Services
{
    public class NotiService : INotiService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public DataContext _context { get; set; }

        public NotiService(IConfiguration configuration, DataContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Notification>> GetNotifications(int userId)
        {
            var notis = await _context.Notifcations.Where(no => no.UserId == userId)
            .OrderByDescending(c => c.CreatedAt).Include(c => c.Wallet).ToListAsync();

            return notis;
        }
        public async Task<Notification> CreateNoti(CreateNotificationDto notiDto)
        {
            var noti = _mapper.Map<Notification>(notiDto);

            await _context.Notifcations.AddAsync(noti);

            await _context.SaveChangesAsync();
            return noti;
        }
        public async Task<IEnumerable<Notification>> CreateListNoti(IEnumerable<CreateNotificationDto> notiDto, bool saveChanges = false)
        {
            var notis = _mapper.Map<IEnumerable<Notification>>(notiDto);

            await _context.Notifcations.AddRangeAsync(notis);
            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }

            return notis;
        }

        public async Task MarkSeen(int id)
        {
            var noti = await _context.Notifcations.Where(n => n.Id == id).FirstOrDefaultAsync();

            if (noti == null)
            {
                throw new ApiException("Notification not found", 400);
            }

            noti.IsSeen = true;
            await _context.SaveChangesAsync();
        }

        public async Task MarkSeenAllNotis(int userId)
        {
            await _context.Notifcations.Where(n => n.UserId == userId).UpdateFromQueryAsync(no => new Notification { IsSeen = true });
        }
    }
}
