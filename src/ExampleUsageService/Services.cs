using System.Windows.Forms;

namespace ExampleUsageService
{
   public static class Services
    {
       public static string OpenFolder(string initialPath = "")
       {
           var dialog = new FolderBrowserDialog();
           if (!string.IsNullOrEmpty(initialPath))
               dialog.SelectedPath = initialPath;
           return dialog.ShowDialog() == DialogResult.OK ? dialog.SelectedPath : "";
       }
    }
}
