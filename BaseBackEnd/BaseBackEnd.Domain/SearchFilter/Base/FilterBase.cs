using BaseBackEnd.Domain.Pagination;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.SearchFilter.Base
{
    public abstract class FilterBase : IPagination, IClassificationOrder
    {
        public string ClassifytePer { get; set; }
        public bool? CrescentOrder { get; set; } = false;

        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; } = 0;

        [JsonProperty(PropertyName = "qtdPerPage")]
        public int QtdPerPage { get; set; } = 20;
    }
}
