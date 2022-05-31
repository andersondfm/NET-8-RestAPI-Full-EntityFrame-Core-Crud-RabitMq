using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANDERSONDFM.Aplicacao.ViewModels.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nome Requerido.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Senha Requerida.")]
        public string? Password { get; set; }
    }
}
