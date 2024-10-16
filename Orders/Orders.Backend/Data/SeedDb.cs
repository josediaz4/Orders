using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckCategoriesAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Argentina",
                    States =
                    [
                        new State()
                        {
                            Name = "Tucumán",
                            Cities =
                            [
                                new() {Name="Famaillá"},
                                new() {Name="Monteros"},
                                new() {Name="Lules"},
                                new() {Name="San Miguel de Tucumán"}
                            ]
                        },
                        new State()
                        {
                            Name = "Salta",
                            Cities =
                            [
                                new() {Name="Cafayate"},
                                new() {Name="Iruya"},
                                new() {Name="Cachi"},
                                new() {Name="Tartagal"}
                            ]
                        },
                    ]
                });
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States =
                    [
                        new State()
                        {
                            Name = "Antioquia",
                            Cities =
                            [
                                new() {Name = "Medellín"},
                                new() {Name = "Itauí"},
                                new() {Name = "Envigado"},
                                new() {Name = "Bello"}
                            ]
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities =
                            [
                                new() {Name = "Usaquen"},
                                new() {Name = "Champinero"},
                                new() {Name = "Santa Fé"},
                                new() {Name = "Bosa"}
                            ]
                        }
                    ]
                });
                _context.Countries.Add(new Country
                {
                    Name = "Bolivia",
                    States =
                    [
                        new State()
                        {
                            Name = "Tarija",
                            Cities =
                            [
                                new() {Name = "Tarija"},
                                new() {Name = "San Lorenzo"},
                                new() {Name = "Entre Ríos"},
                                new() {Name = "Villamonte"}
                            ]
                        },
                        new State()
                        {
                            Name = "La Paz",
                            Cities =
                            [
                                new() {Name = "La Paz"},
                                new() {Name = "Palca"},
                                new() {Name = "Mecapaca"},
                                new() {Name = "El Alto"}
                            ]
                        }
                    ]
                });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Autos" });
                _context.Categories.Add(new Category { Name = "Belleza" });
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Comida" });
                _context.Categories.Add(new Category { Name = "Cosmeticos" });
                _context.Categories.Add(new Category { Name = "Deportes" });
                _context.Categories.Add(new Category { Name = "Erótica" });
                _context.Categories.Add(new Category { Name = "Ferreteria" });
                _context.Categories.Add(new Category { Name = "Gamer" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Jardín" });
                _context.Categories.Add(new Category { Name = "Jugetes" });
                _context.Categories.Add(new Category { Name = "Lenceria" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "Nutrición" });
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "Tecnología" });
            }
            await _context.SaveChangesAsync();
        }
    }
}