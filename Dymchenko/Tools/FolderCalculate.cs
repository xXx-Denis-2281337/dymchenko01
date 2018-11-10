using Dymchenko.Models;
using System.IO;
using System.Linq;

namespace Dymchenko.Tools
{
    internal class FolderCalculate
    {
        internal static void CalculateRec(Folder folder, string path)
        {
            //get all files
            var files = Directory.EnumerateFiles(path);
            folder.FilesCount += files.ToArray().Length;

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
