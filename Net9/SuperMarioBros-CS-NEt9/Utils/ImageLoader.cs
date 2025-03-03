using System.Text.RegularExpressions;

namespace SuperMarioBros_CS_Net9.Utils;

internal static class ImageLoader
{
    // load an image from a file name in the "images" folder and return the bitmap
    public static Bitmap? LoadImage(string originalFileName)
    {
        var fileName = originalFileName;    

        // validate that the file name is not an empty string
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }

        // validate if fileName does not end with png, add the extension at the end
        if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
        {
            fileName += ".png";
        }

        string path = Path.Combine("images", fileName);
        if (!File.Exists(path))
        {
            // Try to strip numeric suffixes from filename like "tile0.png", "tile00.png", or "tile000.png"
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);

            // Use regex to remove trailing digits
            string fileNameWithoutNumbers = Regex.Replace(fileNameWithoutExtension, @"\d+$", "");
            string newFileName = fileNameWithoutNumbers + extension;

            path = Path.Combine("images", newFileName);
        }

        // if the file is not found, throw an exception
        if (!File.Exists(path))
        {
            // 
            // throw new FileNotFoundException($"Image file not found: {path}");
            return null;
        }
        return new Bitmap(path);
    }
}
