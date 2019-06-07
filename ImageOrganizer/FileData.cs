
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.IO;

namespace ImageOrganizer
{

    public class FileData
    {

        public enum FolderCreation
        {
            NOTHING,
            CURRENT_IMAGE_FOLDER,
            YEAR_MONTH,
            YEAR_MONTH_DAY,
            CAMERA,
            ENTER
        }

        public enum FileNameExistsAction
        {
            ADD_SUFFIX,
            TERMINATE,
        }

        public enum FileRenameOptions
        {
            NO,
            TIMESTAMP,
            PARENT_FOLDER_PREFIX,
            PARENT_FOLDER_IF_TEXT_EXISTS
        }

        public const string NO_CAMERA_DATA = "NO_CAMERA_DATA";
        public static readonly string[] EXTENSIONS = { "JPG", "JPEG", "BMP", "PNG" };
        private string checkSum;

        public FileInfo Info { get; }        
        private Dictionary<string, object> fileProperties;

        public FileData(System.IO.FileInfo info)
        {
            this.Info = info;
        }

        public System.DateTime GetCreationDate()
        {
            return Info.CreationTime;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj, false);
        }


        public bool Equals(object obj, bool ignoreFileName)
        {

            FileData data = (FileData)obj;

            if (!ignoreFileName && !data.Info.Name.Equals(this.Info.Name, System.StringComparison.OrdinalIgnoreCase)) return false;

            if (data.Info.Length != this.Info.Length) return false;

            if (!data.CheckSum().Equals(CheckSum())) return false;

            return true;

        }

        public string CheckSum()
        {

            if (checkSum == null)
            {

                System.Data.HashFunction.xxHash.xxHashConfig config = new System.Data.HashFunction.xxHash.xxHashConfig
                {
                    HashSizeInBits = 64
                };

                using (FileStream fs = File.OpenRead(Info.FullName))
                {
                    System.Data.HashFunction.IHashValue xxHash = System.Data.HashFunction.xxHash.xxHashFactory.Instance.Create(config).ComputeHash(fs);
                    checkSum = xxHash.AsBase64String();
                }

            }

            return checkSum;

        }

        public DateTime? ItemDate()
        {
            if (FileProperties().TryGetValue("System.ItemDate", out object itemDate))
            {

                DateTime date = (DateTime)itemDate; 

                // vjerojatno je zmrdano pa treba vidjeti dal drugi datumi imaju više smisla
                if (date.Minute == 0 && date.Day == 1 && date.Month == 1)
                {
                    if (FileProperties().TryGetValue("System.DateModified", out object modifiedDate))
                    {
                        DateTime modifDate = (DateTime)modifiedDate;
                        if (date == modifDate) return date;
                        if (modifDate.Minute != 0 || date.Day != 1 || date.Month != 1) return modifDate;
                    }
                        
                }

                return date;
            }

            return null;

        }

        public string CameraProducerModel()
        {

            string cameraData = NO_CAMERA_DATA;

            if (FileProperties().TryGetValue("System.Photo.CameraManufacturer", out object camera))
            {
                cameraData = (string)camera;
            }

            if (FileProperties().TryGetValue("System.Photo.CameraModel", out object model))
            {
                cameraData = (cameraData.Equals(NO_CAMERA_DATA) ? "" : (cameraData + " ")) + (string)model;
            }

            return cameraData;

        }

        private Dictionary<string, object> FileProperties()
        {

            if (fileProperties == null)
            {
                fileProperties = new Dictionary<string, object>();
                ShellPropertyCollection props = new ShellPropertyCollection(Info.FullName);
                foreach (IShellProperty prop in props)
                {
                    if (prop.CanonicalName == null) continue;
                    fileProperties.Add(prop.CanonicalName, prop.ValueAsObject);                    
                }
            }

            return fileProperties;
        }

    }

}