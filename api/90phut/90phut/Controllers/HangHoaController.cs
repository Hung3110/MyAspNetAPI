using GoodsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly GoodsDbContext _context;

        public HangHoaController(GoodsDbContext context)
        {
            _context = context;
        }

        // GET: api/HangHoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HangHoa>>> GetGoods()
        {
            return await _context.Goods.ToListAsync();
        }

        // GET: api/HangHoa/{maHangHoa}
        [HttpGet("{maHangHoa}")]
        public async Task<ActionResult<HangHoa>> GetHangHoa(string maHangHoa)
        {
            var hangHoa = await _context.Goods.FindAsync(maHangHoa);
            if (hangHoa == null) return NotFound();
            return hangHoa;
        }

        // POST: api/HangHoa
        [HttpPost]
        public async Task<ActionResult<HangHoa>> CreateHangHoa(HangHoa hangHoa)
        {
            _context.Goods.Add(hangHoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHangHoa), new { maHangHoa = hangHoa.MaHangHoa }, hangHoa);
        }

        // PUT: api/HangHoa/{maHangHoa}
        [HttpPut("{maHangHoa}")]
        public async Task<IActionResult> UpdateHangHoa(string maHangHoa, HangHoa hangHoa)
        {
            if (maHangHoa != hangHoa.MaHangHoa) return BadRequest();
            _context.Entry(hangHoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/HangHoa/{maHangHoa}
        [HttpDelete("{maHangHoa}")]
        public async Task<IActionResult> DeleteHangHoa(string maHangHoa)
        {
            var hangHoa = await _context.Goods.FindAsync(maHangHoa);
            if (hangHoa == null) return NotFound();
            _context.Goods.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{maHangHoa}/ghi-chu")]
        public async Task<IActionResult> UpdateGhiChu(string maHangHoa, [FromBody] string ghiChu)
        {
            var hangHoa = await _context.Goods.FindAsync(maHangHoa);
            if (hangHoa == null) return NotFound();
            hangHoa.GhiChu = ghiChu;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}