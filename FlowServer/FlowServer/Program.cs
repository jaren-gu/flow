using System;
using FlowServer.Helper;

namespace FlowServer
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var mysql = new MySqlDbHelper())
            {
                mysql.Connection.Open();
                LogHelper.Info("MySql is connect!");
            }

            LogHelper.Info("info");
            LogHelper.Debug("debug");
            LogHelper.Error("error");
            LogHelper.Warn("warn");
            Console.ReadKey();
        }
    }
}