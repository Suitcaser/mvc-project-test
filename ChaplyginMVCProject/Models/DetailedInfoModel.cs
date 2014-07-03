using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChaplyginMVCProject.Models
{
    public class DetailedInfoModel : ShortInfoModel
    {
        public DetailedInfoModel()
        {
        }

        public DetailedInfoModel(int id, int cn, DateTime date, double sum, string name, string cs, string sig, string ci, string ei) : base(id, cn, date, sum, name)
        {
            ContractSubject = cs;
            Signatory = sig;
            ContactInfo = ci;
            ExecutorInfo = ei;
        }

        [Required]
        [StringLength(50)]
        [DisplayName("Предмет договора")]
        public string ContractSubject{get;set;}
        [Required]
        [StringLength(50)]
        [DisplayName("Подписант")]
        public string Signatory { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("Информация об исполнителе")]
        public string ExecutorInfo { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("Контактные данные представителя")]
        public string ContactInfo { get; set; }
    }
}