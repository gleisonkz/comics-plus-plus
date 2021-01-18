namespace ComicStore.DomainTests.Patterns.Builder
{
    public abstract class TestBuilder<TBuilder, TSubject>
        where TBuilder : new()
        where TSubject : new()
    {
        protected readonly TSubject Subject = new TSubject();
        public static TBuilder Create()
        {
            return new TBuilder();
        }

        public TSubject Build()
        {
            return Subject;
        }
    }
}
