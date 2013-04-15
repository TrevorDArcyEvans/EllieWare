//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

namespace EllieWare.Common
{
  public class FileExtensions
  {
    public const string AllFilesFilter = "All files (*.*)|*.*";

    private const string InternalPdfFilesFilter = 
                          "Adobe PDF files (*.pdf)|*.pdf|";

    public const string PdfFilesFilter = InternalPdfFilesFilter + AllFilesFilter;

    public const string PdfFileExtension = ".pdf";

    public const string ZipFileExtension = ".zip";

    private const string InternalZipFilesFilter = 
                          "Compressed archive files (*.zip)|*.zip|";

    public const string ZipFilesFilter = InternalZipFilesFilter + AllFilesFilter;

    public const string InternalImageFilesFilter = 
                            "GIF Graphics Interchange Format (*.gif)|*.gif|" +
                            "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|" +
                            "PNG Portable Network Graphics Format (*.png)|*.png|" +
                            "TIFF Tag Image File Format (*.tif)|*.tif;*.tiff|" +
                            "Device Independent Bitmap (*.bmp)|*.bmp|";

    public const string ImageFilesFilter = InternalImageFilesFilter + AllFilesFilter;

    private const string InternalPythonFilesFilter =
                          "Python script files (*.py)|*.py|";

    public const string PythonFilesFilter = InternalPythonFilesFilter + AllFilesFilter;
  }
}
