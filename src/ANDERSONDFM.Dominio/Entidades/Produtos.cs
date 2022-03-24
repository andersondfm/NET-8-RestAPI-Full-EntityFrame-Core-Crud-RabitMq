
namespace ANDERSONDFM.Dominio.Entidades
{
	public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }

        public Produtos(int Id_, string Nome_, DateTime DataInclusao_, string UsuarioInclusao_)
        {
            this.Id = Id_;
            this.Nome = Nome_;
            this.DataInclusao = DataInclusao_;
            this.UsuarioInclusao = UsuarioInclusao_;
        }

        public Produtos()
        {
        }
    }
}
