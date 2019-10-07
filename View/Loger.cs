using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

using Microsoft.Extensions.Logging;

namespace View
{
    class Loger
    {
        private string logpath = "console";
        public string logInto
        {
            get
            {
                return logpath;
            }
            set
            {
                this.Writer?.Dispose();
                logpath = value;
                if (value == "console")
                {
                    this.Writer = new StreamWriter(Console.OpenStandardOutput());
                }
                else
                {
                    //try
                    //{
                    this.Writer = new StreamWriter(new FileStream(value, FileMode.OpenOrCreate));
                    //}
                    /*catch
                    {
                        LogError("Loger", $"cant open file for loging ({value})");
                    }*/
                }
            }
        }
        protected StreamWriter Writer { get; set; }
        private string errpath = "console";
        public string errorInto
        {
            get
            {
                return errpath;
            }
            set
            {
                this.Error?.Dispose();
                errpath = value;
                if (value == "console")
                {
                    this.Error = new StreamWriter(Console.OpenStandardError());
                }
                else
                {
                    //try
                    //{
                        this.Error = new StreamWriter(new FileStream(value,FileMode.OpenOrCreate));
                    //}
                   // catch
                    //{
                       // LogError("Loger", $"cant open file for error ({value})");
                    //}
                }
            }
        }
        protected StreamWriter Error { get; set; }
        public string DateTimeFormat { get; set; } = "ru-Ru";
        private int count = 0;
        private int errCount = 0;
        public Loger()
        {
            this.Writer = new StreamWriter(Console.OpenStandardOutput());
            this.Error = new StreamWriter(Console.OpenStandardError());
        }
        ~Loger()
        {
            Writer.Close();
            Error.Close();
        }
        public Loger(string log, string error)
        {
            this.logInto = log;
            this.errorInto = error;
        }
        public Loger(string log)
        {
            this.logInto = log;
        }

        public void Log(string text)
        {
            DateTime n = DateTime.Now;
            Writer.WriteLine($"{++count}) [ {n.ToString(this.DateTimeFormat)} ] : {text}");
        }
        public void LogError(string text)
        {
            DateTime n = DateTime.Now;
            Error.WriteLine($"{++errCount}) [ {n.ToString(this.DateTimeFormat)} ] : {text}");
        }
        public void Log(string where,string what)
        {
            DateTime n = DateTime.Now;
            Writer.WriteLine($"{++count}) [ {n.ToString(this.DateTimeFormat)} ] : [In -- {where} -- {what}]");
        }
        public void LogError(string where, string what)
        {
            DateTime n = DateTime.Now;
            Error.WriteLine($"{++errCount}) [ {n.ToString(this.DateTimeFormat)} ] : [In -- {where} -- {what}]");
        }
    }
}
