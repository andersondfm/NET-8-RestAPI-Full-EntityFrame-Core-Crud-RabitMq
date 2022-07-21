using System.ComponentModel.DataAnnotations;

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
