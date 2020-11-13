using System;
using System.Collections.Generic;
using System.Text;

namespace GSAtend.CamadaNegocio
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        public Paciente Paciente { get; set; }
        public string DescricaoAtendimento { get; set; }
    }
}