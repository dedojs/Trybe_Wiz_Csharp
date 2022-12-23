using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{

    private readonly ILogger<HelloController> _logger;

    public HelloController(ILogger<HelloController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]    
    public ActionResult Get()
    {
        return Ok("hello, use /{language} to get a hello in your language!");
    }

    //[Route("[controller]/{}")]
    [HttpGet("{language}")]
    public ActionResult Get(string language)
    {
        string greet;
        switch (language)
        {   
            case "en": 
                greet = "[en] : Hello";
                break;
            case "br":
                greet = "[br] : Olá";
                break;
            case "de":
                greet = "[de] : Hallo";
                break;
            case "es":
                greet = "[es] : Hola";
                break;
            default:
                greet = "Não conheço essa!";
                break;
        }

        return Ok(greet);

    }
}
