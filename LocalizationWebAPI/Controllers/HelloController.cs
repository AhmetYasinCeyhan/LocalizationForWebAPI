using LocalizationWebAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HelloController : ControllerBase
{
    private readonly IStringLocalizer<MessageResources> _localizer;
    public HelloController(IStringLocalizer<MessageResources> localizer)
    {
        _localizer = localizer;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_localizer["SAY_HELLO"]);
    }
}
