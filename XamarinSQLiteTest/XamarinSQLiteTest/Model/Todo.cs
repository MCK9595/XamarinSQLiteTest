using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSQLiteTest.Model
{
    public class Todo
    {
        [SQLite.PrimaryKey,SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Detail { get; set; }
    }
}
