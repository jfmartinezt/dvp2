using CL.Server.Domain.Users;
using CL.Server.Middleware.Contracts.Persons;
using CL.Server.Middleware.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ticket.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PersonsController : ControllerBase
  {
    private readonly ILogger<PersonsController> _logger;
    private readonly UsersManager usersManager;

    public PersonsController(ILogger<PersonsController> logger)
    {
      _logger = logger;
      usersManager = new UsersManager();
    }

    [Route("user-add")]
    [HttpPost]
    public UserCreationData AddUser(UserCreationData user)  
    {
      return usersManager.AddUser(user);
    }

    [Route("user-login")]
    [HttpPost]
    public PersonData GetUserInfo(UserLoginData user)
    {
      return usersManager.UserInfoData(user);
    }
  }
}
