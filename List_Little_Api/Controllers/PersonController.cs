using AutoMapper;
using List_Little_Api.DTOs;
using List_Little_Business_Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace List_Little_Api.Controllers;

[Authorize(Policy = "Access")]
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService Service;
    private readonly ILogger<PersonController> Logger;

    public PersonController(IPersonService service, ILogger<PersonController> logger)
    {
        Service = service;
        Logger = logger;
    }

    [HttpGet]
    public ActionResult<Person> GetAll()
    {
        try
        {
            Logger.LogInformation("Authorisation Successful");
            if (User.HasClaim("permissions", "listlittle:read-write"))
            {
                var personList = Service.GetAll();
                Logger.LogInformation("Return Admin information");
                return Ok(personList);
            }
            else if (User.HasClaim("permissions", "listlittle:read-write-one-eight"))
            {
                var personList = Service.GetAll();
                var sortedList = personList.OrderBy(p => p.Number).Take(8);
                Logger.LogInformation("Return User1 information");
                return Ok(sortedList);
            }
            else if (User.HasClaim("permissions", "listlittle:read-write-nine-sixteen"))
            {
                var personList = Service.GetAll();
                var sortedList = personList.OrderByDescending(p => p.Number).Take(8);
                Logger.LogInformation("Return User2 information");
                return Ok(sortedList);
            }
            Logger.LogError("Something went wrong");
            return BadRequest();
        }
        catch (Exception e)
        {
            Logger.LogError("Something went wrong" + e);
            return BadRequest();
        }
    }
}
