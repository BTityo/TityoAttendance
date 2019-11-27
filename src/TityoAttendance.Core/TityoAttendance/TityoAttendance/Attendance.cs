using Abp.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TityoAttendance.Authorization.Users;

namespace TityoAttendance.TityoAttendance.TityoAttendance
{
    [Table("Attendance", Schema = "Attendance")]
    public class Attendance : Entity<int>
    {
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
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
