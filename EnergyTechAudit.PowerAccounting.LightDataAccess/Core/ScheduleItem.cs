using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Core
{
    [Table("ScheduleItem", Schema = "Core")]
    public class ScheduleItem : IEntity
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan PeriodBegin { get; set; }

        public TimeSpan PeriodEnd { get; set; }

        public int? OrdinalNumberOfDay { get; set; }

        [Required]
        public int ScheduleTypeId { get; set; }
      
        [ForeignKey("ScheduleTypeId")]        
        public virtual ScheduleType ScheduleType { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public static bool CheckSchelude(IEnumerable<ScheduleItem> scheduleItems)
        {
            var scheduleItemList = scheduleItems as IList<ScheduleItem> ?? scheduleItems.ToList();

            // элементы расписания отсутствуют,то считаем,
            // что доступ оператору выгрузки разрешен в любое время 

            if (!scheduleItemList.Any())
            {
                return true;
            }

            var now = DateTime.Now;
            var dayOfWeek = (int)now.DayOfWeek;
            var timeOfDay = now.TimeOfDay;
            var dayOfMonth = now.Day;

            var expResult = true;

            Predicate<ScheduleItem> predicate = si =>
            {
                return

                    (timeOfDay >= si.PeriodBegin && timeOfDay <= si.PeriodEnd) &&
                    (
                        (
                            si.ScheduleType.Code == "ByDayOfWeek"
                            && si.OrdinalNumberOfDay != null
                            && dayOfWeek == si.OrdinalNumberOfDay.Value
                            )
                        ||
                        (
                            si.ScheduleType.Code == "ByWorkingDaysOfWeek" && (dayOfWeek >= 1 && dayOfWeek <= 5)
                            )
                        ||
                        (
                            si.ScheduleType.Code == "ByHolydaysOfWeek" && (dayOfWeek == 0 || dayOfWeek == 6)
                            )
                        ||
                        (
                            si.ScheduleType.Code == "ByDayOfMonth"
                            && si.OrdinalNumberOfDay != null
                            && si.OrdinalNumberOfDay.Value == dayOfMonth
                            )
                        );
            };

            // если есть элементы, но нет ни одного попадания 
            if (!scheduleItemList.Any(s => predicate(s)))
            {
                return false;
            }

            foreach (var scheduleItem in scheduleItemList)
            {
                if (predicate(scheduleItem))
                {
                    expResult = expResult && scheduleItem.Enabled;
                }
            }

            return expResult;
        }

    }
}
