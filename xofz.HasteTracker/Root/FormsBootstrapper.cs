namespace xofz.HasteTracker.Root
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.Framework;
    using xofz.Framework.Logging;
    using xofz.Presentation;
    using xofz.Root;
    using xofz.Root.Commands;
    using xofz.HasteTracker.Framework.SettingsProviders;
    using xofz.HasteTracker.Presentation;
    using xofz.HasteTracker.Root.Commands;

    public class FormsBootstrapper
    {
        public FormsBootstrapper()
            : this(new CommandExecutor())
        {
        }

        public FormsBootstrapper(
            CommandExecutor executor)
        {
            this.executor = executor;
        }

        public virtual Form MainForm => this.mainForm;

        public virtual void Bootstrap()
        {
            if (Interlocked.CompareExchange(ref this.bootstrappedIf1, 1, 0) == 1)
            {
                return;
            }

            this.setMainForm(new MainForm());
            var s = this.mainForm;
            var e = this.executor;
            e.Execute(new SetupMethodWebCommand(
                new AppConfigSettingsProvider(),
                    () => new MethodWeb()));
            var w = e.Get<SetupMethodWebCommand>().Web;
            UnhandledExceptionEventHandler handler = this.unhandledException;
            w.Run<EventSubscriber>(subscriber =>
            {
                var cd = AppDomain.CurrentDomain;
                subscriber.Subscribe(
                    cd,
                    nameof(cd.UnhandledException),
                    handler);
            });

            e
                .Execute(new SetupHomeCommand(
                    s,
                    w))
                .Execute(new SetupShutdownCommand(
                    w));
            w.Run<Navigator>(n => n.Present<HomePresenter>());
        }

        private void setMainForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        private void unhandledException(
            object sender,
            UnhandledExceptionEventArgs e)
        {
            var w = this.executor.Get<SetupMethodWebCommand>().Web;
            w.Run<LogEditor>(le =>
            {
                LogHelpers.AddEntry(le, e);
            },
                "Exceptions");
        }

        private MainForm mainForm;
        private long bootstrappedIf1;
        private readonly CommandExecutor executor;
    }
}
