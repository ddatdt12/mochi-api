using Microsoft.AspNetCore.Mvc;
using MochiApi.Models;
using Microsoft.AspNetCore.Authorization;
using MochiApi.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MochiApi.Dtos;
using MochiApi.DTOs;

namespace MochiApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        public DataContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public UserController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([MinLength(4, ErrorMessage = "At lease 4 characters")] string email)
        {
            var users = await _context.Users.Where(u => u.Email.Contains(email)).ToListAsync();

            var userDtos = _mapper.Map<IEnumerable<BasicUserDto>>(users);
            return Ok(new ApiResponse<IEnumerable<BasicUserDto>>(userDtos, "search users"));
        }
    }
}
