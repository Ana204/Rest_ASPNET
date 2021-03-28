using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rest_api01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
  
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        //endPoint via http 
        [HttpGet ("sum/{firstNumber}/{secondNUmber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            //verificando se os numeros passados no endPoint é numerico
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
          return BadRequest("Invalid Input");
        }

        //Método chamado no if para converter string para Decimal
        private int ConvertToDecimal(string firstNumber)
        {
            throw new NotImplementedException();
        }

        //Método Chamado no if para a verificação 
        private bool IsNumeric(string firstNumber)
        {
            throw new NotImplementedException();
        }
    }
}
