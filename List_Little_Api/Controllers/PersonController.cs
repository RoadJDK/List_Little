using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace List_Little_Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public bool GetAll()
    {
        return true;
    }
}

