using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsDemo
{
    static class Client
    {
        public static bool Value { get; set; }
    }
    static class Manager
    {
        public static bool Value { get; set; }
    }
    static class Stockman
    {
        public static bool Value { get; set; }
    }
    static class Director
    {
        public static bool Value { get; set; }
    }



    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>




        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConstructorForm());
        }
    }
}
