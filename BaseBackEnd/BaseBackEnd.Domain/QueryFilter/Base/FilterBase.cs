using BaseBackEnd.Domain.Pagination;
using Newtonsoft.Json;

namespace BaseBackEnd.Domain.QueryFilter.Base
{
    public abstract class FilterBase : IPagination, IClassificationOrder
    {
        public string ClassifyPer { get; set; }
        public bool? CrescentOrder { get; set; } = false;

        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; } = 0;

        [JsonProperty(PropertyName = "qtdPerPage")]
        public int QtdPerPage { get; set; } = 20;
    }
}
