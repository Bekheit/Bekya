
using AuthenticationService.Data;
using AuthenticationService.Dtos;
using AuthenticationService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers;

public class AuthController : BaseController
{
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;
  private readonly IMapper _mapper;
  public AuthController(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
  {
    _mapper = mapper;
    _tokenService = tokenService;
    _userManager = userManager;
  }

  [HttpPost("login")]
  public async Task<ActionResult<Response>> Login(LoginDto loginDto)
  {
    var user = _userManager.Users.SingleOrDefault(u => u.PhoneNumber == loginDto.PhoneNumber);
    Response response;

    if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
    {
      response = new Response()
      {
        Code = 400,
        Success = false,
        Message = "Invalid Phone number or Password",
      };
      return Unauthorized(response);
    }

    response = new Response()
    {
      Code = 200,
      Success = true,
      Message = "User logged in successfully",
      Body = _tokenService.CreateToken(user)
    };

    return Ok(response);
  }

  [HttpPost("register")]
  public async Task<ActionResult<Response>> Register(RegisterDto registerDto)
  {
    var userExist = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == registerDto.PhoneNumber);
    Response response;


    if (userExist != null)
    {
      response = new()
      {
        Code = 400,
        Success = false,
        Message = "Failed to Register user",
        Body = "Phone number is already exist"
      };
      return BadRequest(response);
    }
    var user = _mapper.Map<AppUser>(registerDto);
    var result = await _userManager.CreateAsync(user, registerDto.Password);

    if (!result.Succeeded)
    {
      response = new()
      {
        Code = 400,
        Success = false,
        Message = " Failed to Register user",
        Body = result.Errors
      };
      return BadRequest(response);
    }

    response = new()
    {
      Code = 201,
      Success = true,
      Message = "User registered Successfully",
      Body = _tokenService.CreateToken(user)
    };

    return Ok(response);
  }
}
