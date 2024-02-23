using BusinessLayer.BaseStoreBL;
using BusinessLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseStoreController<T> : ControllerBase
    {
        private IBaseStoreBL<T> _BaseStoreBL;

        public BaseStoreController(IBaseStoreBL<T> BaseStoreBL)
        {
            _BaseStoreBL = BaseStoreBL;
        }
        [HttpGet("{id}")]
        public virtual IActionResult GetRecordById([FromRoute] int id)
        {
            try
            {
                var record = _BaseStoreBL.GetRecordById(id);

                if (record != null)
                {
                    return StatusCode(200, record);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetFilterRecords([FromQuery] string? search, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            try
            {
                var records = _BaseStoreBL.FilterRecords(search, pageSize, pageNumber);

                if (records != null)
                {
                    return StatusCode(200, records);
                }
                else
                {
                    return StatusCode(500, "loi");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public virtual IActionResult InsertOneRecord([FromBody] T record)
        {
            try
            {
                int affectedRow = _BaseStoreBL.InsertOneRecord(record);

                if (affectedRow != 0)
                {
                    return StatusCode(201, affectedRow);
                }
                else
                {
                    return StatusCode(500, "e001");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public virtual IActionResult UpdateOneRecord([FromRoute] int id, [FromBody] T record)
        {
            try
            {
                var recodId = _BaseStoreBL.UpdateOneRecord(id, record);

                if (recodId != 0)
                {
                    return StatusCode(200, recodId);
                }
                else
                {
                    return StatusCode(500, "e001");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMssg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("multi_delete")]
        public virtual IActionResult DeleteMultiRecord([FromBody] List<int> ids)
        {
            try
            {
                var a = _BaseStoreBL.DeleteMutirecord(ids);

                if (a > 0)
                {
                    return StatusCode(200, a);
                }
                else
                {
                    return StatusCode(500, "e001");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
