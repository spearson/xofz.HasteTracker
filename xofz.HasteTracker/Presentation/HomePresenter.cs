namespace xofz.HasteTracker.Presentation
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;
    using xofz.HasteTracker.Framework;
    using xofz.HasteTracker.UI;
    using System.Security.Principal;

    public sealed class HomePresenter : Presenter
    {
        public HomePresenter(
            HomeUi ui,
            MethodWeb web)
            : base(ui, null)
        {
            this.ui = ui;
            this.web = web;
            this.timerHandlerFinished = new ManualResetEvent(true);
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            var w = this.web;
            w.Run<EventSubscriber>(subscriber =>
            {
                subscriber.Subscribe(
                    this.ui,
                    nameof(this.ui.ExitRequested),
                    this.ui_ExitRequested);
                w.Run<xofz.Framework.Timer>(t =>
                {
                    subscriber.Subscribe(
                        t,
                        nameof(t.Elapsed),
                        this.timer_Elapsed);
                },
                    "HomeTimer");
            });

            w.Run<GlobalSettingsHolder>(s =>
            {
                var charName = s.CharacterName;
                UiHelpers.Write(
                    this.ui,
                    () => this.ui.CharacterName = charName);
            });

            w.Run<Navigator>(n => n.RegisterPresenter(this));
        }

        public override void Start()
        {
            var w = this.web;
            w.Run<xofz.Framework.Timer>(t =>
                {
                    w.Run<EventRaiser>(er =>
                    {
                        w.Run<Messages>(messages =>
                        {
                            var waitingMessage = messages.Waiting;
                            UiHelpers.Write(
                                this.ui,
                                () =>
                                {
                                    this.ui.HasteRating = waitingMessage;
                                    this.ui.HastePercentage = waitingMessage;
                                });
                        });
                        
                        er.Raise(
                            t,
                            nameof(t.Elapsed));
                    });
                    t.Start(TimeSpan.FromMinutes(5));
                },
                "HomeTimer");
        }

        public override void Stop()
        {
            var w = this.web;
            w.Run<xofz.Framework.Timer>(t =>
                {
                    t.Stop();
                    this.timerHandlerFinished.WaitOne();
                },
                "HomeTimer");
        }

        private void ui_ExitRequested()
        {
            var w = this.web;
            w.Run<Navigator>(n => n.Present<ShutdownPresenter>());
        }

        private void timer_Elapsed()
        {
            var h = this.timerHandlerFinished;
            h.Reset();
            var w = this.web;
            w.Run<
                HttpClientFactory,
                GlobalSettingsHolder,
                Messages>((factory, settings, messages) =>
                {
                    var errorMessage = messages.Error;
                    string hasteRating;
                    string hastePercentage;
                    using (var client = factory.Create())
                    {
                        var uri = new StringBuilder()
                            .Append("https://")
                            .Append(settings.Location)
                            .Append(".api.battle.net/wow/character/")
                            .Append(settings.Realm)
                            .Append('/')
                            .Append(settings.CharacterName)
                            .Append("?fields=stats")
                            .Append("&locale=en_US")
                            .Append("&apikey=")
                            .Append(settings.PublicApiKey)
                            .ToString();
                        client.Timeout = TimeSpan.FromMilliseconds(10000);
                        Task<string> readHasteTask;
                        try
                        {
                            readHasteTask = client.GetStringAsync(uri);
                            readHasteTask.Wait();
                        }
                        catch
                        {                            
                            hasteRating = errorMessage;
                            hastePercentage = errorMessage;
                            goto setHaste;
                        }
                        
                        HasteResponseData data;
                        try
                        {
                            var json = readHasteTask.Result;
                            data = JsonConvert.DeserializeObject<HasteResponseData>(json);
                        }
                        catch
                        {
                            hasteRating = errorMessage;
                            hastePercentage = errorMessage;
                            goto setHaste;
                        }

                        hasteRating = data
                            ?.stats
                            ?.hasteRating
                            .ToString()
                            ?? errorMessage;
                        hastePercentage = data
                            ?.stats
                            ?.haste
                            .ToString()
                            ?? errorMessage;
                        if (hastePercentage != errorMessage)
                        {
                            hastePercentage += ' ';
                            hastePercentage += '%';
                        }

                        setHaste:
                        UiHelpers.Write(
                            this.ui,
                            () =>
                            {
                                this.ui.HasteRating = hasteRating;
                                this.ui.HastePercentage = hastePercentage;
                            });
                    }
                });

            h.Set();
        }

        private void setLastSyncedIP(string lastSyncedIP)
        {
            this.lastSyncedIP = lastSyncedIP;
        }

        private bool currentUserIsAdmin()
        {
            var principle = new WindowsPrincipal(
                WindowsIdentity.GetCurrent());
            return principle.IsInRole(
                WindowsBuiltInRole.Administrator);
        }

        private long setupIf1;
        private string lastSyncedIP;
        private readonly HomeUi ui;
        private readonly MethodWeb web;
        private readonly ManualResetEvent timerHandlerFinished;
    }
}
