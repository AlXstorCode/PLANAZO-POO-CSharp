using System;
using System.Collections.Generic;
using System.Text;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Cine : Evento
    {
        public Cine(int id, string nombre, decimal preciobase, int capacidadmax, DateTime fecha) : base(id, nombre, preciobase, capacidadmax, fecha)
        {
        }
        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase;
        }
    }
}
