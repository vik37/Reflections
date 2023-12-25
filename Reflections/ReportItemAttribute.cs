namespace Reflections
{   
    public class ReportItemAttribute : Attribute
    {
        public string Heading { get; set; }
        public string Units { get; set; }
        public string Format { get; set; }
        public int ColumnOrder { get; }

        public ReportItemAttribute(int columnOredr)
        {
            ColumnOrder = columnOredr;    
        }
    }
}
