using System.Collections.Generic;
using System.Text;

namespace XinetFolderFixer
{
    internal class ExcelDataCollection : List<ExcelData>
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in this)
            {
                builder.AppendLine(item.ToString());
            }
            return builder.ToString();
        }
    }
}