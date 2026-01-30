using Mezclador.ViewModels;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador.Services
{
    public class Excel
    {
        public ExcelPackage? excelPackage;
        public string filePath = string.Empty;
        public async Task Create(DateTime dateStart, DateTime dateEnd)
        {
            List<ConsumoSinPlanVM> consumoList = ConexionDB.GetConsumptionList(dateStart, dateEnd);
            if (consumoList.Count <= 0)
                return;

            // Agrupar por Material y calcular los totales
            var totalesPorMaterial = consumoList
                .GroupBy(item => item.Material)
                .Select(grupo => new
                {
                    Material = grupo.Key,
                    TotalCantidad = grupo.Sum(item => Double.TryParse(item.Cantidad, out double cantidad)?cantidad:0.0)
                });

            var consumoPorProducto = consumoList
            .GroupBy(item => item.Producto)
            .Select(grupo => new
            {
                Producto = grupo.Key,
                Materiales = grupo
                    .GroupBy(item => item.Material)
                    .Select(materialGrupo => new
                    {
                        Material = materialGrupo.Key,
                        TotalCantidad = materialGrupo.Sum(item => Double.TryParse(item.Cantidad, out double cantidad) ? cantidad : 0.0)
                    })
            });

            var dateNow = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            filePath = @$"C:\reportes\Reporte {dateNow}.xlsx";
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            // Crear un nuevo archivo Excel
            //using (
            excelPackage = new ExcelPackage();
            //{
            // Agregar una hoja de cálculo
            var worksheet = excelPackage.Workbook.Worksheets.Add("Reporte");

            // Agregar datos a la hoja
            worksheet.Cells[1, 1].Value = "Historial de consumo";

            worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
            worksheet.Cells[1, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, 2].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
            worksheet.Cells[1, 7].Value = "Consumo por material";
            worksheet.Cells[1, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, 7].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            worksheet.Cells[2, 1].Value = "Orden";
            worksheet.Cells[2, 2].Value = "Producto";
			worksheet.Cells[2, 3].Value = "Material";
			worksheet.Cells[2, 4].Value = "Cantidad";
            worksheet.Cells[2, 5].Value = "Fecha";
            
            var horCenter = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
   //         worksheet.Column(1).Width = 15;
            worksheet.Column(1).Style.HorizontalAlignment = horCenter;
            worksheet.Column(4).Style.HorizontalAlignment = horCenter;
            //         worksheet.Column(2).Width = 40;
            //         worksheet.Column(3).Width = 40;
            //worksheet.Column(4).Width = 12;
            //         worksheet.Column(5).Width = 24;

            int row = 2;
            foreach (var consumo in consumoList)
            {
                worksheet.Cells[row, 1].Value = consumo.Orden;
                worksheet.Cells[row, 2].Value = consumo.Producto;
                worksheet.Cells[row, 3].Value = consumo.Material;
                worksheet.Cells[row, 4].Value = consumo.Cantidad;
                worksheet.Cells[row, 5].Value = consumo.Fecha;
                row++;
            }

            row = 2;
            foreach (var consumo in totalesPorMaterial)
            {
                worksheet.Cells[row, 7].Value = consumo.Material;
                worksheet.Cells[row, 8].Value = consumo.TotalCantidad;
                row++;
            }

            row++;
            worksheet.Cells[row, 7].Value = "Consumo por producto";
            worksheet.Cells[row, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[row, 7].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            foreach (var consumo in consumoPorProducto)
            {
                row++;
                worksheet.Cells[row, 7].Value = consumo.Producto;
                worksheet.Cells[row, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[row, 7].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                row++;
                foreach (var material in consumo.Materiales)
                {
                    worksheet.Cells[row, 7].Value = material.Material;
                    worksheet.Cells[row, 8].Value = material.TotalCantidad;
                    row++;
                }
            }
            for (int i = 1; i <= 8; i++)
            {
                worksheet.Column(i).AutoFit();
            }
            // Guardar el archivo
            FileInfo fileInfo = new FileInfo(filePath);
            try
            {
                await Task.Run(() => excelPackage.SaveAs(fileInfo));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
                //no usar MessageBox porque email tambien usa esta funcion
            }
            Console.WriteLine($"Archivo Excel guardado en: {filePath}");
            //}
        }
        public async Task Create(int idOrden)
        {
            List<ConsumoSinPlanVM> consumoList = ConexionDB.GetConsumListByOrder(idOrden);
            try
            {
                var orden = consumoList[0].Orden;
                var nombreProd = consumoList[0].NombreProd;
                var producto = consumoList[0].Producto;
                filePath = @$"C:\reportes\Orden {orden} {nombreProd} {producto} .xlsx";
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                // Crear un nuevo archivo Excel
                //using (
                excelPackage = new ExcelPackage();
                //{
                // Agregar una hoja de cálculo
                var worksheet = excelPackage.Workbook.Worksheets.Add("Reporte");

                // Agregar datos a la hoja
                worksheet.Cells[1, 1].Value = "Material";
                worksheet.Cells[1, 2].Value = "Nombre";
                worksheet.Cells[1, 3].Value = "Cantidad";
                worksheet.Cells[1, 4].Value = "Fecha";

                worksheet.Column(1).Width = 16;
                worksheet.Column(2).Width = 34;
                worksheet.Column(3).Width = 12;
                worksheet.Column(4).Width = 24;

                int row = 2;
                foreach (var consumo in consumoList)
                {
                    worksheet.Cells[row, 1].Value = consumo.Material;
                    worksheet.Cells[row, 2].Value = consumo.Nombre;
                    worksheet.Cells[row, 3].Value = consumo.Cantidad;
                    worksheet.Cells[row, 4].Value = consumo.Fecha;
                    row++;
                }
                // Guardar el archivo
                FileInfo fileInfo = new FileInfo(filePath);

                await Task.Run(() => excelPackage.SaveAs(fileInfo));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }
            Console.WriteLine($"Archivo Excel guardado en: {filePath}");
        }
    }
}
