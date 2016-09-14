﻿using System;
using VYSA.Domain.Extensions;

namespace VYSA.Domain.Entities
{
    public class Event : EntityBase
    {
        // Foreign Keys
        public int SeasonId { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //public string Notes { get; set; }
        public string TournamentUrl { get; set; }
        public string GoogleMapUrl { get; set; }
        
        private DateTime? startDate;
        public DateTime? StartDate
        {
            get
            {
                return startDate.HasValue ? startDate.Value : DateTime.MinValue;
            }
            set
            {
                startDate = ((DateTime)value).AbsoluteStart();
            }
        }
        private DateTime? endDate;
        public DateTime? EndDate
        {
            get
            {
                return endDate.HasValue ? endDate.Value : DateTime.MinValue;
            }
            set
            {
                endDate = ((DateTime)value).AbsoluteEnd();
            }
        }

        // Navigation properties
        public Season Season { get; set; }
    }
}