using System.Text;

namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = directoryInfo.GetFiles();

            Dictionary<string, List<FileDirectory>> fileDictionary = new Dictionary<string, List<FileDirectory>>();

            foreach (FileInfo file in files)
            {
                if (!fileDictionary.ContainsKey(file.Extension))
                {
                    fileDictionary.Add(file.Extension, new List<FileDirectory>());
                }

                fileDictionary[file.Extension].Add(new FileDirectory(file.Name, file.Length));
            }

            StringBuilder reportBuilder = new();
            CreateReport(fileDictionary, reportBuilder);
            return reportBuilder.ToString();
        }

        public static void CreateReport(Dictionary<string, List<FileDirectory>> fileDictionary, StringBuilder reportBuilder)
        {
            foreach (var kvp in fileDictionary.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                reportBuilder.AppendLine(kvp.Key);

                foreach (FileDirectory file in kvp.Value.OrderBy(f => f.SizeKb))
                {
                    reportBuilder.AppendLine($"--{file.Name} - {file.SizeKb}kb");
                }
            }
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(desktopPath, textContent);
        }
    }

    public class FileDirectory
    {
        public string Name { get; set; }

        public float SizeKb { get; set; }

        public FileDirectory(string name, long sizeBytes)
        {
            Name = name;
            SizeKb = (float)sizeBytes / 1024;
        }
    }
}