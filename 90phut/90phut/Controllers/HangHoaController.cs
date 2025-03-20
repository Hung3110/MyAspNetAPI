using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _90phut.data;
using _90phut.Models;

[Route("api/hanghoa")]
[ApiController]
public class HangHoaController : ControllerBase
{
    private readonly GoodsDbContext _context;

    public HangHoaController(GoodsDbContext context)
    {
        _context = context;
    }

 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<HangHoa>>> GetAllGoods()
    {
        var goods = await _context.Goods.AsNoTracking().ToListAsync();
        return Ok(goods);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HangHoa>> GetGoods(string id)
    {
        var hangHoa = await _context.Goods.AsNoTracking().FirstOrDefaultAsync(h => h.MaHangHoa == id);

        if (hangHoa == null)
            return NotFound(new { message = "Không tìm thấy hàng hóa." });

        return Ok(hangHoa);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HangHoa>> CreateGoods(HangHoa hangHoa)
    {
        if (string.IsNullOrEmpty(hangHoa.MaHangHoa) || string.IsNullOrEmpty(hangHoa.TenHangHoa))
            return BadRequest(new { message = "Mã hàng hóa và Tên hàng hóa không được để trống." });

        _context.Goods.Add(hangHoa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGoods), new { id = hangHoa.MaHangHoa }, hangHoa);
    }

    // Cập nhật hàng hóa
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGoods(string id, HangHoa hangHoa)
    {
        if (id != hangHoa.MaHangHoa)
            return BadRequest(new { message = "ID không trùng khớp." });

        var existingGoods = await _context.Goods.FindAsync(id);
        if (existingGoods == null)
            return NotFound(new { message = "Không tìm thấy hàng hóa cần cập nhật." });

        existingGoods.TenHangHoa = hangHoa.TenHangHoa;
        existingGoods.SoLuong = hangHoa.SoLuong;
        existingGoods.GhiChu = hangHoa.GhiChu;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return StatusCode(500, new { message = "Lỗi cập nhật dữ liệu, vui lòng thử lại." });
        }

        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGoods(string id)
    {
        var hangHoa = await _context.Goods.FindAsync(id);
        if (hangHoa == null)
            return NotFound(new { message = "Không tìm thấy hàng hóa để xóa." });

        _context.Goods.Remove(hangHoa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
