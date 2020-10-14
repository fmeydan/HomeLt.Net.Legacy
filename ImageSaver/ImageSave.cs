using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;

namespace ImageSaver
{
    public class ImageSave:IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// Saves Multiple Files Default Location "/Medias/ImageName" and returns Image Path
        /// </summary>
        /// <param name="images"></param>
        /// <param name="ImageName"></param>
        /// <returns></returns>
        public  List<string> SaveMultipleImageSingleName(HttpPostedFileBase[] images, string ImageName)
        {
            List<string> imagePaths = new List<string>();
            if (images != null)
            {
                foreach (var item in images)
                {
                    string imageName = item.FileName;
                    string[] fileNameByDots = imageName.Split('.');
                    string extansion = fileNameByDots[fileNameByDots.Length - 1];
                    imageName.Replace(extansion, "");
                    imageName = new FileNamer().ToString();
                    //using (FileNamer namer = new FileNamer())
                    //{
                    //    imageName = namer.ConvertTRCharToENChar(imageName);
                    //    ImageName = namer.ConvertTRCharToENChar(ImageName);
                    //}
                    string newFileName = ImageName + "_" + imageName;
                    string filePath = HttpContext.Current.Server.MapPath("~/Medias/" + ImageName);
                    if (Directory.Exists(filePath))
                    {

                        string date = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                        filePath = filePath + "/" + date;
                        Directory.CreateDirectory(filePath);
                        string finalName2 = Path.Combine(filePath, newFileName);
                        item.SaveAs(finalName2 + "." + extansion);

                        string dbPath2 = ("/Medias/") + ImageName + "/" + date + "/" + newFileName + "." + extansion;
                        imagePaths.Add(dbPath2);
                        return imagePaths;
                    }
                    Directory.CreateDirectory(filePath);
                    string finalName = Path.Combine(filePath, newFileName);
                    item.SaveAs(finalName + "." + extansion);

                    string dbPath = ("/Medias/") + ImageName + "/" + newFileName + "." + extansion;
                    imagePaths.Add(dbPath);

                }
            }
            return imagePaths;
        }


        /// <summary>
        /// Save an image to selected path
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Name"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string SaveImage(HttpPostedFileBase Image,string Name,string Path)
        {
            if (Image!=null)
            {
                string extansion = System.IO.Path.GetExtension(Image.FileName);
                Directory.CreateDirectory(Path);
                string savedImagePath = Path + "/" + new FileNamer().ConvertTRCharToENChar(Name) + extansion;
                
                Image.SaveAs(savedImagePath);
                return (savedImagePath);

            }
            return "";

        }



        public List<string> SaveMultiImage(HttpPostedFileBase[] Image, string Name, string Path)
        {
            List<string> paths = new List<string>() ;
            if (Image != null)
            {
                
                foreach (var item in Image)
                {
                    string extansion = System.IO.Path.GetExtension(item.FileName);
                    Directory.CreateDirectory(Path);
                    string savedImagePath = Path + "/" + new FileNamer().ConvertTRCharToENChar(Name) + extansion;

                    item.SaveAs(savedImagePath);
                    paths.Add(savedImagePath);
                }
               
                return (paths);

            }
            return paths;

        }


        public  string DeleteImage(string path, string name)
        {

            string imageServerLocation = HttpContext.Current.Server.MapPath(path);
            string[] filenameSeperated = path.Split('/');
            string fileName = filenameSeperated[filenameSeperated.Length - 1];
            string parent = Directory.GetParent(imageServerLocation).ToString();
            string deletedFolderName = parent + "_" + "Deleted";
            //string imageFolderName = "";
            //for (int i = 0; i < filenameSeperated.Length - 1; i++)
            //{
            //    imageFolderName += filenameSeperated[i] + "/";
            //}
            //Directory.CreateDirectory(deletedFolderName);
            Directory.Move(parent, deletedFolderName);
            name = new FileNamer().ConvertTRCharToENChar(name).ToString();
            //using (FileNamer namer = new FileNamer())
            //{
            //    name = namer.ConvertTRCharToENChar(name);
            //}
            return "/Medias/" + name + "_Deleted" + "/" + fileName;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ImageSave()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}