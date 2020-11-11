using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPIAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultList adultList;

        public AdultController(IAdultList adultList)
        {
            this.adultList = adultList;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultList.GetAdultsAsync();
                return Ok(adults);
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Adult added = await adultList.AddAdultAsync(adult);
                return Created($"{added.Id}", added);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await adultList.RemoveAdultAsync(id);
                return Ok();
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
