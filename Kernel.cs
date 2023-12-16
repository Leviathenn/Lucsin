using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Sys = Cosmos.System;

namespace Lucsin
{
    public class Kernel: Sys.Kernel
    {
        private bool hasRanC = false;
        public static CosmosVFS VFS = new CosmosVFS();
        protected override void BeforeRun()
        {
            Console.WriteLine("Registering filesystem...");
            VFSManager.RegisterVFS(VFS,true,false);
            Console.WriteLine("FS Registered");
            Console.WriteLine("Booting");
            
        
        }
        protected override void Run()
        {
           
              Shell.shellc(); 

        
        }
    }
}
