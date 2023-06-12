using BackendInforamacioni1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendInforamacioni1.Controllers
{
    public class OsobaController : ControllerBase
    {

        private readonly DbCon bazan;
        public OsobaController(DbCon baz)
        {

            this.bazan = baz;   
        }


        [HttpGet("getAll")]

        public  async Task<IActionResult>GetAll()
        {

            var osobe = await bazan.Osoba.ToListAsync();

                return Ok(osobe);   



        }

        [HttpGet("/{id}")]

        public async Task<IActionResult> GetOne(int id)
        {

            var osoba = await bazan.Osoba.FirstOrDefaultAsync(t=>t.Id==id);

            return Ok(osoba);



        }



        [HttpPost("addPost")]

        public async Task<IActionResult> AddPost([FromBody] Osoba osoba)
        {
            await bazan.Osoba.AddAsync(osoba);

            await bazan.SaveChangesAsync();          





            return Ok(osoba);
        }




        [HttpPut("updatePost")]

        public async Task<IActionResult> updatePost([FromBody] Osoba osoba)
        {
             bazan.Osoba.Update(osoba);

            await bazan.SaveChangesAsync();


            return Ok(osoba);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult>DeleteOne(int id)
        {

            var osoba=await bazan.Osoba.FirstOrDefaultAsync(t=> t.Id==id);  


            if(osoba==null) return NotFound();



            bazan.Osoba.Remove(osoba);
            await bazan.SaveChangesAsync();

            return Ok(osoba);

        }



        [HttpGet("filter/{num}")]
        public async Task<IActionResult> filter(int num)
        {

            var osobe = await bazan.Osoba.Where(t => t.Number == num).ToListAsync();

            if (osobe == null) return NotFound();



           

            return Ok(osobe);

        }











    }
}
