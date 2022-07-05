using Excel = Microsoft.Office.Interop.Excel;
using ReadExcel.AttributeCustome;
using ReadExcel.Model;
using System.Reflection;
using ReadExcel.Db;
namespace ReadExcel.ClassService
{
    public class ReadFileExcel : IDisposable
    {
        private readonly DbDataContext _context;
        private Excel.Application _xlApp;
        private Excel.Workbook _xlWorkBook;
        private Excel.Worksheet? _xlWorkSheet;
        private Excel.Range? _range;

        public ReadFileExcel(DbDataContext context)
        {
            _context = context;
            _xlApp = new Excel.Application();

        }
        private int GetPositionOfSheet(string sheet)
        {
            // find sheet name of file excel
            int i = 1;
            foreach (Excel.Worksheet wSheet in _xlWorkBook.Worksheets)
            {
                var sheetName = wSheet.Name.ToLower();
                if (sheetName == sheet.ToLower()) break;
                i++;
                if (i > _xlWorkBook.Worksheets.Count) throw new Exception($"Can not find sheet name : {sheet}");
            }
            return i;
        }
        // tự động mapping data theo vị trí cột dữ liệu, cột 1 trong sheet map với cột 1 trong table, chỉ áp dụng khi chắc chắn biết vị trí phù hợp.
        public async Task<List<DataEntity>> ReadFileSheetByPosition(string path, string sheet = "Master List")
        {
            try
            {
                _xlWorkBook = _xlApp.Workbooks.Open(path, ReadOnly: true);
                _xlWorkSheet = (Excel.Worksheet)_xlWorkBook.Worksheets.get_Item(GetPositionOfSheet(sheet));
                _range = _xlWorkSheet.UsedRange;
                var listModel = new List<DataEntity>();
                for (int i = 2; i <= _range.Rows.Count; i++)
                {
                    var item = new DataEntity();
                    for (int j = 1; j <= _range.Columns.Count; j++)
                    {
                        var value = _range.Cells[i, j].Value2;
                        if (value != null)
                        {
                            switch (j)
                            {
                                case 1: item.Product_No = value; break;
                                case 2: item.PCAModuleAndInternal = value; break;
                                case 3: item.KCC = value; break;
                                case 4: item.StandardPackQty = value; break;
                                case 5: item.ProductDescriptione = value; break;
                                case 6: item.DigitsUPCCode = value; break;
                                case 7: item.digitsJANCode = value; break;
                                case 8: item.Rev = value; break;
                                case 9: item.RMN = value; break;
                                case 10: item.ProductLabelTemplate = value; break;
                                case 11: item.HPInternalPN = value; break;
                                case 12: item.OverpackLabelTemplate = value; break;
                                case 13: item.ImprintLogo = value; break;
                                case 14: item.ImprintSerialNo = value; break;
                                case 15: item.UpdatedBy = value; break;
                                case 16:
                                    try
                                    {
                                        DateTime dt = DateTime.FromOADate(value);
                                        item.DateOfUpdated = dt;
                                    }
                                    catch
                                    {

                                    }
                                    break;
                                case 17: item.ProductCode = value; break;
                                case 18: item.Remark = value; break;
                                case 19: item.BISNumber = value; break;
                                case 20: item.SamePartSNCheck = value; break;
                                case 21: item.SupplierPartNumber = value; break;
                                case 22: item.OptionPN = value; break;
                                case 23: item.SpareNo = value; break;
                                case 24: item.MaterialNo = value; break;
                                case 25: item.CDCLabelTemplate = value; break;
                            }
                        }
                    }
                    listModel.Add(item);
                }
                // insert to database
                await _context.Data.AddRangeAsync(listModel);
                await _context.SaveChangesAsync();
                return listModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // tự động mapping data theo tên cột dữ liệu có trong sheet excel Master_List
        public async Task<List<DataEntity>> ReadFileSheetAutoMap(string path, string sheet = "Master List")
        {
            try
            {
                _xlWorkBook = _xlApp.Workbooks.Open(path, ReadOnly: true);
                _xlWorkSheet = (Excel.Worksheet)_xlWorkBook.Worksheets.get_Item(GetPositionOfSheet(sheet));
                _range = _xlWorkSheet.UsedRange;
                var positionColumn = new List<string>();
                var listModel = new List<DataEntity>();
                // get column name
                for (int j = 1; j <= _range.Columns.Count; j++)
                {
                    string value = Convert.ToString(_range.Cells[1, j].Value2);
                    if(value != null)
                    {
                        positionColumn.Add(value);
                    }
                    else
                    {
                        positionColumn.Add("No Name");
                    }
                   

                }
                // get data to list
                var listData = new List<Dictionary<string, dynamic?>>();
                for (int i = 2; i <= _range.Rows.Count; i++)
                {
                    var listDataMap = new Dictionary<string, dynamic?>();
                    for (int j = 1; j <= _range.Columns.Count; j++)
                    {
                        var value = _range.Cells[i, j].Value2;
                        if (value != null)
                        {
                            listDataMap.Add(positionColumn[j - 1], value);
                        }
                    }
                    listData.Add(listDataMap);
                }
                // map data
                listData.ForEach(map =>
                {
                    DataEntity instance = new DataEntity();
                    Type type = instance.GetType();
                    type.GetProperties().ToList().ForEach(propertie =>
                    {
                        var attr = propertie.GetCustomAttribute<ExcelAttribute>();
                        if (attr != null)
                        {
                            switch (Type.GetTypeCode(propertie.PropertyType))
                            {
                                case TypeCode.Decimal:
                                    try
                                    {
                                        double dt = decimal.Parse(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {

                                    }
                                    break;

                                case TypeCode.Int32:
                                    try
                                    {
                                        int dt = int.Parse(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case TypeCode.Double:
                                    try
                                    {
                                        double dt = double.Parse(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case TypeCode.DateTime:
                                    try
                                    {
                                        DateTime dt = DateTime.FromOADate(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {

                                    }
                                    break;
                                case TypeCode.String:
                                    try
                                    {
                                        string dt = Convert.ToString(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case TypeCode.Boolean:
                                    try
                                    {
                                        bool dt = bool.Parse(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case TypeCode.Byte:
                                    try
                                    {
                                        byte dt = byte.Parse(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case TypeCode.Char:
                                    try
                                    {
                                        char dt = char.Parse(map[attr.Name]);
                                        propertie.SetValue(instance, dt, null);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                default: break;
                            }
                        }
                    });
                    listModel.Add(instance);
                });
                // insert to database
                await _context.Data.AddRangeAsync(listModel);
                await _context.SaveChangesAsync();
                return listModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Dispose()
        {
            _range = null;
            _xlApp?.Quit();
            _xlWorkSheet = null;
        }
    }
}
