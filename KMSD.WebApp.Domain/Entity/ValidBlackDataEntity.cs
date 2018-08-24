using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.Entity
{
    /// <summary>
    /// 实名期
    /// </summary>
    public class ValidBlackDataEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string UserID { get; set; }

        public int UserType { get; set; }

        public int UserGroup { get; set; }

        public string Remark { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
