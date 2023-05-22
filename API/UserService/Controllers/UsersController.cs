using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Controllers;

public class UsersController : BaseController
{
  private readonly IMapper _mapper;
  private readonly IUserRepo _userRepo;
  public UsersController(IUserRepo userRepo, IMapper mapper)
  {
    _userRepo = userRepo;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
  {
    var users = await _userRepo.GetUsers();
    return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<UserDto>> GetUser(int id)
  {
    var user = await _userRepo.GetUserById(id);
    if (user == null) return NotFound();

    return Ok(user);
  }
}
