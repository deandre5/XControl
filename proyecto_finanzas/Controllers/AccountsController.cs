using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poryecto_finanzas.Controllers;
using poryecto_finanzas.DTOs;
using poryecto_finanzas.Repositories;
using proyecto_finanzas.data.DTOs;
using proyecto_finanzas.data.Repositories;
using System.Dynamic;

namespace proyecto_finanzas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : Controller
    {

        private readonly IAccountsRepositorie _accountsRepositorie;
        private readonly ILogger<AccountsController> _logger;


        public AccountsController(ILogger<AccountsController> logger, IAccountsRepositorie accountsRepositorie)
        {
            _logger = logger;
            _accountsRepositorie = accountsRepositorie;
        }


        [HttpPost]
        [Route("api/accounts/create")]
        [Authorize]
        public async Task<IActionResult> createAccounts(AccountsDTO account)
        {

            string response = await _accountsRepositorie.createAccount(account);
            ResponseTypeDTO responseType;

            if (response.Equals("1"))
            {

                responseType = new ResponseTypeDTO("Cuenta creada.", 200, 000);
                ObjectResponseDTO<ResponseTypeDTO> objectResponseDTO = new ObjectResponseDTO<ResponseTypeDTO>(responseType);
                return Ok(objectResponseDTO);
            }
            else
            {
                responseType = new ResponseTypeDTO("Error" + response, 400, 000);

                ObjectResponseDTO<ResponseTypeDTO> objectResponseDTO = new ObjectResponseDTO<ResponseTypeDTO>(responseType);
                return BadRequest(objectResponseDTO);
            }
        }


        [HttpDelete]
        [Route("api/accounts/delete")]
        [Authorize]
        public async Task<IActionResult> deleteAccounts(int idAccount, int idUser)
        {

            string response = await _accountsRepositorie.deleteAccount(idAccount,idUser);
            ResponseTypeDTO responseType;

            if (response.Equals("1"))
            {
                responseType = new ResponseTypeDTO("Cuenta eliminada.", 200, 000);
                ObjectResponseDTO<ResponseTypeDTO> objectResponseDTO = new ObjectResponseDTO<ResponseTypeDTO>(responseType);
                return Ok(objectResponseDTO);
            }
            else
            {
                responseType = new ResponseTypeDTO("Error" + response, 400, 000);

                ObjectResponseDTO<ResponseTypeDTO> objectResponseDTO = new ObjectResponseDTO<ResponseTypeDTO>(responseType);
                return BadRequest(objectResponseDTO);
            }
        }


        [HttpPut]
        [Route("api/accounts/update")]
        [Authorize]
        public async Task<IActionResult> updateAccounts(AccountsDTO account)
        {

            string response = await _accountsRepositorie.updateAccount(account);
            ResponseTypeDTO responseType;

            if (response.Equals("1"))
            {
                responseType = new ResponseTypeDTO("Cuenta eliminada.", 200, 000);
                ObjectResponseDTO<ResponseTypeDTO> objectResponseDTO = new ObjectResponseDTO<ResponseTypeDTO>(responseType);
                return Ok(objectResponseDTO);
            }
            else
            {
                responseType = new ResponseTypeDTO("Error" + response, 400, 000);

                ObjectResponseDTO<ResponseTypeDTO> objectResponseDTO = new ObjectResponseDTO<ResponseTypeDTO>(responseType);
                return BadRequest(objectResponseDTO);
            }
        }



        [HttpGet]
        [Route("api/accounts")]
        [Authorize]
        public async Task<IActionResult> getAccounts(string idUser)
        {

            List<AccountsResponseDTO> accounts = await _accountsRepositorie.getAccounts(idUser);
            ListResponseDTO<AccountsResponseDTO> objectResponseDTO = new ListResponseDTO<AccountsResponseDTO>(accounts);
            return Ok(objectResponseDTO);
        }
    }
}
