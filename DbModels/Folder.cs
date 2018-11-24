using Dymchenko.Tools;
using System;
using System.Runtime.Serialization;
using System.Data.Entity.ModelConfiguration;

namespace Dymchenko.Models
{
    [DataContract(IsReference = true)]
    public class Folder
    {
        #region Fields
        [DataMember]
        private Guid _id;
        [DataMember]
        private string _path;
        [DataMember]
        private int _filesCount = 0;
        [DataMember]
        private int _foldersCount = 0;
        [DataMember]
        private long _folderSize = 0;
        [DataMember]
        private string _folderRequestDate;
        [DataMember]
        private Guid _userId;
        [DataMember]
        private User _user;
        #endregion

        #region Properties
        private Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public string Path
        {
            private get => _path;
            set => _path = value;
        }
        public int FilesCount
        {
            get => _filesCount;
            private set => _filesCount = value;
        }
        public int FoldersCount
        {
            get => _foldersCount;
            private set => _foldersCount = value;
        }
        public long FolderSize
        {
            get => _folderSize;
            private set => _folderSize = value;
        }
        public string FolderRequestDate
        {
            get => _folderRequestDate;
            private set => _folderRequestDate = value;
        }
        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }
        public User User
        {
            get => _user;
            private set => _user = value;
        }
        #endregion

        #region Constructors
        public Folder() { }

        public Folder(string path, User user)
        {
            _id = Guid.NewGuid();
            _path = path;
            _filesCount = 0;
            _foldersCount = 0;
            _folderSize = 0;
            _folderRequestDate = DateTime.Now.ToString();
            _userId = user.Id;
        }
        #endregion

        public override string ToString()
        {
            return Path + "\nFiles count: " + FilesCount.ToString() + "\nFolders count: " + FoldersCount.ToString() + "\nFolder size (byte): " + FolderSize.ToString();
        }

        public class FolderEntityConfiguration : EntityTypeConfiguration<Folder>
        {
            public FolderEntityConfiguration()
            {
                ToTable("Folder");
                HasKey(k => k.Id);

                Property(p => p.Id)
                    .HasColumnName("Id")
                    .IsRequired();
                Property(p => p.Path)
                    .HasColumnName("Path")
                    .IsRequired();
                Property(p => p.FoldersCount)
                    .HasColumnName("FoldersCount")
                    .IsRequired();
                Property(p => p.FilesCount)
                    .HasColumnName("FilesCount")
                    .IsRequired();
                Property(p => p.FolderSize)
                    .HasColumnName("FolderSize")
                    .IsRequired();
                Property(p => p.FolderRequestDate)
                    .HasColumnName("FolderRequestDate")
                    .IsRequired();
            }
        }

        //Calculate folder size, amount of subfolders and amount of files
        public void Calculate()
        {
            FolderInfo fi = new FolderInfo();
            FolderCalculate.CalculateRec(fi, _path);
            FilesCount = fi.FilesCount;
            FoldersCount = fi.FoldersCount;
            FolderSize = fi.FolderSize;
        }
    }
}
