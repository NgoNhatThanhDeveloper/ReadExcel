

namespace ReadExcel.AttributeCustome
{
    [AttributeUsage(AttributeTargets.Property)]

    public class ExcelAttribute : Attribute
    {
        public string Name { get; set; }
        public ExcelAttribute(string name)
        {
            Name = name;
        }
    }
}
