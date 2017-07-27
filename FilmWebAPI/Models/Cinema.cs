﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI.Models.Business
{
    public class Cinema
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
