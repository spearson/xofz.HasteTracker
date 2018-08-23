namespace xofz.HasteTracker.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;
    using xofz.HasteTracker.Framework;
    using xofz.HasteTracker.Presentation;
    using xofz.HasteTracker.UI;

    public class SetupHomeCommand : Command
    {
        public SetupHomeCommand(
            HomeUi ui,
            MethodWeb web)
        {
            this.ui = ui;
            this.web = web;
        }

        public override void Execute()
        {
            this.registerDependencies();
            new HomePresenter(
                    this.ui,
                    this.web)
                .Setup();
        }

        private void registerDependencies()
        {
            var w = this.web;
            w.RegisterDependency(
                new Messages
                {
                    Error = @"Error",
                    Waiting = @"..."
                });
            w.RegisterDependency(
                new xofz.Framework.Timer(),
                "HomeTimer");
        }

        private readonly HomeUi ui;
        private readonly MethodWeb web;
    }
}
