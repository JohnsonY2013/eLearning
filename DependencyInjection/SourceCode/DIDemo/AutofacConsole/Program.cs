using Autofac;
using Autofac.Features.Indexed;
using Autofac.Features.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AutofacConsole
{
    public interface IMobileService
    {
        void Execute();
    }

    public class SMSService : IMobileService
    {
        public void Execute()
        {
            Console.WriteLine("SMS service is executing.");
        }
    }

    public interface IMailService
    {
        void Execute();
    }
    public class EmailService : IMailService
    {
        public void Execute()
        {
            Console.WriteLine("Email service is executing.");
        }
    }

    public class NotificationSender
    {
        public IMobileService mobileService = null;
        public IMailService mailService = null;

        //构造方法注入
        public NotificationSender(IMobileService tmpService)
        {
            mobileService = tmpService;
        }

        // 属性注入
        public IMailService SetMailService
        {
            set { mailService = value; }
        }

        public void SendNotification()
        {
            mobileService.Execute();
            mailService.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IMobileService smsService = new SMSService();
            var notificationSender = new NotificationSender(smsService);
            notificationSender.mailService = new EmailService();
            notificationSender.SendNotification();

            var builder = new ContainerBuilder();
            builder.RegisterType<SMSService>().As<IMobileService>();
            builder.RegisterType<EmailService>().As<IMailService>();

            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            //builder.RegisterType<YesterdayWriter>().As<IDateWriter>();

            //builder.RegisterType<TodayWriter>().Keyed<IDateWriter>(Writers.Today);
            //builder.RegisterType<YesterdayWriter>().Keyed<IDateWriter>(Writers.Yesterday);

            builder.RegisterType<TodayWriter>().As<IDateWriter>().WithMetadata("Name", "Today");
            builder.RegisterType<YesterdayWriter>().As<IDateWriter>().WithMetadata("Name", "Yesterday");
            //builder.RegisterAdapter<Meta<IDateWriter>, DateWriter>(cmd => new DateWriter(cmd.Value, (string)cmd.Metadata["Name"]));
            //builder.RegisterAdapter<IDateWriter, DateWriter>(cmd => new DateWriter(cmd));
            //builder.RegisterAdapter<Meta<IDateWriter>, DateWriter>(
            //    cmd => new DateWriter(cmd.Value, (string)cmd.Metadata["Name"]));

            var container = builder.Build();

            container.Resolve<IMobileService>().Execute();
            container.Resolve<IMailService>().Execute();


            using (var scope = container.BeginLifetimeScope())
            {
                //https://www.ordina.nl/nl-nl/overige-content/2013/januari/autofac-and-multiple-implementations-of-an-interface/
                var writers = scope.Resolve<IEnumerable<IDateWriter>>();
                var writerAdapter = scope.Resolve<IEnumerable<Meta<IDateWriter, string>>>();

                foreach (var writer in writers)
                    writer.WriteDate();

                foreach (var writer in writerAdapter)
                {
                    var a = writer;
                }

                //var writersWithKey = new IIndex<Writers, IDateWriter>();
            }

            Console.WriteLine();
        }
    }
}
