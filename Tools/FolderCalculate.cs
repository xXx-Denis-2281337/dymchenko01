using System.IO;
using System.Linq;

namespace Dymchenko.Tools
{
    public class FolderInfo
    {
        private int _filesCount = 0;
        private int _folderSize = 0;
        private int _foldersCount = 0;

        public int FilesCount { get; set;}
        public int FolderSize { get; set; }
        public int FoldersCount { get; set; }
    }

    public class FolderCalculate
    {
        public static void CalculateRec(FolderInfo folder, string path)
        {
            //get all files
            var files = Directory.EnumerateFiles(path);
            folder.FilesCount += files.Count();

            // get the sizeof all files in the current directory
            var currentSize = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();
            folder.FolderSize += (int)currentSize;

            //get all folders
            var folders = Directory.EnumerateDirectories(path);
            folder.FoldersCount += folders.ToArray().Length;

            // recursive for all subfolders
            foreach (string dir in folders)
            {
                CalculateRec(folder, dir);
            }
        }
    }
}
