using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {
        private readonly DataContext _context;
        public FolhaController(DataContext context) =>
            _context = context;

        [HttpPost]
        [Route("criar")]
        public IActionResult Criar([FromBody] FolhaPagamento folha)
        {
            try
            {
                folha.Funcionario = _context.Funcionarios.Find(folha.FuncionarioId);

                folha.SalarioBruto = folha.ValorHora * folha.QuantidadeDeHoras;

                folha.FGTS = folha.SalarioBruto * 0.08;

                

                
                if (folha.SalarioBruto <= 1693.72)
                {

                    folha.INSS = folha.SalarioBruto*0.08; 

                } else if (folha.SalarioBruto <= 2822.9 )
                    {

                        folha.INSS = folha.SalarioBruto*0.09;

                    } else if (folha.SalarioBruto <= 5645.8)
                        {
                            folha.INSS = folha.SalarioBruto*0.11;
                        }
                        folha.INSS = 621.03;


                if(folha.SalarioBruto <=1903.98)
                {
                    folha.IRRF = 0;
                } else if (folha.SalarioBruto <= 2826.65)
                    {
                        folha.IRRF = (folha.SalarioBruto * 0.075) - 142.8;
                    } else if(folha.SalarioBruto <= 3751.05)
                        {
                            folha.IRRF = (folha.SalarioBruto*0.15)-354.8;
                        } else if (folha.SalarioBruto<=4664.68)
                            {
                                folha.IRRF = (folha.SalarioBruto * 0.225)-636.13;
                            } folha.IRRF = (folha.SalarioBruto*0.275)-869.39;  



                folha.SalarioLiquido = folha.SalarioBruto - folha.IRRF -folha.INSS;              



                _context.Folhas.Add(folha);
                _context.SaveChanges();
                return Created("",folha);
            }
            catch 
            {
                return NotFound("Funcionario não encontrado! *ERRO 404*");
            }

        }
          
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Folhas.ToList());

        [HttpGet]
        [Route("buscarfolha/{cpf}")]
        public IActionResult Buscar([FromRoute] string cpf)

        {
            FolhaPagamento folhaPagamento = _context.Folhas.FirstOrDefault(f =>f.Funcionario.Cpf.Equals(cpf));
            if(folhaPagamento != null)
            {
                return Ok(folhaPagamento);
            }
            return NotFound("Funcionario não encontrado");
        }

        [HttpGet]
        [Route("filtrar/{mesAno}")]
        public IActionResult Filtar([FromRoute] int mesAno)
        {
            FolhaPagamento folhaPagamento = _context.Folhas.FirstOrDefault(f=>f.MesAno.Equals(mesAno));

            return folhaPagamento != null ? Ok(folhaPagamento) : NotFound("DataNaoEncontrada");
        }
    }
}