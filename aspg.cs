/**
    @author Leviathan
**/
using System;
using System.Collections;
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
    public class aspg
    {
         static ArrayList  nameVars = new ArrayList();
    static ArrayList gotoData = new ArrayList();
    static ArrayList ignoreLines = new ArrayList();
    static ArrayList retrLines = new ArrayList();
    static string fileName = "";
    static int mainIndex = 0;

    static int createGoto(){
         using (StreamReader read = new StreamReader(fileName)) {
         string line;
         int cIndex = 0;
         while ((line = read.ReadLine()) != null) {
            if(line == "" || line == " "){

            }else{
                string Command = line.Split(" ")[0];
                string[] cArgs = WSplit(line.Split(Command)[1]);
                if(Command == "FGOTO"){
                    int endLine = findEndGoto();
                    gotoData.Add(cIndex+":"+endLine);
                }else{
                    cIndex++;
                }
            }
       
         }
        }
        return 0;
    }    
    static int findEndGoto(){
        int returnLine = 0;
        foreach (string item in gotoData)
        {
            string startLine = item.Split(":")[0];
            try
            {
                int endLine = int.Parse(item.Split(":")[1]);      
                returnLine = endLine;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error with parsing int...");
                throw;
            }
    
            
            
        }
        return returnLine;
    }
    static void ECHO(string stri1){
        string stri = "";
        if(stri1.Contains('"')){
            stri = stri1.Split('"')[1];
        }
        if(stri.Contains("$")){
            string alsd = stri.Split("$")[1];
            string bltt = alsd.Split(" ")[0];

            string fixStr = stri.Replace("$"+bltt,findVar(bltt));
            Console.WriteLine(fixStr);
        }else{
             Console.WriteLine(stri);
        }

    }
    static string findVar(string varName){
        string blayt = "";
        foreach (string item in nameVars)
        {
            
            string name = item.Split(":")[0];
            if(name == varName){
                blayt = item.Split(":")[1];

            }
        }
        return blayt;
    }
    public static void READMSG(string stri){
        if(stri.Contains("$")){
            string alsd = stri.Split("$")[1];
            string bltt = alsd.Split(" ")[0];

            string fixStr = stri.Replace("$"+bltt,findVar(bltt));
            Console.Write(fixStr);
        }else{
             Console.Write(stri);
        }
    }
    public static void parseCommand(string command, string[] args){   
        switch (command)
        {
            case "WRITE":
                ECHO(args[1]);
                break;
            case "WRITEVAR":
                Console.WriteLine("Use of illigal function! update v0.3.2");
                break;
            case "STORE":
            string varName = args[1];
            string argsValue = args[2];
            string braV = argsValue.Split('"')[1];
            nameVars.Add(varName+":"+braV);
            
            break;
            case "LIST":
            Console.WriteLine(findVar(args[1]));
            break;
            case "READMSG":
                READMSG(args[1].Split('"')[1]);
                break;
            case "READLINE":
                string readM = Console.ReadLine();
                string stri = args[1];
                 if(stri.Contains("$")){
                    string alsd = stri.Split("$")[1];
                    string bltt = alsd.Split(" ")[0];
        
                    nameVars.Add(bltt+":"+readM);
                    
                    }else{
                         //Dismiss it.

                    }
                break;
            case "SGOTO":
                retrLines.Add(mainIndex);
            break;
            case "READFILE":
                string fileName = args[1];
               
                 if(fileName.Contains("$")){
            string alsd = fileName.Split("$")[1];
            string bltt = alsd.Split(" ")[0];

            string fixStr = fileName.Replace("$"+bltt,findVar(bltt));
            fileName = fixStr;
        }else{
            //ofc dismiss
        }
                string pipeVar = args[2];
                 if(pipeVar.Contains("$")){
            string alsd = pipeVar.Split("$")[1];
            string bltt = alsd.Split(" ")[0];
            string liser = File.ReadAllText(fileName);
            nameVars.Add(bltt+":"+liser);
            
        }else{
             //Dissmiss
        }
            break;
            case "IF":
                string condition1 = args[1];
                string opperator = args[2];
                string condition2 = args[3];
                string gotoOp = args[4];
                //Place holder
                switch (opperator)
                {
                    case "==":
                        if(condition1 == condition2){
                            
                        }
                    break;
                    default:
                    break;
                }
            break;
            default:
                Console.WriteLine("Invalid Syntax.");
            break;
        
        }

    }
    public static void Run(String[] args){
        fileName = args[0];     
        string[] lines = File.ReadAllLines(fileName);
        foreach (var line in lines)
        {
            while(line != null){
              if(line == "" || line == " "){
                
             }else{
                 string Command = line.Split(" ")[0];
                 string[] cArgs = WSplit(line.Split(Command)[1]);
                 parseCommand(Command,cArgs);
    
             }
             mainIndex++;
            }
        }
      
    }
      static string[] WSplit(string input)
    {
        List<string> result = new List<string>();
        bool insideQuotes = false;
        int start = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '\"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (input[i] == ' ' && !insideQuotes)
            {
                // Split the substring if outside quotes and encountering a space
                result.Add(input.Substring(start, i - start));
                start = i + 1;
            }
        }

        // Add the last substring (or the whole string if no space is encountered at the end)
        result.Add(input.Substring(start));

        return result.ToArray();
    }  
    }
}