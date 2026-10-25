using PLANAZO_POO_CSharp.Modelos;

Evento cine = new Cine(1, "Pelicula prueba", 50000m, 100, DateTime.Now);
Evento concierto = new Concierto(2, "Concierto prueba", 50000m, 100, DateTime.Now);
Evento taller = new Taller(3, "Taller prueba", 50000m, 100, DateTime.Now);

Console.WriteLine($"Cine: {cine.CalcularPrecioFinal()}");
Console.WriteLine($"Concierto: {concierto.CalcularPrecioFinal()}");
Console.WriteLine($"Taller: {taller.CalcularPrecioFinal()}");