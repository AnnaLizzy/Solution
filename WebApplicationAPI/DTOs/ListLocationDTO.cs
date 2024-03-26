﻿namespace WebApplicationAPI.DTOs
{
    public class ListLocationDTO
    {
        public int ID { get; set; }        
        public string? LocationID { get; set; }
        public string? LocationAbrevationName { get; set; }
        public string? LocationDetailName { get; set; }
        public int AreaID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int IsDeleted { get; set; }
    }
}