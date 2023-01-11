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
    private readonly IMapper Mapper;
    private readonly ILogger<PersonController> Logger;

    public PersonController(IPersonService service, IMapper mapper, ILogger<PersonController> logger)
    {
        Service = service;
        Mapper = mapper;
        Logger = logger;
    }

    [HttpGet]
    public ActionResult<Person> GetAll()
    {
        try
        {
            if (User.HasClaim("permissions", "listlittle:read-write"))
            {
                var personList = Service.GetAll();
                return Ok(personList);
            }
            else if (User.HasClaim("permissions", "listlittle:read-write-one-eight"))
            {
                var personList = Service.GetAll();
                var sortedList = personList.OrderBy(p => p.Number).Take(8);
                return Ok(sortedList);
            }
            else if (User.HasClaim("permissions", "listlittle:read-write-nine-sixteen"))
            {
                var personList = Service.GetAll();
                var sortedList = personList.OrderByDescending(p => p.Number).Take(8);
                return Ok(sortedList);
            }
            return BadRequest();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
