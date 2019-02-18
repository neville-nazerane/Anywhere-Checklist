using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using AnywhereChecklist.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnywhereChecklist.Website.Controllers
{

    [Authorize, ApiController, Route("api/CheckLists")]
    public class CheckListsApiController : ControllerBase
    {
        private readonly ICheckListRepository checkListRepository;
        private readonly ICheckListItemRepository checkListItemRepository;

        public CheckListsApiController(ICheckListRepository checkListRepository,
                                       ICheckListItemRepository checkListItemRepository)
        {
            this.checkListRepository = checkListRepository;
            this.checkListItemRepository = checkListItemRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CheckList>> Add(CheckListAdd checkList)
        {
            var result = await checkListRepository.AddAsync(checkList);
            if (result == null) return this.ValidateAndBadRequest();
            else return result;
        }

    }
}
