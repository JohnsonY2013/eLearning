using System;

namespace AutofacConsole
{
    public interface IOutput
    {
        void Write(string content);
    }

    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    public interface IDateWriter
    {
        void WriteDate();
    }

    public class TodayWriter : IDateWriter
    {
        private IOutput _output;

        public TodayWriter(IOutput output)
        {
            _output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Today.ToShortDateString());
        }
    }

    public class YesterdayWriter : IDateWriter
    {
        private IOutput _output;
        public YesterdayWriter(IOutput output)
        {
            _output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Today.AddDays(-1).ToShortDateString());
        }
    }

    public class DateWriter
    {
        IDateWriter _dateWriter;
        public DateWriter(IDateWriter dateWriter)
        {
            _dateWriter = dateWriter;
        }

        public void Write()
        {
            _dateWriter.WriteDate();
        }
    }

    public enum Writers
    {
        Today,
        Yesterday,
        Tomorrow
    }
}
