using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Drawing;
using System.Xml.Linq;

namespace Web_Ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhaleController : ControllerBase
    {

        [HttpGet("get-whale")]
        public WhaleData GetWhaleData()
        {
            List<WhaleData> whales = new List<WhaleData>();
            WhaleBusiness whaleBusiness = new WhaleBusiness();
            whales = whaleBusiness.GetData();
            int whaleId =0;
            string name="";
            int age = 0;
            string colour ="";
            bool ısItPregnant= false;
            foreach(WhaleData item in whales)
            {
                whaleId = item.WhaleId;
                name= item.Name;
                age = item.Age;
                colour = item.Colour;
                ısItPregnant = item.IsItPregnant;
            }
            return new WhaleData(whaleId, name, age, colour, ısItPregnant);

        }

        [HttpPost("post-whale")]
        public IActionResult AddData([FromBody] WhaleData whale)
        {
            if (whale == null) return BadRequest();

            WhaleBusiness whaleBusiness = new WhaleBusiness(); 
            whaleBusiness.AddData(whale);
            return Ok("İŞLEM BAŞARILI!");

        }

        [HttpDelete("delete-whale")]
        public IActionResult DeleteData(int whaleId)
        {
            if(whaleId == null) return BadRequest();
            WhaleBusiness whaleBusiness=new WhaleBusiness();
            int rowsAffected=whaleBusiness.DeleteData(whaleId);
           if (rowsAffected>0)   
            {
                return Ok("Silme İşlemi Başarılı!");
            }
           else return NotFound("Kullanıcı Bulunamadı.");
            
        }
        [HttpPut("put-whale")]
        public IActionResult UpDateData([FromBody] WhaleData whale, int whaleId)
        {
            if(whaleId==null ) return BadRequest();
            WhaleBusiness whaleBusiness = new WhaleBusiness();
            int rowsAffected = whaleBusiness.UpDateData(whaleId,whale);
            if (rowsAffected > 0)
            {
                return Ok("Güncelleme işlemi BAŞARILI!");
            }
            else return NotFound("BULUNAMADI!");
        }
    }

}
