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
using Cosmos.System.Network; 

/**
    @author Leviathenn
**/
namespace Lucsin
{
    public class Whomper
    {
 
     
        public static void Shell(){
            string prompt = "whomper> ";
            Console.Write(prompt);
            string input = Console.ReadLine();
            doCommand(input);
            Shell();

        }
          private static void doCommand(string input)
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
               case "c": case "connect":
                Console.WriteLine("Blayt");
               break;
               default:
                Console.WriteLine("Invalid Command / Option");
               break;
                
            }
        }
    }
}