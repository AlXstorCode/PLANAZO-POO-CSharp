using System;
using System.Collections.Generic;
using System.Text;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Taller : Evento
    {
        public Taller(int id, string nombre, decimal preciobase, int capacidadmax, DateTime fecha) : base(id, nombre, preciobase, capacidadmax, fecha)
        { 
        }
        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase * 0.9m;
        }
    }
}
