namespace ANDERSONDFM.Aplicacao.ViewModels
{
    public class UsuarioAuth
    {
        public UsuarioAuth(string email, string password, string nome)
        {
            Email = email;
            Password = password;
            Nome = nome;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
    }
}
