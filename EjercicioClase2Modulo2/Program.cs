namespace EjercicioClase2Modulo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Utilizando LINQ resolver las siguientes consignas:

            //Carga de datos
            var lstClientes = new List<Clientes>()
            {
                new Clientes() { Apellido = "Jara", Nombre = "Alejandro" ,CodCliente = 123 , Vip = true},
                new Clientes() { Apellido = "Mossier", Nombre = "Fernando" ,CodCliente = 345 , Vip = false},
                new Clientes() { Apellido = "Bustos", Nombre = "Andres" ,CodCliente = 567 , Vip = true},
                new Clientes() { Apellido = "Dalpiaz", Nombre = "Carla" ,CodCliente = 789 , Vip = true},
                new Clientes() { Apellido = "Miranda", Nombre = "Micaela" ,CodCliente = 112 , Vip = false},
                new Clientes() { Apellido = "De Castillo", Nombre = "Andrea" ,CodCliente = 223 , Vip = false},
            };


            #region Ejercicio1
            // Detectar cual es el numero mas grande e imprimirlo por consola

            var lstNumeros = new List<int>() { 25, 10, 99, 105, 1, 84, 22 };

            int maxEdad = lstNumeros.Max();

            Console.WriteLine("\n\n Ejercicio 1  ");
            Console.WriteLine("---------------------- ");
            Console.WriteLine($"\n Numero maximo: {maxEdad}");


            #endregion

            #region Ejercicio2
            //Ordenar los nombres alfabeticamente
            var lstNombres = new List<string>() { "Ana", "Alejandro", "Alexis", "Pablo", "Carlos", "Anibal", "Carla", "Susana" };

            var lstNomOrd = lstNombres.OrderBy(nombre => nombre);

            Console.WriteLine("\n\n Ejercicio 2  ");
            Console.WriteLine("---------------------- ");
            Console.WriteLine("\n Lista nombres ordenada: ");

            foreach (string nombre in lstNomOrd)
            {
                Console.WriteLine($" {nombre}");
            }

            #endregion

            #region Ejercicio3
            // Utilizando la variable "lstClientes" filtrar los clientes que tengan vip = true e imprimirlo por consola


            var lstCtesVip = lstClientes.Where(cliente => cliente.Vip);

            Console.WriteLine("\n\n Ejercicio 3  ");
            Console.WriteLine("---------------------- ");
            Console.WriteLine("\n Lista clientes vip: ");

            foreach (Clientes ClienteVip in lstCtesVip)
            {
                Console.WriteLine($" Apellido: {ClienteVip.Apellido}, Nombre: {ClienteVip.Nombre}, CodCte: {ClienteVip.CodCliente}, Vip: {ClienteVip.Vip}");
            }

            #endregion

            #region Ejercicio4 
            //Utilizando la variable "lstClientes" crear una nueva lista donde solo se encuentren los nombres de los clientes e imprimir los nombres

            Console.WriteLine("\n\n Ejercicio 4  ");
            Console.WriteLine("---------------------- ");
            Console.WriteLine("\n Lista nombre clientes: ");

            lstClientes.ForEach(cliente =>
            {
                Console.WriteLine($" {cliente.Nombre}");

            });

            #endregion

            #region Ejercicio5
            //Apartir de la variable "lstClientes" crear una lista que contenga todos los datos pero  modificando los siguientes campos:
            // Nombre tiene que guardarse en mayusculas
            // Apellido tiene que guardarse en mayusculas
            // Vip => se debe evaluar el bool y si es true se debe asignar el texto "Premium" y si es false "Normal"

            //**************************************************************************
            // SOLUCION 1 - ojo que solo quedan los no VIP en la lista de modificados 
            //**************************************************************************
            //var lstCtesModif = lstClientes.Where(cliente => cliente.Vip == true)
            //                    .Select(cliente => new ClienteModificado()
            //                    {
            //                        Nombre = cliente.Nombre.ToUpper(),
            //                        Apellido = cliente.Apellido.ToUpper(),
            //                        CodCliente = cliente.CodCliente,
            //                        TiCliente = "Premium"
            //                    })
            //                    .ToList();

            //lstCtesModif = lstClientes.Where(cliente => cliente.Vip == false)
            //                .Select(cliente => new ClienteModificado()
            //                {
            //                    Nombre = cliente.Nombre.ToUpper(),
            //                    Apellido = cliente.Apellido.ToUpper(),
            //                    CodCliente = cliente.CodCliente,
            //                    TiCliente = "Normal"
            //                })
            //                .ToList();


            //**************************************************************************
            // SOLUCION 2 - explicada por Ale 
            //**************************************************************************
            //var lstCtesModif = lstClientes.Select(cliente => new ClienteModificado()
            //{
            //    Nombre = cliente.Nombre.ToUpper(),
            //    Apellido = cliente.Apellido.ToUpper(),
            //    CodCliente = cliente.CodCliente,
            //    TiCliente = cliente.Vip ? "Premium" : "Normal"
            //})
            //.ToList();

            //**************************************************************************
            // SOLUCION 3 - explicada por Ale :)
            //**************************************************************************
            var lstCtesModif = lstClientes.Select(cliente =>
            {
                string tiCte = "";
                if (cliente.Vip)
                {
                    tiCte = "Premiun";
                }
                else
                {
                    tiCte = "Normal";
                }
                var CteModificado = new
                {
                    Nombre = cliente.Nombre.ToUpper(),
                    Apellido = cliente.Apellido.ToUpper(),
                    CodCliente = cliente.CodCliente,
                    TiCliente = tiCte
                };
                return(CteModificado);
            })
            .ToList();


            Console.WriteLine("\n\n Ejercicio 5  ");
            Console.WriteLine("---------------------- ");
            Console.WriteLine("\n Lista modificada: ");

            lstCtesModif.ForEach(CteModif => Console.WriteLine($" Apellido: {CteModif.Apellido}, Nombre: {CteModif.Nombre}, CodCte: {CteModif.CodCliente}, TiCte: {CteModif.TiCliente}"));

            //**************************************************************************
            // IMPRIMIR SIN LINQ
            //**************************************************************************
            //foreach (var CteModif in lstCtesModif)
            //{
            //    Console.WriteLine($" Apellido: {CteModif.Apellido}, Nombre: {CteModif.Nombre}, CodCte: {CteModif.CodCliente}, TiCte: {CteModif.TiCliente}");
            //}

            #endregion
        }
    }
}