using System;
using System.Collections.Specialized;
using System.IO;

namespace XinetFolderFixer
{
    public class FolderFileRestructurer
    {
        private StringCollection _CharactersToReplace;
        private ExcelDataReader _ExcelFileHandler;

        public FolderFileRestructurer(ExcelDataReader excelFileHandler, StringCollection charactersToReplace)
        {
            _ExcelFileHandler = excelFileHandler;
            _CharactersToReplace = charactersToReplace;
        }

        public void RestructureFoldersAndFiles()
        {
            Console.WriteLine("---The tool started---");
            Console.WriteLine("Reading data from excel file...");
            ExcelDataCollection dataCollection = _ExcelFileHandler.ReadData();
            foreach (ExcelData data in dataCollection)
            { 
                string outputFolder = GetFullPathInParentDirectory(data.OutputPath);
                string inputFolder = GetFullPathInParentDirectory(data.InputPath);
                Console.WriteLine("Creating folder {0}", outputFolder);
                CreateFolder(outputFolder);
                Console.WriteLine("Moving files from folder {0} to folder {1}", inputFolder, outputFolder);
                RenameFilesAndMove(inputFolder, outputFolder);
            }
            Console.WriteLine("---The tool ended---");
        }

        private string GetFullPathInParentDirectory(string folderName)
        {
            string parent = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string fullPath = Path.Combine(parent, folderName);
            return fullPath;
        }

        public void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                Console.WriteLine("The folder {0} already exists", path);
            }
        }

        private void RenameFilesAndMove(string fromFolder, string toFolder)
        {
            if (!Directory.Exists(fromFolder))
            {
                Console.WriteLine("Directory {0} doesn't exist", fromFolder);
                return;
            }
            DirectoryInfo dirInfo = new DirectoryInfo(fromFolder);
            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                string renamedFile = RenameFile(fileInfo.Name);
                string destFilePath = Path.Combine(toFolder, renamedFile);
                if (!File.Exists(destFilePath))
                {
                    fileInfo.MoveTo(destFilePath);
                }
            }
        }

        public string RenameFile(string fileName)
        {
            string newName = Path.GetFileNameWithoutExtension(fileName);
            foreach (string character in _CharactersToReplace)
            {
                newName = newName.Replace(character, "-");
            }
            newName = newName.TrimEnd('-');
            newName = string.Format("{0}{1}", newName, Path.GetExtension(fileName));
            return newName.ToLower();
        }
    }
}
