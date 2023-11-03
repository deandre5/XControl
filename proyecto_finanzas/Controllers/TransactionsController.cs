using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyecto_finanzas.data.DTOs;
using proyecto_finanzas.data.Repositories;

namespace proyecto_finanzas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly ITransactionsRepositorie _transactionsRepositorie;


        public TransactionsController(ILogger<AccountsController> logger, ITransactionsRepositorie transactionsRepositorie)
        {
            _logger = logger;
            _transactionsRepositorie = transactionsRepositorie;
        }

        [HttpPost]
        [Route("api/transactions/expenses-income/create")]
        [Authorize]
        public async Task<IActionResult> createExpensesIncome(ExpensesIncome expensesIncome)
        {
            string response = await _transactionsRepositorie.createExpensesIncome(expensesIncome);
            ResponseTypeDTO responseType;

            if (response.Equals("1"))
            {

                responseType = new ResponseTypeDTO("Transaccion creada.", 200, 000);
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
        [Route("api/transactions/expenses-income/update")]
        [Authorize]
        public async Task<IActionResult> updateExpensesIncome(ExpensesIncome expensesIncome)
        {
            string response = await _transactionsRepositorie.updateExpensesIncome(expensesIncome);
            ResponseTypeDTO responseType;

            if (response.Equals("1"))
            {

                responseType = new ResponseTypeDTO("Transaccion actualizada.", 200, 000);
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
        [Route("api/transactions/expenses-income")]
        [Authorize]
        public async Task<IActionResult> getAccounts(string IdCuenta, DateTime fechaInicial, DateTime fechaFinal)
        {
            string intervaloInicial = fechaInicial.Date.ToString("yyyy-MM-dd HH:mm:ss");
            string intervaloFinal = fechaFinal.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyy-MM-dd HH:mm:ss");

            List<ExpensesIncomeResponse> expensesIncomeResponse = await _transactionsRepositorie.getExpensesIncome(IdCuenta, intervaloInicial, intervaloFinal);
            ListResponseDTO<ExpensesIncomeResponse> objectResponseDTO = new ListResponseDTO<ExpensesIncomeResponse>(expensesIncomeResponse);
            return Ok(objectResponseDTO);
        }


        [HttpDelete]
        [Route("api/transactions/expenses-income/delete")]
        [Authorize]
        public async Task<IActionResult> deleteAccounts(int idAccount, int idExpensesIncome)
        {

            string response = await _transactionsRepositorie.deleteExpensesIncome(idAccount, idExpensesIncome);
            ResponseTypeDTO responseType;

            if (response.Equals("1"))
            {
                responseType = new ResponseTypeDTO("transaccion eliminada.", 200, 000);
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

    }
}
