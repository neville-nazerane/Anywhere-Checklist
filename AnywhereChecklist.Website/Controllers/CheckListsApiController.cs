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

        [HttpPut]
        public async Task<ActionResult<CheckList>> Update(CheckListUpdate checkList)
        {
            var result = await checkListRepository.UpdateAsync(checkList);
            if (result == null) return this.ValidateAndBadRequest();
            else return result;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await checkListRepository.DeleteAsync(id);

        
        [HttpPost("items")]
        public async Task<ActionResult<CheckListItem>> Add(CheckListItemAdd checkList)
        {
            var result = await checkListItemRepository.AddAsync(checkList);
            if (result == null) return this.ValidateAndBadRequest();
            else return result;
        }

        [HttpPut("items")]
        public async Task<ActionResult<CheckListItem>> Update(CheckListItemUpdate checkList)
        {
            var result = await checkListItemRepository.UdpateAsync(checkList);
            if (result == null) return this.ValidateAndBadRequest();
            else return result;
        }

        [HttpPut("items/toggle/{id}")]
        public async Task ToggleItem(int id) => await checkListItemRepository.ToggleAsync(id);

        [HttpDelete("items/{id}")]
        public async Task DeleteItem(int id) => await checkListItemRepository.DeleteAsync(id);



    }
}
