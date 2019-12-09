using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TityoAttendance.TityoAttendance.TityoProject.Dto;

namespace TityoAttendance.TityoAttendance.TityoAttendance.Dto
{
    [AutoMapFrom(typeof(Attendance))]
    public class AttendanceDto : EntityDto<int>
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
        public ProjectDto Project { get; set; }
    }
}
