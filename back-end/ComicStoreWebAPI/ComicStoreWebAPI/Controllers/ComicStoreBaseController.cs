using ComicStore.Service.Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ComicStoreBaseController : ControllerBase
    {
        protected void AddPaginationHeader(Paginator<dynamic> obj)
        {
            Response.Headers.Add(
                "X-Pagination",
                 JsonConvert.SerializeObject(obj.GetPaginatorMetadata(), new JsonSerializerSettings
                 {
                     ContractResolver = new DefaultContractResolver
                     {
                         NamingStrategy = new CamelCaseNamingStrategy()
                     }
                 })
                 );
        }
    }
}
