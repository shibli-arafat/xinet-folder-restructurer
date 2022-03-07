namespace XinetFolderFixer
{
    internal class ExcelData
    {
        public string InputPath { get; set; }
        public string OutputPath { get; set; }

        public override string ToString()
        {
            string data = string.Format(@"Input Path: {0}, Output Path: {1}", this.InputPath, this.OutputPath);
            return data;
        }
    }
}