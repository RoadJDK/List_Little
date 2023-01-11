using AutoMapper;
using List_Little_Api.DTOs;
using List_Little_Business_Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace List_Little_Api.Controllers;

[Authorize(Policy = "Admin")]
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
            var personList = Service.GetAll();
            var mappedEntities = personList.Select(Mapper.Map<Person>);
            return Ok(personList);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
