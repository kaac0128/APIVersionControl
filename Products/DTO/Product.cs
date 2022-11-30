﻿

namespace Products.DTO
{
    public class Product
    {
        public int? id { get; set; }
        public string? title { get; set; }
        public float? price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public Rating? rating { get; set; }
    }
}
