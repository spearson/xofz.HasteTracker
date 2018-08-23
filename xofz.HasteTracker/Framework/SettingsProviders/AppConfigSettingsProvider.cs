namespace xofz.HasteTracker.Framework.SettingsProviders
{
    using xofz.HasteTracker.Properties;

    public sealed class AppConfigSettingsProvider
        : SettingsProvider
    {
        GlobalSettingsHolder SettingsProvider.Provide()
        {
            return new GlobalSettingsHolder
            {
                PublicApiKey = Settings.Default.PublicApiKey,
                Location = Settings.Default.Location,
                CharacterName = Settings.Default.CharacterName,
                Realm = Settings.Default.Realm,
                ApiSecret = Settings.Default.ApiSecret,
            };
        }
    }
}
