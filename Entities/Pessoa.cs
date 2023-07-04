namespace PlanSaleWithAddon.Entities
{
    public class Pessoa
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        #region Entidade Associativa

        public int PlanoId { get; set; }
        public virtual Plano Plano { get; set; }
        #endregion

        protected Pessoa() { }

        public Pessoa(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Pessoa(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public void Alterar (Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            Email = pessoa.Email;
            Telefone = pessoa.Telefone;
        }

        public void VincularPlano(int planoId)
        {
            PlanoId = planoId;
        }

    }
}
