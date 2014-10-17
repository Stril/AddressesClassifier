using System.Windows.Forms;

namespace ExampleUsageService
{
   public static class Services
    {
       public static string OpenFolder()
       {
           var dialog = new FolderBrowserDialog();
           return dialog.ShowDialog() == DialogResult.OK ? dialog.SelectedPath : "";
       }
    }
}
