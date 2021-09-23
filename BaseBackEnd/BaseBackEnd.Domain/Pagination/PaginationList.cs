using Newtonsoft.Json;

namespace BaseBackEnd.Security.Domain.Pagination
{
    public class PaginationList<TItem> : IPagination
    {
        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "qtdPerPage")]
        public int QtdPerPage { get; set; }

        [JsonProperty(PropertyName = "itemsTotal")]
        public int ItemsTotal { get; set; }

        [JsonProperty(PropertyName = "pagesTotal")]
        public int PagesTotal => QtdPerPage > 0 ? (int)Math.Ceiling((decimal)ItemsTotal / QtdPerPage) : 0;

        [JsonProperty(PropertyName = "items")]
        public List<TItem> Items { get; set; }

        public PaginationList(List<TItem> items, int qtdPerPage, int currentPage, int itemsTotal)
        {
            QtdPerPage = qtdPerPage;
            CurrentPage = currentPage;
            ItemsTotal = itemsTotal;
            Items = items;
        }

        public PaginationList<TDestination> Map<TDestination>(Func<TItem, TDestination> mapFunction) =>
            new PaginationList<TDestination>(Items.Select(mapFunction).ToList(), QtdPerPage, CurrentPage, ItemsTotal);
    }
}
