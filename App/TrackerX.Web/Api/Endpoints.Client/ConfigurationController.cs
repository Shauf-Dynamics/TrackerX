using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TrackerX.Web.Options;

namespace TrackerX.Web.Api.Endpoints.Client;

[ApiController]
[Route("api/configuration")]
public class ConfigurationController : Controller
{
    private readonly AppConfigurationOptions _options;

    public ConfigurationController(IOptionsSnapshot<AppConfigurationOptions> configs)
    {
        _options = configs.Value;
    }

    [HttpGet]    
    [ProducesResponseType(typeof(IEnumerable<AppConfigurationOptions>), 200)]
    public IActionResult Get()
    {        
        return Ok(_options);        
    }
}
