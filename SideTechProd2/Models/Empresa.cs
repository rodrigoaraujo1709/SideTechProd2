using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SideTechProd2.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }

        [DisplayName("Razão Social")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string RazaoSocial { get; set; }

        [DisplayName("Nome Fantasia")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string NomeFantasia { get; set; }

        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Cnpj { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

    }
}

