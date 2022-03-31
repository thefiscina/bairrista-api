namespace Bairrista.Service.Model
{
    public class AuthResponse
    {
        public string usuario_uuid { get; set; }
        public string nome { get; set; }
        public string access_token { get; set; }
        public string ultimo_acesso_em { get; set; }
        public string expira_em { get; set; }
    }
}
