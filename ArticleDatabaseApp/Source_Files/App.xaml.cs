using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ArticleDatabaseApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade databaseFacade = new DatabaseFacade(new DataContext());
            databaseFacade.EnsureCreated();            
        }  
    }
}
