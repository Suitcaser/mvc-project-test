using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChaplyginMVCProject.Models
{
    public class ShortInfoModel
    {
        public ShortInfoModel(int id, int cn, DateTime date, double sum, string name)
        {
            Id = id;
            ContractNumber = cn;
            ContractDate = date;
            Sum = sum;
            FullName = name;
        }

        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Номер контракта")]
        public int ContractNumber { get; set; }
        [DisplayName("Дата подписания")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ContractDate { get; set; } //Полагаем договор может быть подписан в любое (даже будущее!!) время
        private double _sum;
        [DisplayName("Итоговая сумма")]
        public double Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                if (value >= 0)
                    _sum = value;
                else
                    throw new ArgumentOutOfRangeException("value","Сумма договора не может быть отрицательным значением.");
            }
        }
        private string _fullName;
        [DisplayName("ФИО исполнителя")]
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _fullName = value;
                else
                    throw new ArgumentException("ФИО не может быть пустой строкой или состоять только из пробелов.");
            }
        }
    }
}