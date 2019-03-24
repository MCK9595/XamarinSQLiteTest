using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using XamarinSQLiteTest.Model;

namespace XamarinSQLiteTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public static string DbPath { get; } = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLiteDataBase.db");

        public ICommand SelectSQL { get; }
        public ICommand InsertSQL { get; }
        public ICommand CreateTable { get; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            try
            {
                Title = "Main Page";
                SelectSQL = new DelegateCommand(selectSQL);
                InsertSQL = new DelegateCommand(insertSQL);
                CreateTable = new DelegateCommand(createTable);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void insertSQL()
        {
            using (var db = new SQLite.SQLiteConnection(DbPath))
            {
                db.Insert(new Todo() { Title = "おいしい牛乳", TimeStamp = DateTime.Now, Detail = "スーパーに5本買いに行く" });
                db.Insert(new Todo() { Title = "イヤーピース", TimeStamp = DateTime.Now, Detail = "スーパーに5本買いに行く" });
            }
        }

        private void selectSQL()
        {
            using (var db = new SQLite.SQLiteConnection(DbPath))
            {
                foreach (var row in db.Table<Todo>())
                {
                    System.Diagnostics.Debug.WriteLine($"ID:{row.Id}\tTitle:{row.Title}\tTimeStamp:{row.TimeStamp}\tDetail:{row.Detail}");
                }
            }
        }

        private void createTable()
        {
            try
            {
                using (var db = new SQLite.SQLiteConnection(DbPath))
                {
                    db.CreateTable<Todo>();
                }
            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
