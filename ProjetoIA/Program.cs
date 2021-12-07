using System.Drawing;
using System.Drawing.Imaging;

namespace ReconhecimentoCsharp
{

    //        private static void cultureInfo2()

    public class Program
    {
        const string path = "C:\\Users\\giovanna.marques\\2. ProjetoIA\\ImagensTeste\\";
        const string pathSave = "C:\\Users\\giovanna.marques\\2. ProjetoIA\\ImagensConvertidasEmCinza\\";
        static string[] extensions = new string[] { "jpg", "jpeg", "png"};


        static void Main(string[] args)
        {

            Console.WriteLine("\n Arquivos nas extensões não validadas: \n ");
            string arquivosnaovalidados = "*.pdf,*.gif,*.bmp,*.wmf,*.emf,*.xbm,*.ico,*.eps,*.tif,*.tiff,*.g01,*.g02,*.g03,*.g04,*.g05,*.g06,*.g07,*.g08";

            foreach (string arqnaoval in Directory.GetFiles("C:\\Users\\giovanna.marques\\2. Csharp\\ImagensTeste", "*.*", SearchOption.AllDirectories).Where(s => arquivosnaovalidados.Contains(Path.GetExtension(s).ToLower())))

            {
                Console.WriteLine(arqnaoval);

            }

            var files = new List<string>();
            Console.WriteLine($"\n Arquivos sendo convertidos para .Jpeg:\n ");

            foreach (var extension in extensions)
            {
                string[] filesExtensions = Directory.GetFiles(path, $"*.{extension}", SearchOption.AllDirectories);

                files.AddRange(filesExtensions);
            }

            files.ForEach(x => {
                convertImageToBW(x);
                Console.WriteLine(x);
            });
        }

        static void convertImageToBW(string path)
        {
            Bitmap image = new Bitmap(path);
            int x, y;
            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayScale = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));
                    Color newColor = Color.FromArgb(pixelColor.A, grayScale, grayScale, grayScale);
                    image.SetPixel(x, y, newColor);
                }
            }
            image.Save(pathSave + Guid.NewGuid() + ".jpeg", ImageFormat.Jpeg);
        }
    }
}