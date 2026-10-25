using System;
using System.Collections.Generic;
using System.Text;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Reserva
    {
        public int Id { get; }
        public string NombrePersona { get; }
        public Evento EventoReserva { get; }
        public int Cantidad { get; }
        public decimal ValorTotal { get; }
        public EstadoReserva Estado { get; private set; }

        public Reserva(int id, string nombrePersona, Evento evento, int cantidad)
        {
            Id = id;
            NombrePersona = nombrePersona;
            EventoReserva = evento;
            Cantidad = cantidad;
            ValorTotal = evento.CalcularPrecioFinal() * cantidad;
            Estado = EstadoReserva.Activa;
        }
        public void Cancelar()
        {
            if (Estado == EstadoReserva.Cancelada)
            {
                throw new InvalidOperationException("No se puede cancelar la reserva; ya se encuentra cancelada.");
            }

            Estado = EstadoReserva.Cancelada;
        }
    }
}
