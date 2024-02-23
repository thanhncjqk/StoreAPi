using BusinessLayer.AccountBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    //[Route("api/[controller]")
    //[ApiController]
    public class AccountController : BaseStoreController<Account>
    {
        private IAccountBL _AccountBL;

        public AccountController(IAccountBL AccountBL) : base(AccountBL)
        {
            _AccountBL = AccountBL;
        }
    }
}
