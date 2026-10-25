using PLANAZO_POO_CSharp.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLANAZO_POO_CSharp.Servicios
{
    public class GestorReservas
    {
        private readonly List<Evento> eventos = new List<Evento>();
        private readonly List<Reserva> reservas = new List<Reserva>();
        private int siguienteIdReserva = 1;

        public GestorReservas()
        {
            eventos.Add(new Cine(1, "Pelicula buena", 18000m, 80, new(2026, 11, 5)));
            eventos.Add(new Cine(2, "Pelicula mala", 28000m, 100, new(2026, 11, 10)));
            eventos.Add(new Concierto(3, "Concierto bueno", 20000m, 50, new(2026, 12, 5)));
            eventos.Add(new Concierto(4, "Concierto malo", 40000m, 20, new(2026, 12, 10)));
            eventos.Add(new Taller(5, "Taller qsy", 50000m, 10, new(2026, 12, 20)));
            eventos.Add(new Taller(6, "Taller sizeyo", 60000m, 200, new(2026, 12, 31)));
        }

        public List<Evento> ObtenerEventos()
        {
            return eventos;
        }
        public Evento BuscarEvento(int id)
        {
            foreach (Evento evento in eventos)
            {
                if (id == evento.Id)
                {
                    return evento;
                }
            }
            throw new KeyNotFoundException($"El evento con el id {id} no existe, intente nuevamente.");
        }
        public Reserva Reservar(string nombrePersona, int idEvento, int cantidad)
        {
            if (string.IsNullOrWhiteSpace(nombrePersona))
            {
                throw new ArgumentException("El nombre de la persona es obligatorio.");
            }
            Evento evento = BuscarEvento(idEvento);
            evento.ReservarCupos(cantidad);
            Reserva reserva = new Reserva(siguienteIdReserva++, nombrePersona, evento, cantidad);
            reservas.Add(reserva);
            return reserva;
        }
        public List<Reserva> ObtenerReservas()
        {
            return reservas;
        }
        public Reserva BuscarReserva(int id)
        {
            foreach (Reserva reserva in reservas)
            {
                if (id == reserva.Id)
                {
                    return reserva;
                }

            }
            throw new KeyNotFoundException($"La reserva con el id {id} no existe, intente nuevamente.");
        }
        public void CancelarReserva(int idReserva)
        {
            Reserva reserva = BuscarReserva(idReserva);
            reserva.Cancelar();
            reserva.EventoReserva.LiberarCupos(reserva.Cantidad);
        }
        public int ContarReservasActivas()
        {
            int contador = 0;
            foreach(Reserva reserva in reservas)
            {
                if(reserva.Estado == EstadoReserva.Activa)
                {
                    contador++;
                }
            }
            return contador;
        }
        public int ContarEntradasActivas()
        {
            int contador = 0;
            foreach(Reserva reserva in reservas)
            {
                if(reserva.Estado == EstadoReserva.Activa)
                {
                    contador += reserva.Cantidad;
                }
            }
            return contador;
        }
        public decimal CalcularValorActivas()
        {
            decimal contador = 0m;
            foreach (Reserva reserva in reservas)
            {
                if (reserva.Estado == EstadoReserva.Activa)
                {
                    contador += reserva.ValorTotal;
                }
            }
            return contador;
        }
    }

}
