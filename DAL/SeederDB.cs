using CashFlow_API.DAL.Entities;
namespace CashFlow_API.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulatePersonasAsync();
            await _context.SaveChangesAsync();
        }

        #region
        private async Task PopulatePersonasAsync()
        {
            if (!_context.Personas.Any())
            {
                _context.Personas.Add(new Persona
                {
                    CreatedDate = DateTime.Now,
                    Nombre = "Andres",
                    Apellido = "Acevedo",
                    Cedula = 1231542154,
                    Gastos = new List<Gasto>()
                    {
                        new Gasto {Referencia="M1805929",VlrGasto=250000,Descripcion="Comida con mi novia en provenza",CreatedDate=DateTime.Now },
                        new Gasto {Referencia="M1805930",VlrGasto=300000,Descripcion="Recibo de los servicios",CreatedDate=DateTime.Now },
                        new Gasto {Referencia="M1805931",VlrGasto=25000,Descripcion="Compre un Shampoo",CreatedDate=DateTime.Now }
                    }
                });
                _context.Personas.Add(new Persona
                {
                    CreatedDate = DateTime.Now,
                    Nombre = "Felipe",
                    Apellido = "Rojas",
                    Cedula = 135232154,
                    Gastos = new List<Gasto>()
                    {
                        new Gasto {Referencia="M1700001",VlrGasto=150000,Descripcion="Cena con la familia",CreatedDate=DateTime.Now },
                        new Gasto {Referencia="M1700002",VlrGasto=30000,Descripcion="",CreatedDate=DateTime.Now },
                        new Gasto {Referencia="M1700003",VlrGasto=10000,Descripcion="Compra de velas",CreatedDate=DateTime.Now }
                    }
                });
                _context.Personas.Add(new Persona
                {
                    CreatedDate = DateTime.Now,
                    Nombre = "Estiben",
                    Apellido = "Salazar",
                    Cedula = 1124958724,
                    Gastos = new List<Gasto>()
                    {
                        new Gasto {Referencia="M0705936",VlrGasto=350000,Descripcion="Compra de Zapatos en Adidas",CreatedDate=DateTime.Now },
                        new Gasto {Referencia="M0705923",VlrGasto=1500000,Descripcion="Compra de Telefono en Claro",CreatedDate=DateTime.Now },
                        new Gasto {Referencia="M0705944",VlrGasto=40000,Descripcion="Pago de mi Plan de Datos",CreatedDate=DateTime.Now }
                    }
                });
            }
        }
        #endregion
    }
}
