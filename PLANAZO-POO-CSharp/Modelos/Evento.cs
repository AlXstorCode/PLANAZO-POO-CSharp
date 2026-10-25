using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PLANAZO_POO_CSharp.Modelos
{
    public abstract class Evento
    {
        public int Id { get; }
        public string Nombre { get; }
        public decimal PrecioBase { get; }
        public int CapacidadMaxima { get; }
        public DateTime Fecha { get; }
        public int CuposDisponibles { get; private set; }

        protected Evento(int id, string nombre, decimal preciobase, int capacidadmax, DateTime fecha)
        {
            Id = id;
            Nombre = nombre;
            PrecioBase = preciobase;
            CapacidadMaxima = capacidadmax;
            Fecha = fecha;
            CuposDisponibles = capacidadmax;
        }
        public abstract decimal CalcularPrecioFinal();

        public void ReservarCupos(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad de entradas no puede ser 0 ni negativo.");
            }
            if (cantidad > CuposDisponibles)
            {
                throw new InvalidOperationException("La cantidad de entradas no puede ser mayor a los cupos disponibles.");
            }

            CuposDisponibles -= cantidad;
        }
        public void LiberarCupos(int cantidad)
        {
            if(cantidad <= 0)
            {
                throw new ArgumentException("Las entradas liberadas no pueden ser 0 o negativas.");
            }

            if(CuposDisponibles + cantidad > CapacidadMaxima)
            {
                throw new InvalidOperationException("Los cupos no pueden superar la capacidad maxima.");
            }

            CuposDisponibles += cantidad;
        }
    }
}
