using backendnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendnet.Data.Seed;

public class SeedCategoria : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasData(
            new Categoria { CategoriaId = 1, Nombre = "Acción", Protegida = true },
            new Categoria { CategoriaId = 2, Nombre = "Aventura", Protegida = true },
            new Categoria { CategoriaId = 3, Nombre = "Animación", Protegida = true },
            new Categoria { CategoriaId = 4, Nombre = "Ciencia ficción", Protegida = true },
            new Categoria { CategoriaId = 5, Nombre = "Comedia", Protegida = true },
            new Categoria { CategoriaId = 6, Nombre = "Crimen", Protegida = true },
            new Categoria { CategoriaId = 7, Nombre = "Documental", Protegida = true },
            new Categoria { CategoriaId = 8, Nombre = "Drama", Protegida = true },
            new Categoria { CategoriaId = 9, Nombre = "Familiar", Protegida = true },
            new Categoria { CategoriaId = 10, Nombre = "Fantasia", Protegida = true },
            new Categoria { CategoriaId = 11, Nombre = "Historia", Protegida = true },
            new Categoria { CategoriaId = 12, Nombre = "Horror", Protegida = true },
            new Categoria { CategoriaId = 13, Nombre = "Musica", Protegida = true },
            new Categoria { CategoriaId = 14, Nombre = "Misterio", Protegida = true },
            new Categoria { CategoriaId = 15, Nombre = "Romance", Protegida = true }
        );
    }
}