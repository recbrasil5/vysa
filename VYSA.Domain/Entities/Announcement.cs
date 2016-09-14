﻿using System;
using VYSA.Domain.Extensions;

namespace VYSA.Domain.Entities
{
    public class Announcement : EntityBase
    {
        // Columns
        public string Title { get; set; }
        public string Message { get; set; }
        private DateTime? startTime;
        public DateTime? StartTime
        {
            get
            {
                return startTime.HasValue ? startTime.Value : DateTime.MinValue;
            }
            set
            {
                startTime = ((DateTime)value).AbsoluteStart();
            }
        }
        private DateTime? endTime;
        public DateTime? EndTime
        {
            get
            {
                return endTime.HasValue ? endTime.Value : DateTime.MinValue;
            }
            set
            {
                endTime = ((DateTime)value).AbsoluteEnd();
            }
        }
    }
}
