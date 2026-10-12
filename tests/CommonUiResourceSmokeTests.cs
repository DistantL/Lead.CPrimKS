// Run against the actual application directory after a full MSBuild /t:Rebuild.
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

internal static class CommonUiResourceSmokeTests
{
    [STAThread]
    private static int Main(string[] args)
    {
        try
        {
            string root = Path.GetFullPath(args[0]);
            var files = Directory.GetFiles(Path.Combine(root, "InnerLibs"), "*.dll", SearchOption.AllDirectories)
                .Concat(Directory.GetFiles(root, "*.dll")).ToArray();
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                string name = new AssemblyName(e.Name).Name + ".dll";
                string path = files.FirstOrDefault(file => string.Equals(Path.GetFileName(file), name, StringComparison.OrdinalIgnoreCase));
                return path == null ? null : Assembly.LoadFrom(path);
            };
            var assembly = Assembly.LoadFrom(Path.Combine(root, "InnerLibs", "Control", "Lead.CPrim.Common.dll"));
            string[] resources = assembly.GetManifestResourceNames();
            if (resources.Length != 11) throw new Exception("Expected 11 embedded resources, found " + resources.Length);
            foreach (string resource in resources)
                using (var stream = assembly.GetManifestResourceStream(resource))
                    if (stream == null || stream.Length == 0) throw new Exception("Missing resource: " + resource);
            var manager = new ResourceManager("Lead.CPrim.Common.Properties.Resources", assembly);
            foreach (string name in new[] { "blue", "gray", "green", "red", "yellow", "tsBtnEdit.Image", "tStripBtnAdd.Image", "tStripBtnDel.Image", "tStripBtnSave.Image" })
            {
                if (manager.GetObject(name) == null) throw new Exception("Missing image: " + name);
                Console.WriteLine("PASS image: " + name);
            }
            foreach (string name in new[] { "Lead.CPrim.EleCommon.Forms.EleConfigForm", "Lead.CPrim.EleCommon.Forms.ElementsUserView", "Lead.CPrim.TaskCommon.TaskConfigForm" })
            {
                using (var form = (Form)Activator.CreateInstance(assembly.GetType(name, true)))
                {
                    if (form.Controls.Count == 0 || form.Handle == IntPtr.Zero)
                        throw new Exception("Form initialization failed: " + name);
                    Console.WriteLine("PASS form constructor and handle: " + name);
                }
            }
            Console.WriteLine("PASS: 11 resource streams, 9 images, 3 form constructors/handles. No hardware or main program started.");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
    }
}
