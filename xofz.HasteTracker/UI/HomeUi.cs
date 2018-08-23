namespace xofz.HasteTracker.UI
{
    using xofz.UI;

    public interface HomeUi : Ui
    {
        event Action ExitRequested;

        string HasteRating { get; set; }

        string HastePercentage { get; set; }

        string CharacterName { get; set; }
    }
}
