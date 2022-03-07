using ExcelDataReader;
using System.IO;

namespace XinetFolderFixer
{
    public class ExcelDataReader
    {
        private string _FilePath;
        public ExcelDataReader(string filePath)
        {
            _FilePath = filePath;
        }

        internal ExcelDataCollection ReadData()
        {
            ExcelDataCollection dataCollection = new ExcelDataCollection();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(_FilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        if (reader.Name == "Brand Elements"
                            ||reader.Name == "GAL"
                            || reader.Name == "Global Automation"
                            || reader.Name == "Marketing Assets")
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                ExcelData data = new ExcelData();
                                data.InputPath = reader.GetValue(0).ToString().TrimStart('/').ToLower();
                                data.OutputPath = reader.GetValue(1).ToString().TrimStart('/').ToLower();
                                dataCollection.Add(data);
                            }
                        }
                    } while (reader.NextResult()); //Move to NEXT SHEET
                }
            }
            return dataCollection;
        }
    }
}