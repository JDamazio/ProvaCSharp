using System;

namespace API.Models
{
    public class FolhaPagamento
    {
        public FolhaPagamento () => CriadoEm = DateTime.Now;
        public int Id { get; set; }

        public double ValorHora { get; set; }

        public double QuantidadeDeHoras { get; set; }

        public double SalarioBruto { get; set; }

        public double IRRF{ get; set; }

        public double INSS{ get; set; }

        public double FGTS{ get; set; }

        public double SalarioLiquido{ get; set; }

        public int Mes { get; set; }
        public int Ano { get; set; }

        public DateTime CriadoEm { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}