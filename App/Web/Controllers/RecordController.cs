using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {        
        private readonly ILogger<RecordController> _logger;
        private readonly DataContext _dataContext;

        public RecordController(ILogger<RecordController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }

        [HttpGet(Name = "GetRecords")]
        public IEnumerable<int> Get()
        {
            return _dataContext.Exercises.AsEnumerable().Select(x=>x.TypeId);
          //  return _dataContext.Records.AsEnumerable().Select(x => x.Id);
        }
    }
}