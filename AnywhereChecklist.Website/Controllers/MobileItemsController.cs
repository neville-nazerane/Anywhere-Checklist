using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnywhereChecklist.Web.Services;
using AnywhereChecklist.Entities;
using AnywhereChecklist.Models;
using NetCore.Jwt;

namespace AnywhereChecklist.WebAPI.Controllers
{

    [ApiController, Route("mobileApi/items")]
    [Authorize(AuthenticationSchemes = NetCoreJwtDefaults.SchemeName)]
    public class MobileItemsController : ControllerBase
    {
        private readonly ICheckListItemRepository repository;

        public MobileItemsController(ICheckListItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckListItem>> Get(int id)
            => await repository.GetAync(id);

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
