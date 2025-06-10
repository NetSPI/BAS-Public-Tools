using System;

using System.Net;

using System.Diagnostics;

using System.Reflection;

using System.Configuration.Install;

using System.Runtime.InteropServices;           

using System.Collections.ObjectModel;

using System.Management.Automation;

using System.Management.Automation.Runspaces;

using System.Text;


public class Program

{

                public static void Main()

                {

                    Console.WriteLine("Hello from PowerShell from .net c# in main!");


                    // Create session state object

                    InitialSessionState iss = InitialSessionState.CreateDefault();


                    // Setup language session state configuration

                    iss.LanguageMode = PSLanguageMode.FullLanguage;


                    // Create runspace using session state object

                    Runspace runspace = RunspaceFactory.CreateRunspace(iss);


                    // Open runspace

                    runspace.Open();


                    // Create script invoker object in run space

                    RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);

                    Pipeline pipeline = runspace.CreatePipeline();

                     

                    //Interrogate LockDownPolicy

                    //Console.WriteLine(System.Management.Automation.Security.SystemPolicy.GetSystemLockdownPolicy());                

                     

                    // Add PS script 

                    pipeline.Commands.AddScript("write-output 'Hello from PowerShell from .net c# in main!' | out-file c:\\temp\\ps-sharp-code-output.txt");


                    // Run PS script

                    Collection<PSObject> results = pipeline.Invoke();

                    runspace.Close();                        

                }                

}