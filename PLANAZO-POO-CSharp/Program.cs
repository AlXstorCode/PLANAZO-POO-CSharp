using System.Text;
using PLANAZO_POO_CSharp.Modelos;
using PLANAZO_POO_CSharp.Servicios;

Console.OutputEncoding = Encoding.UTF8;

GestorReservas gestor = new GestorReservas();
bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("================================");
    Console.WriteLine("        PLANAZO - EVENTOS");
    Console.WriteLine("================================");
    Console.WriteLine();
    Console.WriteLine("1. Ver eventos disponibles");
    Console.WriteLine("2. Consultar evento");
    Console.WriteLine("3. Reservar entradas");
    Console.WriteLine("4. Ver reservas realizadas");
    Console.WriteLine("5. Cancelar una reserva");
    Console.WriteLine("6. Ver resumen de reservas");
    Console.WriteLine("0. Salir");
    Console.WriteLine();
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine() ?? "";
    Console.WriteLine();

    try
    {
        switch (opcion)
        {
            case "1":
                Console.WriteLine("--- EVENTOS DISPONIBLES ---");
                foreach (Evento e in gestor.ObtenerEventos())
                {
                    MostrarEvento(e);
                }
                break;

            case "2":
                int idConsulta = LeerEntero("Id del evento: ");
                Evento evento = gestor.BuscarEvento(idConsulta);
                Console.WriteLine("--- DETALLE DEL EVENTO ---");
                MostrarEvento(evento);
                Console.WriteLine($"   Precio base: ${evento.PrecioBase:N0}");
                break;

            case "3":
                Console.Write("Nombre de la persona: ");
                string nombre = Console.ReadLine() ?? "";
                int idEvento = LeerEntero("Id del evento: ");
                int cantidad = LeerEntero("Cantidad de entradas: ");
                Reserva nueva = gestor.Reservar(nombre, idEvento, cantidad);
                Console.WriteLine($"Reserva #{nueva.Id} confirmada para {nueva.NombrePersona}.");
                Console.WriteLine($"Evento: {nueva.EventoReserva.Nombre} | Entradas: {nueva.Cantidad} | Total: ${nueva.ValorTotal:N0}");
                Console.WriteLine($"Cupos restantes: {nueva.EventoReserva.CuposDisponibles}");
                break;

            case "4":
                Console.WriteLine("--- RESERVAS REALIZADAS ---");
                if (gestor.ObtenerReservas().Count == 0)
                {
                    Console.WriteLine("No hay reservas registradas.");
                }
                foreach (Reserva r in gestor.ObtenerReservas())
                {
                    Console.WriteLine($"#{r.Id} | {r.NombrePersona} | {r.EventoReserva.Nombre} | Entradas: {r.Cantidad} | Total: ${r.ValorTotal:N0} | {r.Estado}");
                }
                break;

            case "5":
                int idReserva = LeerEntero("Id de la reserva a cancelar: ");
                gestor.CancelarReserva(idReserva);
                Reserva cancelada = gestor.BuscarReserva(idReserva);
                Console.WriteLine($"Reserva #{cancelada.Id} cancelada. Se devolvieron {cancelada.Cantidad} cupos.");
                Console.WriteLine($"Cupos disponibles de {cancelada.EventoReserva.Nombre}: {cancelada.EventoReserva.CuposDisponibles}");
                break;

            case "6":
                Console.WriteLine("--- RESUMEN DE RESERVAS ---");
                Console.WriteLine($"Reservas activas: {gestor.ContarReservasActivas()}");
                Console.WriteLine($"Entradas reservadas: {gestor.ContarEntradasActivas()}");
                Console.WriteLine($"Valor total: ${gestor.CalcularValorActivas():N0}");
                break;

            case "0":
                salir = true;
                Console.WriteLine("Gracias por usar PLANAZO.");
                break;

            default:
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: debe ingresar un número entero válido.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static int LeerEntero(string mensaje)
{
    Console.Write(mensaje);
    return int.Parse(Console.ReadLine() ?? "");
}

static void MostrarEvento(Evento e)
{
    Console.WriteLine($"{e.Id}. [{e.GetType().Name}] {e.Nombre} | {e.Fecha:dd/MM/yyyy} | Precio final: ${e.CalcularPrecioFinal():N0} | Cupos: {e.CuposDisponibles}/{e.CapacidadMaxima}");
}
