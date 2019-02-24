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
    public class CheckListsController : ControllerBase
    {
        private readonly ICheckListRepository repository;

        public CheckListsController(ICheckListRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<CheckList>> Add(CheckListAdd checkList)
        {
            var result = await repository.AddAsync(checkList);
            if (result == null) return this.ValidateAndBadRequest();
            else return result;
        }

        [HttpPut]
        public async Task<ActionResult<CheckList>> Update(CheckListUpdate checkList)
        {
            var result = await repository.UpdateAsync(checkList);
            if (result == null) return this.ValidateAndBadRequest();
            else return result;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await repository.DeleteAsync(id);

    }
}
