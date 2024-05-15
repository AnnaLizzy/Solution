using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using WebApplicationApp.Models;
using SkiaSharp;

namespace WebApplicationApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            _ = User.Identity?.Name;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DrawPoints()
        {
            return View();
        }
        public IActionResult DrawPointsOnImage()
        {
            // Đường dẫn đến ảnh có sẵn
            string imagePath = "wwwroot/images/mapQv.png";

            // Tải ảnh từ đường dẫn
            using SKBitmap bitmap = SKBitmap.Decode(imagePath);
            // Tạo một bitmap mới để vẽ lên
            using SKBitmap newBitmap = new(bitmap.Width, bitmap.Height);
            // Tạo một canvas từ bitmap mới
            using (SKCanvas canvas = new(newBitmap))
            {
                // Vẽ ảnh gốc lên canvas
                canvas.DrawBitmap(bitmap, 0, 0);

                // Vẽ các điểm trên ảnh
                using SKPaint paint = new();
                paint.Color = SKColors.Red; // Màu đỏ
                paint.IsAntialias = true; // Chế độ làm mịn

                // Vẽ các điểm lên ảnh
                DrawPoint(canvas, 100, 100, paint); // Vẽ điểm tại tọa độ (100, 100)
                DrawPoint(canvas, 200, 200, paint); // Vẽ điểm tại tọa độ (200, 200)
                                                    // Thêm các điểm khác tùy ý
            }

            // Lưu ảnh đã vẽ
            using MemoryStream stream = new();
            using SKImage image = SKImage.FromBitmap(newBitmap);
            image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(stream);
            stream.Position = 0;

            // Trả về file ảnh đã vẽ
            return File(stream.ToArray(), "image/png");

        }

        private static void DrawPoint(SKCanvas canvas, float x, float y, SKPaint paint)
        {
            canvas.DrawCircle(x, y, 5, paint); // Vẽ một điểm chấm tại tọa độ (x, y)
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
