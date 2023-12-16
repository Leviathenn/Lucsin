using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Cosmos.Core;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Sys = Cosmos.System;

namespace Lucsin
{
    public class Shell
    {
        public static string currentDirectory = @"0:\";
        public static string lastDirecotory = @"0:\";
        public static CosmosVFS VFS = Kernel.VFS;
        public static void shellc(){
           // Console.Clear();
            Console.Write("rootfs> ");
            string cmd = Console.ReadLine();
            doCommand(cmd);
            shellc();
        }
        public static void doCommand(string input)
        {
            string[] parts = input.Split(' ');
            string[] args = {};
            string cmd = parts[0];     
            foreach (var item in parts)
            {
                
                if(item == cmd){
                    //Console.WriteLine("Command: "+cmd);
                }else{
                   // Console.WriteLine("Arg: "+item);
                   args.Append(item);
                }
            }
            switch (cmd)
            {
                case "mkdir":
                    string dir = args[0];
                    Directory.CreateDirectory(dir);
                    break;
                case "ls":
                 //   string[] dirls = Directory.GetDirectories(args[0]);
                    foreach (var file in Directory.GetFiles(currentDirectory))
                    {
                        Console.WriteLine(file);
                    }
                    break;
                case "cd":
                    if(args[0] == "../"){
                        currentDirectory = lastDirecotory;

                    }else{
                        currentDirectory = @"0:\"+args[0];
                    }
                    break;
                case "echo":
                    Console.WriteLine(args[0]);
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "whomper":
                    Whomper.Shell();
                    break;
                default:

                        if(cmd.EndsWith(".prg")){
                            string[] sArgs = {cmd};
                            aspg.Run(sArgs);
                        
                        }else{
                            Console.WriteLine(cmd+" Is not a file or command.");
                        }
                    
                    
                    break;
                
            }
        }
    }
 
}