using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Katale_Server_Final.Side_Code
{
    public class ImageProcessor
    {
        string path = ConfigurationManager.AppSettings["LogosPath"];
            
        ///<summary>
        ///Retrieve Image as per PATH
        /// </summary>
        public byte[] GetImageByte(string Path)
        {
            Image image = Image.FromFile(Path);
            byte[] ImageArr;
            MemoryStream ms = new MemoryStream();

            if (image != null)
            {
                image.Save(ms, ImageFormat.Jpeg);
                ms.Close();

                ImageArr = ms.ToArray();
                return ImageArr;

            }

            else
            {

                return null;
            }

            
        }

        public Image GetImage(string Path)
        {
            Image image = Image.FromFile(Path);

            if (image != null)
            {
                return image;
            }
            else
            {
                return null;
            }
        }


        ///<summary>
        ///Retrieve Image as per PATH
        /// </summary>
        /// 
        public async Task SaveImageAsync(Image image,string path,string Name)
        {
            
            if (! await DirectoryExists(path))
            {
                Directory.CreateDirectory(path);
            }
            
                //Save Image here
                image.Save(path + Name, ImageFormat.Jpeg);
          
        }


        private async Task<bool> ImageExists(string Path)
        {

           
            if (File.Exists(Path))
            {
                return true;
            }
            else
            {
               
                
                return false;
            }
        }


        private async Task<bool> DirectoryExists(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else

            {
                return false;
            }
        }

       


    }
}