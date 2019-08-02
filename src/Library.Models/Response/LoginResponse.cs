namespace Library.Models.Response
{
    public class LoginResponse
    {
        public int LoginStatus { get; set; }

        public string Id{get;set;}
        public string Auth_Token { get; set; }
        public int Expires {get;set;}

    }
}