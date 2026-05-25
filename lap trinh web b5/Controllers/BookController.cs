using lap_trinh_web_b5.Models.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lap_trinh_web_b5.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public BookController(BookDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            IQueryable<Book> booksQuery = _context.Books
                .Include(book => book.Category)
                .OrderBy(book => book.Title);

            if (categoryId.HasValue)
            {
                booksQuery = booksQuery.Where(book => book.CategoryId == categoryId.Value);
            }

            var viewModel = new BookIndexViewModel
            {
                CurrentCategoryId = categoryId,
                Books = await booksQuery.ToListAsync(),
                Categories = await _context.Categories
                    .Select(category => new CategoryCountViewModel
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        BookCount = category.Books.Count
                    })
                    .OrderBy(category => category.CategoryName)
                    .ToListAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(item => item.Category)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public async Task<IActionResult> Create()
        {
            await LoadCategoriesAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,Price,Description,CategoryId")] Book book, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                book.Image = await SaveImageAsync(imageFile);
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await LoadCategoriesAsync(book.CategoryId);
            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await LoadCategoriesAsync(book.CategoryId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Price,Description,Image,CategoryId")] Book book, IFormFile? imageFile)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var newImage = await SaveImageAsync(imageFile);
                    if (!string.IsNullOrWhiteSpace(newImage))
                    {
                        book.Image = newImage;
                    }

                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExistsAsync(book.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            await LoadCategoriesAsync(book.CategoryId);
            return View(book);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(item => item.Category)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCategoriesAsync(int? selectedCategoryId = null)
        {
            ViewData["CategoryId"] = new SelectList(
                await _context.Categories.OrderBy(category => category.CategoryName).ToListAsync(),
                "CategoryId",
                "CategoryName",
                selectedCategoryId);
        }

        private async Task<bool> BookExistsAsync(int id)
        {
            return await _context.Books.AnyAsync(book => book.Id == id);
        }

        private async Task<string?> SaveImageAsync(IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("Image", "Chi chap nhan file anh jpg, jpeg, png, gif hoac webp");
                return null;
            }

            var imageFolder = Path.Combine(_environment.WebRootPath, "Content", "ImageBooks");
            Directory.CreateDirectory(imageFolder);

            var fileName = $"{Guid.NewGuid():N}{extension}";
            var filePath = Path.Combine(imageFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            return fileName;
        }
    }
}
