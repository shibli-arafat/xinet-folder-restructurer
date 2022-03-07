using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Specialized;
using System.IO;

namespace XinetFolderFixer
{
    class Program
    {
        private static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            string excelPath = configuration.GetSection("excel-path").Value;
            //string specialChars = configuration.GetSection("special-chars").Value;
            string specialChars = @"/ [ & / \\ # , + = : ( ) $ ' ^ ! @ ~ % * ? < > { } ] – —";
            ExcelDataReader handler = new ExcelDataReader(excelPath);
            FolderFileRestructurer fHandler = new FolderFileRestructurer(handler, GetCharactersToReplace(specialChars));
            try
            {
                fHandler.RestructureFoldersAndFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //TestDirectory();
        }

        private static StringCollection GetCharactersToReplace(string specialChars)
        {
            StringCollection charactersToReplace = new StringCollection();
            string[] charArray = specialChars.Split(" ");
            for (int i = 0; i < charArray.Length; i++)
            {
                charactersToReplace.Add(charArray[i]);
            }
            charactersToReplace.Add(" ");
            return charactersToReplace;
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
        }

        private static void RenameFileTest1(FolderFileRestructurer restructurer)
        {
            string input = "Wired @^*$#!>---name--.txt";
            string expected = "wired-----------name.txt";
            string actual = restructurer.RenameFile(input);
            Console.WriteLine("Expected '{0}', \nactual '{1}'", expected, actual);
            Console.WriteLine("Passed? {0}", string.Compare(expected, actual) == 0);
        }

        private static void RenameFileTest2(FolderFileRestructurer restructurer)
        {
            string input = "Wired @^*$#!>-----.txt";
            string expected = "wired.txt";
            string actual = restructurer.RenameFile(input);
            Console.WriteLine("Expected '{0}', \nactual '{1}'", expected, actual);
            Console.WriteLine("Passed? {0}", string.Compare(expected, actual) == 0);
        }

        private static void RenameFileTest3(FolderFileRestructurer restructurer)
        {
            string input = "Wired -----@^*$#!>.txt";
            string expected = "wired.txt";
            string actual = restructurer.RenameFile(input);
            Console.WriteLine("Expected '{0}', \nactual '{1}'", expected, actual);
            Console.WriteLine("Passed? {0}", string.Compare(expected, actual) == 0);
        }

        private static void TestDirectory()
        {
            string current = Directory.GetCurrentDirectory();
            string parent = Directory.GetParent(current).FullName;

            Console.WriteLine("Current- {0}, Parent: {1}", current, parent);
        }
    }
}
