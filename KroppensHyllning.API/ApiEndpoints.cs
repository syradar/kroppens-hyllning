namespace KroppenHyllning;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Campaigns
    {
        private const string Base = $"{ApiBase}/campaigns";

        public const string Create = Base;

        public const string Get = $"{Base}/{{idOrSlug}}";

        public const string GetAll = Base;

        public const string Update = $"{Base}/{{id:guid}}";

        public const string Delete = $"{Base}/{{id:guid}}";
    }
}
