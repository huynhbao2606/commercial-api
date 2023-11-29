﻿namespace AzureAPI.Helper
{
    public class PaginationParams
    {
        public int PageNumber { get; set; } = 1;    

        private int _pageSize = 6;

        private const int MaxPageSize = 50;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }          

        public string QuerySearch { get; set; }
    }
}
    
