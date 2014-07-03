using System;
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
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }
        [Required]
        [Range(0,999999)]
        [DisplayName("Номер контракта")]
        public int ContractNumber { get; set; }
        [Required]
        [DisplayName("Дата подписания")]
        [DisplayFormat(ApplyFormatInEditMode = true ,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ContractDate { get; set; } //Полагаем договор может быть подписан в любое (даже будущее!!) время
        [Required]
        [DisplayName("Итоговая сумма")]
        [Range(0,Int32.MaxValue)]
        public double Sum { get; set;}

        protected ShortInfoModel(){}

        [Required]
        [StringLength(50)]
        [DisplayName("ФИО исполнителя")]
        public string FullName { get; set; }
    }
}