namespace ApiGTT.Models
{
    public class Certificates
    {
        public long id { get; set; }
        public string alias { get; set; }
        public string cliente { get; set; }
        public string email { get; set; }
        public string observ { get; set; }

        //Aqui guardo el base64
        public string name { get; set; }
        
        //Estos son para la salida del certificado
        public string vigencia { get; set; }
        public string nserie { get; set; }
        public string issue { get; set; }
        public string subject { get; set; }
    }
}