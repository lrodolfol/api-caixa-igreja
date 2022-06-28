namespace api_caixa_igreja
{
    public class MessageException
    {
        public string Mensagem
        {
            get; set;
        } = "Verifique os dados e tente novamente";
        public string Descricao { get; set; }
    }
}
