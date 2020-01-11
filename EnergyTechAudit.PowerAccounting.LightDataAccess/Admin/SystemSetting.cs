using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Admin
{
    [Table("SystemSetting", Schema ="Admin")]
    public class SystemSetting : IEntity
    {
        public int Id { get; set; }

        public string EmailSmtpServer { get; set; }

        public int EmailSmtpPort { get; set; }

        public bool EmailEnableSsl { get; set; }

        public string EmailUserName { get; set; }

        [DataType(DataType.Password)]
        public string EmailPassword { get; set; }

        public string EmailAddress { get; set; }

        private string _customData;

        public string CustomData
        {
            get
            {
                return _customData;
            }
            set
            {
                // проверяем JSON на валидность (JsonReaderException)
                var jsonValue = JObject.Parse(value);
                _customData = value;
            }
        }

    }
}
