using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChaplyginMVCProject.Models;

namespace ChaplyginMVCProject.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Начальная страница сайта - список всех контрактов из базы
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(SortOptions sortOptions = null)
        {
            return View(BuildShortView(sortOptions));

        }

        /// <summary>
        /// Достаём данные для показа о конкретном контракте
        /// </summary>
        /// <param name="id">ИД контракта</param>
        /// <param name="flag">0 - только контактные данные, 1 - все данные</param>
        /// <returns></returns>
        public ActionResult RequestDetails(int id, int flag = Int32.MinValue)
        {
            using (var dbContext = new ContractEntities())
            {
                var contract = dbContext.ContractInfo.SingleOrDefault(x => x.ID == id);
                if (contract == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    ViewBag.ErrorText = "Такого контракта не существует!";
                    return View("Error");
                }

                var model = new DetailedInfoModel(
                    contract.ID,
                    contract.ContractNumber,
                    contract.ContractDate,
                    contract.Sum,
                    contract.FullName,
                    contract.ContractSubject,
                    contract.Sygnatory,
                    contract.ContactInfo,
                    contract.ExecutorInfo
                    );
                switch (flag)
                {
                    case 0:
                        return PartialView("ContactInfoPartialView", model);
                        break;
                    case 1:
                        return View("DetailedPartialView", model);
                        break;
                    default: 
                        return View("DetailedPartialView", model);
                        break;
                }
                

            }
        }

        /// <summary>
        /// Подготовка модели всех договоров
        /// </summary>
        /// <returns> Модель договоров </returns>
        private static IEnumerable<ShortInfoModel> BuildShortView(SortOptions sortOptions = null)
        {
            var shortInfoModel = new List<ShortInfoModel>();
            try
            {
                using (var dbContext = new ContractEntities())
                {
                    #region Sorting
                    IOrderedQueryable<ContractInfo> contractInfos = dbContext.ContractInfo;
                    if (sortOptions != null)
                    {
                        if (sortOptions.ContractNumber.HasValue && sortOptions.ContractNumber.Value) contractInfos = contractInfos.OrderBy(x => x.ContractNumber);
                        if (sortOptions.ContractDate.HasValue && sortOptions.ContractDate.Value) contractInfos = contractInfos.OrderBy(x => x.ContractDate); 
                        if (sortOptions.Sum.HasValue && sortOptions.Sum.Value) contractInfos = contractInfos.OrderBy(x => x.Sum);
                        if (sortOptions.FullName.HasValue && sortOptions.FullName.Value) contractInfos = contractInfos.OrderBy(x => x.FullName);
                    }
                    else contractInfos = contractInfos.OrderBy(x => x.ID);
                    #endregion
                    // Для простоты считаем, что можно без проблем выгрузить сразу все строки, иначе брали бы пачками (показывали по 20 на странице например)
                    foreach (var item in contractInfos)
                    {
                        shortInfoModel.Add(
                            new ShortInfoModel(
                                item.ID,
                                item.ContractNumber,
                                item.ContractDate,
                                item.Sum,
                                item.FullName
                                )
                            );
                    }


                }
            }
            // пишем e.Message в лог или обрабатываем более специфичное а пока оставим конструкцию, лишённую смысла
            catch (Exception e)
            {       
                throw;
            }
            return shortInfoModel;
        }

        

    }


}
