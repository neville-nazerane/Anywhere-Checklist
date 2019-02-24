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

    [ApiController, Route("mobileApi/lists")]
    [Authorize(AuthenticationSchemes = NetCoreJwtDefaults.SchemeName)]
    public class MobileListsController : ControllerBase
    {
        private readonly ICheckListRepository repository;

        public MobileListsController(ICheckListRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckList>>> Get()
            => Ok(await repository.GetAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckList>> Get(int id)
            => await repository.GetAsync(id);

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
