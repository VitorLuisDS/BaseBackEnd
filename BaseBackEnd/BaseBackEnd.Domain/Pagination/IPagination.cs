using Microsoft.AspNetCore.Mvc;

namespace BaseBackEnd.Domain.Pagination
{
    public interface IPagination
    {
        [FromQuery(Name = "currentPage")]
        public int CurrentPage { get; set; }

        [FromQuery(Name = "qtdPerPage")]
        public int QtdPerPage { get; set; }
    }
}
