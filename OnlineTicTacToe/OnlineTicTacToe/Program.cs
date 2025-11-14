namespace OnlineTicTacToe
{
    internal static class Program
    {
        public static ApplicationContext Context { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Context = new ApplicationContext();

            ServerConnect connectForm = new ServerConnect();
            Context.MainForm = connectForm;
            connectForm.Show();
            
            Application.Run(Context);
        }
    }
}