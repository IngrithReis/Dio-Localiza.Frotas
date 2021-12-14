using Localiza.Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace Dio_Localiza.Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    
    
    public class SingletonController : ControllerBase
    {
        private readonly  SingletonContainer _singletonContainer;
        public SingletonController(SingletonContainer singletonContainer)
        {
            _singletonContainer = singletonContainer;
        }

        [HttpGet()]
        public IActionResult Get()
        {  
            //Por injeção de dependência:

            var singleton = _singletonContainer;
            return Ok(_singletonContainer);

           // var singleton = Singleton.Instance;
           // return Ok(singleton);
        }
    }
}
