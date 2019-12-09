using Abp.AutoMapper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoAttendance.Dto
{
    [AutoMapTo(typeof(Attendance))]
    public class CreateAttendanceDto
    {
        public string Description { get; set; }

        [Required]
        public DateTime ActualDay { get { return ActualDay.Date; } set { ActualDay = value.Date; } }

        [Required]
        public TimeSpan From { get; set; }

        [Required]
        public TimeSpan To { get; set; }

        [Required]
        [Range(1, 24)]
        public byte WorkedHours { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsPaid { get; set; }


        [Required]
        public int ProjectId { get; set; }
    }
}
