using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
namespace timeLib
{
    public static class sqlDataAccess
    {
        private static string loadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static List<time> loadTime(int c, int y, int m)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<time>($"PRAGMA foreign_keys = ON;select id,day,stime,etime,hours from workhours where empid = {c} and year = {y} and month = {m} order by day");
                return output.ToList();
            }
        }
        public static List<time> chartData(int y, int m)
        {
            using(IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<time>($"PRAGMA foreign_keys = ON;select day,month,year,stime,etime,name from workhours inner join employees on workhours.empid = employees.code  where year = {y} and month = {m}");
                return output.ToList();
            }
        }

        public static List<employee> getEmployees()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<employee>("PRAGMA foreign_keys = ON;select name,code from employees");
                return output.ToList();
            }
        }

        public static time getlastRecord(int empid)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<time>($"PRAGMA foreign_keys = ON;select id,stime,etime,year,month,day from workhours where empid = {empid} ORDER BY id DESC limit 1");
                if (output.Count() != 0)
                { return output.ToList()[0]; }
                else
                {
                    time tim = new time();
                    return tim;
                }
            }
        }

        public static double getTotalMonth(int empid, int month, int year)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<double>($"PRAGMA foreign_keys = ON;SELECT ifnull(sum(hours),0) from workhours where empid = {empid} and year = {year} and month = {month}");
                return Math.Round(output.Sum(),2);
            }
        }



        public static void insertStartTime(int empid, time t)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"PRAGMA foreign_keys = ON;insert into workhours (stime,empid,year,month,day) values (@stime, {empid}, @year, @month, @day)", t);
            }

        }

        public static void insertEndTime(time t, int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"PRAGMA foreign_keys = ON;update workhours set etime = @etime,hours = @hours where id ={id}", t);
            }
        }

        public static void InsertNewRecord(time newInsert, int empid)
        {
            if (string.IsNullOrEmpty(newInsert.etime))
            {
                using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
                {
                    cnn.Execute($"PRAGMA foreign_keys = ON;insert into workhours (stime,empid,year,month,day) values(@stime,{empid},@year,@month,@day)",newInsert);
                } 
            }
            else
            {
                using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
                {
                    cnn.Execute($"PRAGMA foreign_keys = ON;insert into workhours (stime,etime,hours,empid,year,month,day) values(@stime,@etime,@hours,{empid},@year,@month,@day)",newInsert);
                }
            }
        }

        public static void updateRecord(int id, string valuename, string value)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                string insertQueryString = "PRAGMA foreign_keys = ON;update workhours set " + valuename + " = '" + value + "' where id = " + id;
                cnn.Execute(insertQueryString);
            }
        }

        public static void deleteRecord(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"PRAGMA foreign_keys = ON;delete form workhours where id={id}");
            }
        }

        public static void EditEmployee(employee edditedEmp,int code)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute($"PRAGMA foreign_keys = ON;update employees set name = @name,code = @code where code = {code} ",edditedEmp);
            }
        }

        public static void NewEmployee(employee newEmp)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("PRAGMA foreign_keys = ON;insert into employees (name,code) values(@name,@code)", newEmp);
            }
        }
    }
}
