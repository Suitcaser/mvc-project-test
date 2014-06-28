﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ChaplyginMVCProject.Models
{
    public partial class ShortInfoModel
    {

        public SortOptions Options { get; set; }

        public class SortOptions
        {
            public bool? Id { get; set; }
            public bool? ContractNumber { get; set; }
            public bool? ContractDate { get; set; }
            public bool? Sum { get; set; }
            public bool? FullName { get; set; }
        }



        public ShortInfoModel(){}

        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Номер контракта")]
        public int ContractNumber { get; set; }
        [DisplayName("Дата подписания")]
        public DateTime ContractDate { get; set; } //Полагаем договор может быть подписан в любое (даже будущее) время
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

    public partial class ShortInfoModel
    {
        public List<ShortInfoModel> ContractList { get; set; }

        public ShortInfoModel(int id, int cn, DateTime date, double sum, string name)
        {
            Id = id;
            ContractNumber = cn;
            ContractDate = date;
            Sum = sum;
            FullName = name;
        }
    }

}