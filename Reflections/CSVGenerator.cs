using System.Reflection;
using System.Text;

namespace Reflections
{
    public class CSVGenerator<T>
    {
        private IEnumerable<T> _books;
        private string _fileName;
        private Type _type;

        public CSVGenerator(IEnumerable<T> books, string filename)
        {
            _books = books;
            _fileName = filename;
            _type = typeof(T);
        }

        public void Generator()
        {
            var rows = new List<string>();

            rows.Add(CreateHeader());

            foreach (var book in _books)
            {
                rows.Add(CreateRows(book));
            }
            File.WriteAllLines($"{_fileName}.csv",rows,Encoding.UTF8);
        }

        #region Creating Initial Strig Headers Intended for CSV Files Column Names
        // private string CreateHeader() => "Author,Title,DateOfPublish,Rating";
        #endregion

        private string CreateHeader()
        {
            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderedProperties = properties.OrderBy(p => p.GetCustomAttribute<ReportItemAttribute>().ColumnOrder);

            var sb = new StringBuilder();

            #region Creating Dynamic String Headers Using C# Reflection
            //foreach(var property in properties)
            //{
            //    sb.Append(property.Name).Append(",");
            //}
            #endregion

            foreach (var property in orderedProperties)
            {
                var attr = property.GetCustomAttribute<ReportItemAttribute>().Heading;
                sb.Append(attr ?? property.Name).Append(",");
            }

            return sb.ToString()[..^1];
        }

        private string CreateRows(T item)
        {
            var sb = new StringBuilder();

            #region Creating Initial Strig Intended for CSV Files Rows
            //sb.Append(item.Title).Append(",");
            //sb.Append(item.Author).Append(",");
            //sb.Append(item.DateOfPublish.ToShortDateString()).Append(",");
            //sb.Append(item.Rating).Append(",");
            #endregion

            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            #region Getting Dynamic Values and Dynamic Types
            //foreach (var property in properties)
            //{
            //    sb.Append(CreateItem((dynamic)property.GetValue(item))).Append(",");
            //}
            #endregion

            #region Creating Dynamic String Rows (Values) Using C# Reflection
            //foreach (var property in properties)
            //{
            //    sb.Append(CreateItem(property, item)).Append(",");
            //}
            #endregion

            var orderedProperties = properties.OrderBy(p => p.GetCustomAttribute<ReportItemAttribute>().ColumnOrder);

            foreach(var property in orderedProperties)
            {
                sb.Append(CreateItem(property, item)).Append(",");
            }

            return sb.ToString()[..^1];

            // [..^1] Remove the last comma , from the row 
        }

        #region Dynamic Overloading
        //private string CreateItem(object item) => item.ToString();
        //private string CreateItem(DateTime item) => item.ToShortDateString();
        #endregion

        private string CreateItem(PropertyInfo property, T item)
        {
            var attr = property.GetCustomAttribute<ReportItemAttribute>();

            return string.Format($"{{0:{attr.Format}}}{attr.Units}", property.GetValue(item));
        }       
    }
}
