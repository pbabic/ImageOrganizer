using System;

public class FileData
{

    public enum FolderCreation
    {
        NOTHING,
        CURRENT_IMAGE_FOLDER,
        YEAR_MONTH,
        YEAR_MONTH_DAY,
        CAMERA,
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
    }

    public const string[] EXTENSIONS = { "JPG", "JPEG", "BMP", "PNG" };

    public FileData()
	{
	}
}
