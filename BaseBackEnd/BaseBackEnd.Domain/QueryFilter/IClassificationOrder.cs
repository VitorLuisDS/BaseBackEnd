﻿namespace BaseBackEnd.Domain.QueryFilter
{
    public interface IClassificationOrder
    {
        public string ClassifyPer { get; set; }
        public bool? CrescentOrder { get; set; }
    }
}