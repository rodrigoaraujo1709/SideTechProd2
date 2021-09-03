using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SideTechProd2.Models
{
    public class Funcionario
    {


        public int IdFuncionario { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Cpf { get; set; }

        [DisplayName("Matrícula")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Matricula { get; set; }

        [DisplayName("Data de Admissão")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public DateTime DataDeAdmissao { get; set; }

        public int IdEmpresa { get; set; }

        public Empresa Empresa { get; set; }


    }
}

