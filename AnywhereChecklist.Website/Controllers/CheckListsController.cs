using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Web.Services;
using AnywhereChecklist.Website.Models;
using AnywhereChecklist.Models;
using Microsoft.AspNetCore.Authorization;

namespace AnywhereChecklist.Website.Controllers
{

    [Authorize]
    public class CheckListsController : Controller
    {
        private readonly ICheckListRepository repository;
        private readonly ICheckListItemRepository itemRepository;

        public CheckListsController(ICheckListRepository repository, 
                                    ICheckListItemRepository itemRepository)
        {
            this.repository = repository;
            this.itemRepository = itemRepository;
        }

        public async Task<IActionResult> Index(int? id)
            => View(new CheckListViewModel
            {
                CheckLists = await repository.GetAsync(),
                CheckListId = id,
                Items = id == null ? null : await itemRepository.GetForListAcync(id ?? 0)
            });

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CheckListAdd checkList)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.AddAsync(checkList);
                if (result == null)
                    this.UpdateValidations();
                else return Ok(result);
            }
            HttpContext.Response.StatusCode = 400;
            return PartialView(checkList);
        }

    }
}
