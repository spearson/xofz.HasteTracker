namespace xofz.HasteTracker.Framework
{
    public class HasteResponseData
    {
        public virtual CharacterStatistics stats { get; set; }
    }

    public class CharacterStatistics
    {
        public virtual int hasteRating { get; set; }

        public virtual double haste { get; set; }
    }
}
