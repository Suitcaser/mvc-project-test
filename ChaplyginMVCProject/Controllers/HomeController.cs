using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChaplyginMVCProject.Models;

namespace ChaplyginMVCProject.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(BuildShortView());

        }

        /// <summary>
        /// Подготовка модели всех договоров
        /// </summary>
        /// <returns> Модель договоров </returns>
        private static ShortInfoModel BuildShortView(ShortInfoModel.SortOptions sortOptions = null)
        {
            var shortInfoModel = new ShortInfoModel();
            try
            {
                using (var dbContext = new ContractEntities())
                {
                    IOrderedQueryable<ContractInfo> contractInfos;
                    if (sortOptions != null)
                    {
                        if (sortOptions.Id.HasValue && !sortOptions.Id.Value) contractInfos = dbContext.ContractInfo.OrderByDescending(x => x.ID);
                        else contractInfos = dbContext.ContractInfo.OrderBy(x => x.ID);

                        if (sortOptions.ContractNumber.HasValue && sortOptions.ContractNumber.Value) contractInfos = dbContext.ContractInfo.ThenBy(x => x.ContractNumber);
                        else if (sortOptions.ContractNumber.HasValue && !sortOptions.ContractNumber.Value) contractInfos = dbContext.ContractInfo.ThenByDescending(x => x.ContractNumber);
                        if (sortOptions.ContractDate.HasValue && sortOptions.ContractDate.Value) contractInfos = dbContext.ContractInfo.ThenBy(x => x.ContractDate);
                        else if (sortOptions.ContractDate.HasValue && !sortOptions.ContractDate.Value) contractInfos = dbContext.ContractInfo.ThenByDescending(x => x.ContractDate);
                        if (sortOptions.Sum.HasValue && sortOptions.Sum.Value) contractInfos = dbContext.ContractInfo.ThenBy(x => x.Sum);
                        else if (sortOptions.Sum.HasValue && !sortOptions.Sum.Value) contractInfos = dbContext.ContractInfo.ThenByDescending(x => x.Sum);
                        if (sortOptions.FullName.HasValue && sortOptions.FullName.Value) contractInfos = dbContext.ContractInfo.ThenBy(x => x.Sum);
                        else if (sortOptions.FullName.HasValue && !sortOptions.FullName.Value) contractInfos = dbContext.ContractInfo.ThenByDescending(x => x.Sum);
                    }
                    else contractInfos = dbContext.ContractInfo.OrderBy(x => x.ID);

                    // Для простоты считаем, что можно без проблем выгрузить сразу все строки, иначе брали бы пачками (показывали по 20 на странице например)
                    foreach (var item in contractInfos)
                    {
                        shortInfoModel.ContractList.Add(
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
