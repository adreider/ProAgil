using System;

namespace ProAgil.API.model
{
    public class Evento
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
    }
}