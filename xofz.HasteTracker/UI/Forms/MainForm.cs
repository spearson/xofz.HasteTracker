namespace xofz.HasteTracker
{
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;
    using xofz.HasteTracker.Properties;
    using xofz.HasteTracker.UI;

    public partial class MainForm 
        : FormUi, HomeUi
    {
        public MainForm()
        {
            this.InitializeComponent();
            var cm = new ContextMenu();
            cm.MenuItems.Add(
                new MenuItem
                {
                    Text = @"E&xit"
                });
            cm.MenuItems[0].Click += this.exitMenuItem_Click;
            var ni = this.notifyIcon;
            ni.ContextMenu = cm;
            ni.Icon = Resources.HasteTracker_Icon;
            this.Icon = Resources.HasteTracker_Icon;

            var h = this.Handle;
        }

        private void exitMenuItem_Click(
            object sender, 
            System.EventArgs e)
        {
            this.exit();
        }

        private void exit()
        {
            var er = this.ExitRequested;
            if (er == null)
            {
                return;
            }

            this.notifyIcon.Visible = false;
            ThreadPool.QueueUserWorkItem(
                o => er.Invoke());
        }

        public event Action ExitRequested;

        string HomeUi.HasteRating
        {
            get => this.hasteRatingLabel.Text;

            set => this.hasteRatingLabel.Text = value;
        }

        string HomeUi.HastePercentage
        {
            get => this.hastePercentageLabel.Text;

            set => this.hastePercentageLabel.Text = value;
        }

        const string baseTitle = "x(z) HasteTracker";

        string HomeUi.CharacterName
        {
            get => this.characterName;

            set
            {
                this.characterName = value;
                this.Text = baseTitle
                  + (value == null
                      ? string.Empty
                      : " - " + value);
                this.notifyIcon.Text = this.Text;
            }
        }

        private string characterName;

        private const string BaseVersionText = @"v";

        string HomeUi.Version
        {
            get
            {
                var text = this.versionLabel.Text;
                if (string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }

                return text.Substring(BaseVersionText.Length);
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.versionLabel.Text = value;
                    return;
                }

                this.versionLabel.Text = BaseVersionText + value;
            }
        }

        private const string BaseCoreVersionText = "Powered by xofz.Core98 v";

        string HomeUi.CoreVersion
        {
            get
            {
                var text = this.coreVersionLabel.Text;
                if (string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }

                return text.Substring(BaseCoreVersionText.Length);
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.coreVersionLabel.Text = value;
                    return;
                }

                this.coreVersionLabel.Text = BaseCoreVersionText + value;
            }
        }

        private void this_FormClosing(
            object sender, 
            FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (this.Visible)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                    return;
                }

                this.Visible = false;
                return;
            }

            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
    }
}
