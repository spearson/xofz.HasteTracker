namespace xofz.HasteTracker.Framework
{
    public class GlobalSettingsHolder
    {
        public virtual string PublicApiKey { get; set; }

        public virtual string ApiSecret { get; set; }

        public virtual string Location { get; set; }

        public virtual string Realm { get; set; }

        public virtual string CharacterName { get; set; }
    }
}
