using ClosedXML.Excel;
using kursovayK.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kursovayK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtchetsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public OtchetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ExportAll()
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {


                var worksheet = workbook.Worksheets.Add("Computers");

                worksheet.Cell(1, 1).Value = "ComputerId";

                worksheet.Cell(1, 2).Value = "Processor";

                worksheet.Cell(1, 3).Value = "VideoCard";

                worksheet.Cell(1, 4).Value = "Headphones";

                worksheet.Cell(1, 5).Value = "Keyboard";

                worksheet.Cell(1, 6).Value = "Mouse";

                worksheet.Cell(1, 7).Value = "GamingChair";


                worksheet.Row(1).Style.Font.Bold = true;

                var otch = _context.Computers;
                int i = 2;
                foreach (Computer item in otch)
                {
                    worksheet.Cell(i, 1).Value = item.ComputerId;
                    worksheet.Cell(i, 2).Value = item.Processor;
                    worksheet.Cell(i, 3).Value = item.VideoCard;
                    worksheet.Cell(i, 4).Value = item.Headphones;
                    worksheet.Cell(i, 5).Value = item.Keyboard;
                    worksheet.Cell(i, 6).Value = item.Mouse;
                    worksheet.Cell(i, 7).Value = item.GamingChair;
                    i++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreedsheetml.sheet")
                    {
                        FileDownloadName = $"otchet_{DateTime.UtcNow.ToLongDateString()}.xlsx"
                    };
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult Export(int? id)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
          

                var worksheet = workbook.Worksheets.Add("Computer");

                worksheet.Cell(1, 1).Value = "ComputerId";

                worksheet.Cell(1, 2).Value = "Processor";

                worksheet.Cell(1, 3).Value = "VideoCard";

                worksheet.Cell(1, 4).Value = "Headphones";

                worksheet.Cell(1, 5).Value = "Keyboard";

                worksheet.Cell(1, 6).Value = "Mouse";

                worksheet.Cell(1, 7).Value = "GamingChair";


                worksheet.Row(1).Style.Font.Bold = true;

                var otch = _context.Computers.Where(d => d.ComputerId == id);
                int i = 2;
                foreach (Computer item in otch)
                {
                    worksheet.Cell(i, 1).Value = item.ComputerId;
                    worksheet.Cell(i, 2).Value = item.Processor;
                    worksheet.Cell(i, 3).Value = item.VideoCard;
                    worksheet.Cell(i, 4).Value = item.Headphones;
                    worksheet.Cell(i, 5).Value = item.Keyboard;
                    worksheet.Cell(i, 6).Value = item.Mouse;
                    worksheet.Cell(i, 7).Value = item.GamingChair;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreedsheetml.sheet")
                    {
                        FileDownloadName = $"otchet_{DateTime.UtcNow.ToLongDateString()}.xlsx"
                    };
                }
            }
        }
    }
}

