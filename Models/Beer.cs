using System;

namespace WhatsOnTap.Models
{
    public class Beer
    {
        public long? id { get; set; }
        public string name { get; set; }
        public Style style { get; set; }
        public long? styleId {get;set;}
        public double? abv {get;set;}
        public double? ibu {get;set;}
        public double? og {get;set;}
        public double? fg {get;set;}
        public double? srm {get;set;}
        public string description {get;set;}
        public Label label {get;set;}
        public long? labelId {get;set;}
    }
}