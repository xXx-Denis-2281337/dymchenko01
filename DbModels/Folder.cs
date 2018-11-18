﻿using Dymchenko.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

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
        private User _user;
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
        public User User
        {
            get => _user;
            set => _user = value;
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