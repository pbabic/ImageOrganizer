using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ImageOrganizer
{
    class FileProcessor
    {
        public List<FileData> Files { get; set; }
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void FindFiles(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;

            string path = (string)Properties.Settings.Default["sourceFolder"];
            string filextensions = (string)Properties.Settings.Default["exstensions"];
            bool checkSubfolders = (bool)Properties.Settings.Default["includeSubfolders"];

            string[] extensions = filextensions.Split(',');

            Files = new List<FileData>();


            GetAllAccessibleFiles(path, delegate (FileInfo f)
                {
                    if (extensions.Length == 1 && extensions[0].Equals("")) return true;
                    if (extensions.Length > 0) {
                        string v = Path.GetExtension(f.Name);
                        v = v.Length > 0 && v.Substring(0, 1).Equals(".") ? v.Substring(1) : v;
                        return extensions.Contains(v.ToUpper());
                    }

                    return true;
                },

            Files, delegate (string name)
                {
                    worker.ReportProgress(1, name);
                    return !worker.CancellationPending;
                },
            checkSubfolders);

        }

        private static void GetAllAccessibleFiles(string rootPath, Func<FileInfo, bool> checkExtension, List<FileData> alreadyFound, Func<string, bool> mayContinue, bool checkSubfolders)
        {

            if (!mayContinue(rootPath))
            {
                return;
            }

            DirectoryInfo di = new DirectoryInfo(rootPath);

            try
            {

                if (checkSubfolders)
                {

                    var dirs = di.EnumerateDirectories();
                    foreach (DirectoryInfo dir in dirs)
                    {
                        if (!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                        {

                            if (!mayContinue(dir.FullName))
                            {
                                return;
                            }

                            GetAllAccessibleFiles(dir.FullName, checkExtension, alreadyFound, mayContinue, checkSubfolders);
                        }

                    }

                }

                var files = di.GetFiles();
                foreach (FileInfo s in files)
                {
                    if (!mayContinue(s.FullName))
                    {
                        return;
                    }
                    if (checkExtension(s))
                    {
                        alreadyFound.Add(new FileData(s));
                    }
                }
            }
            catch (UnauthorizedAccessException exc)
            {
                logger.Debug("File or folder not assesible", exc);
                // life goes on...
            }

        }

        internal void ProcessFiles(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;

            Dictionary<string, FileData> destinationFileDatas = new Dictionary<string, FileData>();

            for (int elIndex = 0; elIndex < Files.Count; elIndex++)
            {

                FileData file = Files[elIndex];

                //				if (file.getFile().getName().equals("DSC00705.JPG")) {
                //					System.err.println("x");
                //				}


                if (worker.CancellationPending)
                {
                    logger.Debug("Cancel file process...");
                    return;
                }

                //double result = (double)elIndex / size;

                //result = result * 100;

                worker.ReportProgress(elIndex, file.Info.FullName);

                logger.Debug("File processing: " + file.Info.FullName);

                if (file.Info.Length == 0)
                {
                    logger.Debug("File size 0. Possibly corrupt.");
                    continue;
                }

                string destinationFolder = DestinationFolder(file);

                string destFile = destinationFolder + Path.DirectorySeparatorChar + RenameFile(file);

                if (IsDuplicateFile(file, destFile, destinationFileDatas))
                {
                    logger.Info("File allready exists in destination folder");
                    continue;
                }

                if (File.Exists(destFile))
                {

                    if (file.Equals(new FileData(new FileInfo(destFile))))
                    {
                        if (ProcessDuplicate(file)) continue;
                        else return;
                    }
                    else
                    {

                        Enum.TryParse((string)Properties.Settings.Default["fileNameExistsAction"], out FileData.FileNameExistsAction fileNameExistsAction);

                        if (fileNameExistsAction == FileData.FileNameExistsAction.ADD_SUFFIX)
                        {

                            string name = Path.GetFileNameWithoutExtension(destFile);
                            string extension = Path.GetExtension(destFile);

                            string previousRenamedFile = null;
                            int[] suffixes = { 0, 0, 0 };

                            for (int i = 1; ; i++)
                            {

                                if (i == 1000 && suffixes[2] < 999) i = 1;

                                string suffix = "";

                                if (suffixes[0] == 999)
                                {
                                    suffix = "999";
                                    if (suffixes[1] == 999)
                                    {
                                        suffix = suffix + "_999";
                                        if (suffixes[2] == 999)
                                        {
                                            // fuck you!
                                            suffix = suffix + "_" + i;
                                        }
                                        else
                                        {
                                            suffixes[2] = i;
                                            suffix = suffix + "_" + string.Format("{0:000}", suffixes[2]);
                                        }
                                    }
                                    else
                                    {
                                        suffixes[1] = i;
                                        suffix = suffix + "_" + string.Format("{0:000}", suffixes[1]);
                                    }
                                }
                                else
                                {
                                    suffixes[0] = i;
                                    suffix = suffix + string.Format("{0:000}", suffixes[0]);
                                }

                                string newPath = Path.GetDirectoryName(destFile) + Path.DirectorySeparatorChar + name + "_" + suffix + extension;

                                if (!File.Exists(newPath))
                                {
                                    destFile = newPath;
                                    break;
                                }
                                else if (previousRenamedFile == null)
                                {
                                    previousRenamedFile = newPath;
                                }
                                else if (new FileData(new FileInfo(newPath)).Equals(new FileData(new FileInfo(previousRenamedFile)), true))
                                {
                                    //if (!ProcessDuplicate(new FileData(new FileInfo(newPath)))) return;
                                    goto outher;
                                }
                                else
                                {
                                    previousRenamedFile = newPath;
                                }
                            }
                        }
                        //else if (fileNameExistsAction == FileData.FileNameExistsAction.SKIP)
                        //{
                        //    continue;
                        //}

                        else if (fileNameExistsAction == FileData.FileNameExistsAction.TERMINATE)
                        {

                            //String fileWithSameNameExists = String.format(messages.getString("FileWithTheSameNameExistsTerminate"), destFile.getFileName(), destFile.getParent());
                            //if (!silentMode)
                            //{
                            //    RtaMessageDialog.openWarning(fileWithSameNameExists);
                            //}
                            logger.Info("File with the same name exists in destination folder: " + destFile);
                            return;
                        }
                    }

                }

                bool move = (bool)Properties.Settings.Default["move"];

                try
                {

                    Directory.GetParent(destFile).Create();

                    if (move)
                    {
                        File.Move(file.Info.FullName, destFile);
                    }
                    else
                    {
                        File.Copy(file.Info.FullName, destFile);
                    }

                    destinationFileDatas.Add(destFile, file);

                    reportFileProcessStatus(file.Info.FullName, destFile, move, true, null);

                }
                catch (Exception error)
                {
                    reportFileProcessStatus(file.Info.FullName, destFile, move, false, error);
                    //if (!RtaMessageDialog.openQuestion(String.format(messages.getString("ErrorProcessing"), conf.isMove() ? "moving" : "copying", file.getPath(), destFile, conf.isMove()))) return;
                }

            outher:;

            }

        }

        private string FixPathCharachters(string v)
        {            
            string invalid = new string(Path.GetInvalidPathChars()) + @"\";

            foreach (char c in invalid)
            {
                v = v.Replace(c.ToString(), "");
            }

            return v.Trim();
        }

        private bool IsDuplicateFile(FileData file, string destFile, Dictionary<string, FileData> destinationFiles)
        {
            DirectoryInfo destinationDirectory = Directory.GetParent(destFile);

            if (!destinationDirectory.Exists) return false;

            if (destinationFiles.TryGetValue(destFile, out FileData destFileData))
            {
                if (file.Equals(destFileData)) return true;
            }

            return (destinationDirectory.EnumerateFiles().Any(item => {

                if (destinationFiles.TryGetValue(item.FullName, out FileData destFileData2))
                {
                    return file.Equals(destFileData2, true);
                }                
                else
                {
                    FileData newDestFile = new FileData(item);
                    destinationFiles.Add(item.FullName, newDestFile);
                    return newDestFile.Equals(file, true);
                }
                
            }));

        }

        private void reportFileProcessStatus(string source, string destination, bool move, bool sucess, Exception error)
        {
            if (sucess)
                logger.Info(String.Format("Successfuly {0} {1} to {2}", move ? "moved" : "copied", source, destination));
            else
                logger.Error(String.Format("Error {0} {1} to {2}", move ? "moving" : "copying", source, destination), error);
        }
        /**
 * 
 * @param conf
 * @param file
 * @return true if process may continue
 */
        private bool ProcessDuplicate(FileData file)
        {
            logger.Debug("Destination folder already contain equal file: " + file.Info.Name);

            bool move = (bool)Properties.Settings.Default["move"];

            if (move)
            {

                try
                {
                    File.Delete(file.Info.FullName);
                }

                // Catch exception if the file was already copied.
                catch (Exception error)
                {
                    logger.Error(error);
                    return false;
                }

            }
            return true;
        }

        private string RenameFile(FileData file)
        {

            Enum.TryParse((string)Properties.Settings.Default["renameOption"], out FileData.FileRenameOptions value);

            switch (value)
            {
                case FileData.FileRenameOptions.TIMESTAMP:
                    return file.GetCreationDate().ToString("yyyyMMddHHmmss") + Path.GetExtension(file.Info.Name);
                case FileData.FileRenameOptions.PARENT_FOLDER_PREFIX:
                    return file.Info.Directory.Name + "-" + file.Info.Name;
                case FileData.FileRenameOptions.PARENT_FOLDER_IF_TEXT_EXISTS:

                    foreach (char c in file.Info.Directory.Name)
                    {
                        if (Char.IsLetter(c)) return file.Info.Directory.Name + "-" + file.Info.Name;
                    }

                    break;
                case FileData.FileRenameOptions.NO:
                default:
                    break;
            }

            return file.Info.Name;
        }

        private string DestinationFolder(FileData data)
        {

            string destionationFolder = (string)Properties.Settings.Default["destinationFolder"];

            Enum.TryParse((string)Properties.Settings.Default["firstLevelFolder"], out FileData.FolderCreation value1);
            destionationFolder = FolderForConfLevel(value1, data, destionationFolder, (bool)Properties.Settings.Default["findCameraData"], (string)Properties.Settings.Default["firstLevelFolderCustom"]);

            Enum.TryParse((string)Properties.Settings.Default["secondLevelFolder"], out FileData.FolderCreation value2);
            destionationFolder = FolderForConfLevel(value2, data, destionationFolder, (bool)Properties.Settings.Default["findCameraData"], (string)Properties.Settings.Default["secondLevelFolderCustom"]);

            Enum.TryParse((string)Properties.Settings.Default["thirdLevelFolder"], out FileData.FolderCreation value3);
            destionationFolder = FolderForConfLevel(value3, data, destionationFolder, (bool)Properties.Settings.Default["findCameraData"], (string)Properties.Settings.Default["thirdLevelFolderCustom"]);

            return destionationFolder;

        }

        private string FolderForConfLevel(FileData.FolderCreation folderCreation, FileData data, string destionationFolder, bool useCameraDataFromImageCreatedSameDay, string customFolder)
        {
            if (folderCreation != FileData.FolderCreation.NOTHING)
            {
                string folder = "";
                switch (folderCreation)
                {
                    case FileData.FolderCreation.CAMERA:
                        folder = data.CameraProducerModel();
                        // nije slika ili nema podataka o kameri pa tražimo sliku kreiranu isti dan iz istog foldera da joj skinemo podatke
                        if (useCameraDataFromImageCreatedSameDay && folder.Equals(FileData.NO_CAMERA_DATA))
                        {
                            FileInfo[] files = data.Info.Directory.GetFiles();

                            FileData fileData = null;
                            
                            foreach (FileInfo info in files)
                            {

                                string extension = Path.GetExtension(info.Name);

                                if (extension.StartsWith(".")) extension = extension.Substring(1);

                                if (FileData.EXTENSIONS.Contains(extension.ToUpper()))
                                {

                                    FileData tmpFileData = new FileData(info);
                                    if (
                                        !FileData.NO_CAMERA_DATA.Equals(tmpFileData.CameraProducerModel()))
                                    {
                                        fileData = tmpFileData;
                                        break;
                                    }
                                }
                                
                            }

                            if (fileData != null)
                            {                                
                                folder = FixPathCharachters(fileData.CameraProducerModel());
                            }
                            else folder = FileData.NO_CAMERA_DATA;

                        }
                        break;
                    case FileData.FolderCreation.YEAR_MONTH:
                        folder = data.ItemDate().Value.ToString("yyyy.MM");
                        break;
                    case FileData.FolderCreation.YEAR_MONTH_DAY:
                        folder = data.ItemDate().Value.ToString("yyyy.MM.dd");                        
                        break;
                    case FileData.FolderCreation.CURRENT_IMAGE_FOLDER:
                        folder = Path.GetPathRoot(data.Info.FullName).Equals(data.Info.Directory.Name) ? "" : data.Info.Directory.Name;
                        break;
                    case FileData.FolderCreation.ENTER:
                        folder = customFolder;
                        break;
                    default:
                        break;
                }

                destionationFolder = @destionationFolder + Path.DirectorySeparatorChar + @folder;
            }
            return destionationFolder;
        }

    }

}