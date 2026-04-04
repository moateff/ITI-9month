using HotelManagementSystem.UI;

namespace HotelManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }

    #region Add Migration And Update Database Steps
    // 1. Delete the Migration Folder.

    // 2. Configure DB Connection Strings
        /// First Change the initial catalog inside "App.config" to the database you are using
        /// Change the Data Source= "" for each connection string to the server you are using
        /// if you are using sql server express don't change it

    // 3. Add Your Migrations
        /// Add-Migration InitFrontend -Context FrontendReservationContext -OutputDir Migrations/FrontendReservation
        /// Add-Migration InitLogin -Context LoginManagerContext -OutputDir Migrations/LoginManager

    // 4. Update Your DB Based On Your Migrations
        /// Update-Database -Context FrontendReservationContext
        /// Update-Database -Context LoginManagerContext 
    #endregion
}