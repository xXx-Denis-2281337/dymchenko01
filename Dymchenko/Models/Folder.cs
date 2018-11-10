using System;
using System.ComponentModel.DataAnnotations;
using Dymchenko.Managers;
using Dymchenko.Tools;

namespace Dymchenko.Models
{
    public class Folder
    {
        #region Fields
        private Guid _id;
        private string _path;
        private int _filesCount = 0;
        private int _foldersCount = 0;
        private int _folderSize = 0;
        private string _folderRequestDate;
        private Guid _userId;
        #endregion

        #region Properties
        [Key]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public string Path
        {
            get => _path;
            set => _path = value;
        }
        public int FilesCount
        {
            get => _filesCount;
            set => _filesCount = value;
        }
        public int FoldersCount
        {
            get => _foldersCount;
            set => _foldersCount = value;
        }
        public int FolderSize
        {
            get => _folderSize;
            set => _folderSize = value;
        }
        public string FolderRequestDate
        {
            get => _folderRequestDate;
            set => _folderRequestDate = value;
        }
        public Guid UserId
        {
            get => _userId;
            set => _userId = value;
        }
        #endregion

        #region Constructors
        public Folder() { }

        public Folder(string path)
        {
            _id = Guid.NewGuid();
            _path = path;
            _filesCount = 0;
            _foldersCount = 0;
            _folderSize = 0;
            _folderRequestDate = DateTime.Now.ToString();
            _userId = StationManager.CurrentUser.Id;
        }
        #endregion

        public override string ToString()
        {
            return Path + "\nFiles count: " + FilesCount.ToString() + "\nFolders count: " + FoldersCount.ToString() + "\nFolder size (byte): " + FolderSize.ToString();
        }

        //Calculate folder size, amount of subfolders and amount of files
        internal void Calculate()
        {
            FolderCalculate.CalculateRec(this, _path);
        }
    }
}
