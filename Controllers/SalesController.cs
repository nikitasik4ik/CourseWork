using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseWork.Models;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace CourseWork.Controllers
{
    public class SalesController : Controller
    {
        private readonly dbnDbContext _context;

        public SalesController(dbnDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var dbnDbContext = _context.Sales.Include(s => s.Client).Include(s => s.Product).Include(s => s.Stuff);
            return View(await dbnDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Include(s => s.Stuff)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "FullName");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand");
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "StuffId", "FullNameStuff");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,ProductId,DateSale,Quantity,StuffId,ClientId")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", sale.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", sale.ProductId);
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "StuffId", "FullNameStuff", sale.StuffId);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "FullName", sale.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", sale.ProductId);
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "StuffId", "FullNameStuff", sale.StuffId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,ProductId,DateSale,Quantity,StuffId,ClientId")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", sale.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", sale.ProductId);
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "StuffId", "FullNameStuff", sale.StuffId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Include(s => s.Stuff)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'dbnDbContext.Sales'  is null.");
            }
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
          return (_context.Sales?.Any(e => e.SaleId == id)).GetValueOrDefault();
        }

        public FileResult GenerateReport()
        {
            var sales = _context.Sales
                .Include(s => s.Stuff)
                .Include(s => s.Client)
                .ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sales");

                // Header row
                worksheet.Cells[1, 1].Value = "Продукт";
                worksheet.Cells[1, 2].Value = "Дата продажи";
                worksheet.Cells[1, 3].Value = "Количество";
                worksheet.Cells[1, 4].Value = "Сотрудник";
                worksheet.Cells[1, 5].Value = "Клиент";

                // Количество столбцов
                var columnCount = worksheet.Dimension.End.Column;

                // Применение стиля для заголовков
                using (var range = worksheet.Cells[1, 1, 1, columnCount])
                {
                    range.Style.Font.Bold = true;
                }

                // Data rows
                var row = 2;
                foreach (var sale in sales)
                {
                    worksheet.Cells[row, 1].Value = sale.ProductId.HasValue ? _context.Products.Find(sale.ProductId)?.Brand : "";
                    worksheet.Cells[row, 2].Value = sale.DateSale?.ToString("dd.MM.yyyy");
                    worksheet.Cells[row, 3].Value = sale.Quantity ?? 0;
                    worksheet.Cells[row, 4].Value = sale.StuffId.HasValue ? _context.Stuffs.Find(sale.StuffId)?.FullNameStuff : "";
                    worksheet.Cells[row, 5].Value = sale.ClientId.HasValue ? _context.Clients.Find(sale.ClientId)?.FullName : "";
                    row++;
                }

                // Auto fit columns
                worksheet.Cells.AutoFitColumns();

                // Convert Excel package to bytes
                var fileContents = excelPackage.GetAsByteArray();

                // Set file name
                var fileName = "SalesReport.xlsx";

                // Return the Excel file as a download
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        public async Task<IActionResult> BestEmployee()
        {
            var bestEmployeeId = await _context.Sales
                .GroupBy(s => s.StuffId)
                .Select(g => new { StuffId = g.Key, TotalQuantity = g.Sum(s => s.Quantity) })
                .OrderByDescending(g => g.TotalQuantity)
                .Select(g => g.StuffId)
                .FirstOrDefaultAsync();

            var bestEmployee = await _context.Stuffs.FindAsync(bestEmployeeId);

            if (bestEmployee != null)
            {
                using (var stream = new MemoryStream())
                {
                    using (var wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
                    {
                        var mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        var body = mainPart.Document.AppendChild(new Body());

                        var headingStyleId = "Heading1";
                        var headingParagraph = body.AppendChild(new Paragraph());
                        var run = headingParagraph.AppendChild(new Run());
                        run.AppendChild(new Text("Отчет о лучшем сотруднике года"));
                        run.RunProperties = new RunProperties();
                        run.RunProperties.AppendChild(new Bold());
                        //run.RunProperties.AppendChild(new FontSize() { Val = "24" });
                        run.RunProperties.AppendChild(new Color() { ThemeColor = ThemeColorValues.Accent1 });

                        var contentParagraph = body.AppendChild(new Paragraph());
                        var contentRun = contentParagraph.AppendChild(new Run());
                        contentRun.AppendChild(new Text("Лучший сотрудник года: " + bestEmployee.FullNameStuff));

                        var table = body.AppendChild(new Table());

                        var headerRow = table.AppendChild(new TableRow());
                        headerRow.AppendChild(CreateTableCell("Продукт"));
                        headerRow.AppendChild(CreateTableCell("Дата продажи"));
                        headerRow.AppendChild(CreateTableCell("Количество"));

                        var sales = await _context.Sales.Include(s => s.Product).Where(s => s.StuffId == bestEmployeeId).ToListAsync();

                        foreach (var sale in sales)
                        {
                            var tableRow = table.AppendChild(new TableRow());
                            tableRow.AppendChild(CreateTableCell(sale.Product?.Brand));
                            tableRow.AppendChild(CreateTableCell(sale.DateSale?.ToString("dd.MM.yyyy")));
                            tableRow.AppendChild(CreateTableCell(sale.Quantity?.ToString()));
                        }

                        wordDocument.Save();
                    }

                    stream.Position = 0;

                    var fileContents = new MemoryStream(stream.ToArray());

                    return File(fileContents, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "BestEmployee.docx");
                }
            }

            return NotFound();
        }

        private TableCell CreateTableCell(string text)
        {
            var cell = new TableCell();
            var paragraph = new Paragraph();
            var run = new Run(new Text(text));
            paragraph.Append(run);
            cell.Append(paragraph);

            var cellProperties = new TableCellProperties();
            var borders = new TableCellBorders();

            var topBorder = new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 };
            var bottomBorder = new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 };
            var leftBorder = new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 };
            var rightBorder = new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 };
            var insideHorizontalBorder = new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 };
            var insideVerticalBorder = new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 2 };

            borders.Append(topBorder);
            borders.Append(bottomBorder);
            borders.Append(leftBorder);
            borders.Append(rightBorder);
            borders.Append(insideHorizontalBorder);
            borders.Append(insideVerticalBorder);

            cellProperties.AppendChild(borders);
            cell.AppendChild(cellProperties);

            return cell;
        }
        public async Task<IActionResult> TopSellingProducts()
        {
            var topSellingProducts = await _context.Sales
                .GroupBy(s => s.ProductId)
                .Select(g => new { ProductId = g.Key, TotalQuantity = g.Sum(s => s.Quantity) })
                .OrderByDescending(g => g.TotalQuantity)
                .Take(10)
                .ToListAsync();

            using (var stream = new MemoryStream())
            {
                using (var wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
                {
                    var mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = mainPart.Document.AppendChild(new Body());

                    var headingStyleId = "Heading1";
                    var headingParagraph = body.AppendChild(new Paragraph());
                    var run = headingParagraph.AppendChild(new Run());
                    run.AppendChild(new Text("Отчет о самых продаваемых товарах"));
                    run.RunProperties = new RunProperties();
                    run.RunProperties.AppendChild(new Bold());
                    //run.RunProperties.AppendChild(new FontSize() { Val = "24" });
                    run.RunProperties.AppendChild(new Color() { ThemeColor = ThemeColorValues.Accent1 });

                    var table = body.AppendChild(new Table());

                    var headerRow = table.AppendChild(new TableRow());
                    headerRow.AppendChild(CreateTableCell("№"));
                    headerRow.AppendChild(CreateTableCell("Продукт"));
                    headerRow.AppendChild(CreateTableCell("Количество"));

                    for (int i = 0; i < topSellingProducts.Count; i++)
                    {
                        var product = await _context.Products.FindAsync(topSellingProducts[i].ProductId);

                        var tableRow = table.AppendChild(new TableRow());
                        tableRow.AppendChild(CreateTableCell((i + 1).ToString()));
                        tableRow.AppendChild(CreateTableCell(product?.Brand));
                        tableRow.AppendChild(CreateTableCell(topSellingProducts[i].TotalQuantity.ToString()));
                    }

                    wordDocument.Save();
                }

                stream.Position = 0;

                var fileContents = new MemoryStream(stream.ToArray());

                return File(fileContents, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "TopSellingProducts.docx");
            }
        }

    }
}
