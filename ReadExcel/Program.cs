using ReadExcel.ClassService;
using ReadExcel.Db;

// cách dùng
var dbContext = new DbDataContext();
// truyền dbContext vào contructor
var read = new ReadFileExcel(dbContext);
// link trỏ đến file excel trong máy local.
var path = @"C:\Users\ngonh\Documents\Zalo Received Files\HP SN Scan v6 (version 2)_1.xlsm";
var list = await read.ReadFileSheetAutoMap(path);
//or
//var lisT = await read.ReadFileSheetByPosition(path);
// ReadFileSheetAutoMap sẽ xử lý chậm hơn ReadFileSheetByPosition bù lại sẽ map data chính xác vào các cột dữ liệu hơn (chậm hơn 5s khi cùng xử lý 415 row data)