using backendnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendnet.Data.Seed;

public class SeedPelicula : IEntityTypeConfiguration<Pelicula>
{
    public void Configure(EntityTypeBuilder<Pelicula> builder)
    {
        builder.HasData(
            new Pelicula { PeliculaId = 1, Titulo = "Sueño de fuga", Sinopsis = "El banquero Andy Dufresne es arrestado por matar a su esposa y amante. Tras una dura adaptación, intenta mejorar las condiciones de la prisión y dar esperanza a sus compañeros.", Anio = 1994, Poster = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 2, Titulo = "El padrino", Sinopsis = "El patriarca de una organización criminal transfiere el control de su clandestino imperio a su reacio hijo.", Anio = 1972, Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 3, Titulo = "El caballero oscuro", Sinopsis = "Cuando el Joker emerge causando caos y violencia en Gotham, el caballero de la noches deberá aceptar una de las pruebas psicológicas y físicas más difíciles para poder luchar con las injusticias del enemigo.", Anio = 2008, Poster = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 4, Titulo = "El retorno del rey", Sinopsis = "Gandalf y Aragorn lideran el Mundo de los hombres, e intentarán atraer la atención de Sauron para darle a Frodo la última oportunidad de completar su misión y así tratar de evitar sucumbir a las continuas tentaciones del Anillo.", Anio = 2003, Poster = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 5, Titulo = "Tiempos violentos", Sinopsis = "Las vidas de dos mafiosos, un boxeador, la esposa de un gánster y un par de bandidos se entrelazan en cuatro historias de violencia y redención.", Anio = 1994, Poster = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 6, Titulo = "Forrest Gump", Sinopsis = "Las presidencias de Kennedy y Johnson, los eventos de Vietnam, Watergate vistas desde la perspectiva de un hombre de Alabama con un coeficiente intelectual de 75.", Anio = 1994, Poster = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 7, Titulo = "El club de la pelea", Sinopsis = "Un hombre deprimido conoce a un fabricante de jabones, y juntos forman un club de pelea clandestino que evoluciona en algo inesperado.", Anio = 1999, Poster = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 8, Titulo = "Inception", Sinopsis = "A un ladrón que roba secretos corporativos a través de la tecnología de entrar en el subconsciente, se le da la tarea de implantar una idea en la mente del jefe de una gran empresa.", Anio = 2010, Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 9, Titulo = "Star Wars: Episodio V - El imperio contraataca", Sinopsis = "Los rebeldes han vencido al Imperio en el planeta helado Hoth. Luke Skywalker empieza a entrenar como Jedi con Yoda, mientras sus amigos son perseguidos por Darth Vader.", Anio = 1980, Poster = "https://m.media-amazon.com/images/M/MV5BYmU1NDRjNDgtMzhiMi00NjZmLTg5NGItZDNiZjU5NTU4OTE0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 10, Titulo = "Matrix", Sinopsis = "Un hacker se da cuenta por medio de otros rebeldes de la naturaleza de su realidad y su rol en la guerra contra los controladores.", Anio = 1999, Poster = "https://m.media-amazon.com/images/M/MV5BZjJjMTg5MTEtMDkwMy00ZjUyLTg5ODYtMmNmY2ZiNGVlZTdjXkEyXkFqcGdeQXVyODA1NjQ0OTY@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 11, Titulo = "Interestelar", Sinopsis = "Un grupo de exploradores prueban los saltos a través de agujeros de gusano en búsqueda de la sobrevivencia de la humanidad.", Anio = 2014, Poster = "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 12, Titulo = "Dune: Parte dos", Sinopsis = "Paul Atreides se une a Chani y los Fremen mientras busca venganza contra los conspiradores que destruyeron a su familia.", Anio = 2024, Poster = "https://m.media-amazon.com/images/M/MV5BODdjMjM3NGQtZDA5OC00NGE4LWIyZDQtZjYwOGZlMTM5ZTQ1XkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 13, Titulo = "Terminador 2: El juicio final", Sinopsis = "Un cyborg, idéntico al que fracasó al asesinar a Sarah Connor, ahora debe proteger al hijo adolescente de un cyborg más avanzado y poderoso.", Anio = 1991, Poster = "https://m.media-amazon.com/images/M/MV5BMGU2NzRmZjUtOGUxYS00ZjdjLWEwZWItY2NlM2JhNjkxNTFmXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 14, Titulo = "Volver al futuro", Sinopsis = "Marty McFly, un estudiante de 17 años, es enviado accidentalmente treinta años al pasado en un artefacto inventado por su amigo.", Anio = 1995, Poster = "https://m.media-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg" },
            new Pelicula { PeliculaId = 15, Titulo = "Barbie", Sinopsis = "Vivir en Barbie Land es ser un ser perfecto en un lugar perfecto. A menos que tengas una crisis existencial completa. O seas Ken.", Anio = 2023, Poster = "https://m.media-amazon.com/images/M/MV5BNjU3N2QxNzYtMjk1NC00MTc4LTk1NTQtMmUxNTljM2I0NDA5XkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg" }
        );

        // Agrega las categorias a cada película
        builder.HasMany(c => c.Categorias).WithMany(c => c.Peliculas).UsingEntity(j => j.HasData(
            new { PeliculasPeliculaId = 1, CategoriasCategoriaId = 6 },
            new { PeliculasPeliculaId = 2, CategoriasCategoriaId = 6 },
            new { PeliculasPeliculaId = 2, CategoriasCategoriaId = 8 },
            new { PeliculasPeliculaId = 3, CategoriasCategoriaId = 1 },
            new { PeliculasPeliculaId = 3, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 3, CategoriasCategoriaId = 8 },
            new { PeliculasPeliculaId = 4, CategoriasCategoriaId = 8 },
            new { PeliculasPeliculaId = 5, CategoriasCategoriaId = 6 },
            new { PeliculasPeliculaId = 5, CategoriasCategoriaId = 8 },
            new { PeliculasPeliculaId = 6, CategoriasCategoriaId = 8 },
            new { PeliculasPeliculaId = 6, CategoriasCategoriaId = 15 },
            new { PeliculasPeliculaId = 7, CategoriasCategoriaId = 8 },
            new { PeliculasPeliculaId = 8, CategoriasCategoriaId = 1 },
            new { PeliculasPeliculaId = 8, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 9, CategoriasCategoriaId = 1 },
            new { PeliculasPeliculaId = 9, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 9, CategoriasCategoriaId = 10 },
            new { PeliculasPeliculaId = 10, CategoriasCategoriaId = 1 },
            new { PeliculasPeliculaId = 10, CategoriasCategoriaId = 4 },
            new { PeliculasPeliculaId = 11, CategoriasCategoriaId = 1 },
            new { PeliculasPeliculaId = 11, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 11, CategoriasCategoriaId = 4 },
            new { PeliculasPeliculaId = 12, CategoriasCategoriaId = 1 },
            new { PeliculasPeliculaId = 12, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 12, CategoriasCategoriaId = 8 },
            new { PeliculasPeliculaId = 13, CategoriasCategoriaId = 1 },
            new { PeliculasPeliculaId = 13, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 13, CategoriasCategoriaId = 4 },
            new { PeliculasPeliculaId = 14, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 14, CategoriasCategoriaId = 4 },
            new { PeliculasPeliculaId = 14, CategoriasCategoriaId = 5 },
            new { PeliculasPeliculaId = 15, CategoriasCategoriaId = 2 },
            new { PeliculasPeliculaId = 15, CategoriasCategoriaId = 5 },
            new { PeliculasPeliculaId = 15, CategoriasCategoriaId = 10 }
        ));
    }
}