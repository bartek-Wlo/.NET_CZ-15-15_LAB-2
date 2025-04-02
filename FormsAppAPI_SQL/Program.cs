using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MauiAppAPI")]

namespace StudentAPI;
using StudentAPI.DataBase;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        Console.WriteLine("Okno Windows Forms START.\n...");
        ApplicationConfiguration.Initialize();
        Application.Run(new FormStudent());
        
        Console.WriteLine("Okno Windows Forms END.\n");
    }    
}