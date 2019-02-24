using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Web.Services;
using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;


namespace AnywhereChecklist.WebAPI.Controllers
{

    [ApiController, Authorize, Route("api/[controller]")]
    public class CheckListItemsController : ControllerBase
    {
        private readonly ICheckListItemRepository repository;

        public CheckListItemsController(ICheckListItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpPut]
        public async Task<ActionResult<CheckListItem>> Update(CheckListItemUpdate checkList)
        {
            var result = await repository.UdpateAsync(checkList);
            if (result == null) return this.ValidateAndBadRequest();
            else return result;
        }

        [HttpPut("toggle/{id}")]
        public async Task ToggleItem(int id) => await repository.ToggleAsync(id);

        [HttpDelete("{id}")]
        public async Task DeleteItem(int id) => await repository.DeleteAsync(id);


    }
}
