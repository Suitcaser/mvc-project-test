using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

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

        private string _contractSubject;
        [DisplayName("Предмет договора")]
        public string ContractSubject
        {
            get { return _contractSubject; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _contractSubject = value;
                else
                    throw new ArgumentException("Предмет договора не может быть пустой строкой или состоять только из пробелов.");
            }
        }
        private string _signatory;
        [DisplayName("Подписант")]
        public string Signatory
        {
            get
            {
                return _signatory;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _signatory = value;
                else
                    throw new ArgumentException("Подписант не может быть пустой строкой или состоять только из пробелов.");
            }
        }
        [DisplayName("Подписант")]
        public string ExecutorInfo { get; set; }
        [DisplayName("Контактные данные представителя")]
        public string ContactInfo { get; set; }
    }
}