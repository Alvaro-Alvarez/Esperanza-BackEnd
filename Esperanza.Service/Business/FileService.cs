using Esperanza.Core.Interfaces.Business;
//using Esperanza.Core.Models.Sync;
//using Microsoft.AspNetCore.Http;
//using OfficeOpenXml;

namespace Esperanza.Service.Business
{
    public class FileService : IFileService
    {
        //private readonly IProductService _productService;

        //public FileService(IProductService productService)
        //{
        //    _productService = productService;
        //}

        //public async Task ImportProducts(IFormFile file)
        //{
        //    if (file == null || file.Length <= 0) throw new Exception("File is empty");
        //    if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
        //        throw new Exception("Not Support file extension");

        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);
        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //            var rowCount = worksheet.Dimension.Rows;
        //            List<ProductXLSX> list = new List<ProductXLSX>();

        //            for (int row = 2; row <= rowCount; row++)
        //            {
        //                list.Add(new ProductXLSX
        //                {
        //                    Tipo = Get(worksheet.Cells[row, 1].Value),
        //                    Alta = Get(worksheet.Cells[row, 2].Value),
        //                    Id = Get(worksheet.Cells[row, 3].Value),
        //                    Laboratorio = Get(worksheet.Cells[row, 4].Value),
        //                    Categoria = Get(worksheet.Cells[row, 5].Value),
        //                    LineaBal = Get(worksheet.Cells[row, 6].Value),
        //                    Nombre = Get(worksheet.Cells[row, 7].Value),
        //                    ComponentePrincipal = Get(worksheet.Cells[row, 8].Value),
        //                    Droga = Get(worksheet.Cells[row, 9].Value),
        //                    Accion = Get(worksheet.Cells[row, 10].Value),
        //                    Description = Get(worksheet.Cells[row, 11].Value),
        //                    Especie = Get(worksheet.Cells[row, 12].Value),
        //                    Presentacion = Get(worksheet.Cells[row, 13].Value),
        //                    ViasDeAdminstracion = Get(worksheet.Cells[row, 14].Value),
        //                    RetiroLeche = Get(worksheet.Cells[row, 15].Value),
        //                    RetiroCarne = Get(worksheet.Cells[row, 16].Value),
        //                    Foto = Get(worksheet.Cells[row, 17].Value),
        //                    Discontinuado = Get(worksheet.Cells[row, 18].Value),
        //                    FaltanteInfo = Get(worksheet.Cells[row, 19].Value),
        //                    FaltanteFoto = Get(worksheet.Cells[row, 20].Value),
        //                    OBS = Get(worksheet.Cells[row, 21].Value)
        //                });
        //            }
        //            await _productService.SyncProducts(list, new Guid().ToString());

        //            //bool manyToMany = false;
        //            //string categoryQueryExm = "INSERT INTO Laboratory (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name) VALUES (NEWID(), 0, GETDATE(), GETDATE(), '@GUID', '@GUID' ,'@NAME');";
        //            //string categoryQueries = string.Empty;
        //            //var queries = new List<string>();
        //            //var categories = list.Where(l => !string.IsNullOrEmpty(l.Laboratorio)).Select(l => l.Laboratorio).Distinct().ToList();
        //            //var categoriesClean = new List<string>();
        //            //foreach (var cat in categories)
        //            //{
        //            //    var cats = cat.Split(",").ToList();
        //            //    if (!manyToMany && cats.Count() > 1) manyToMany = true;
        //            //    for (int i = 0; i < cats.Count; i++) cats[i] = cats[i].Trim();
        //            //    categoriesClean.AddRange(cats);
        //            //}
        //            ////categoriesClean = categoriesClean.Distinct().ToList();
        //            //categoriesClean = categoriesClean.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
        //            //categoriesClean.ForEach(cat =>
        //            //{
        //            //    queries.Add(categoryQueryExm.Replace("@GUID", new Guid().ToString()).Replace("@NAME", cat));
        //            //});
        //            //categoryQueries = string.Join("\n", queries);
        //        }
        //    }
        //}

        ////private bool Valid(object value)
        ////{
        ////    return value != null;
        ////}

        //private string Get(object value)
        //{
        //    if (value != null) return value.ToString().Trim();
        //    return null;
        //}
    }
}
