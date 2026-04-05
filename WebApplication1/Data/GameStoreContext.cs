using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options):DbContext(options)
{

    public DbSet<Games> Games =>Set<Games>();

    public DbSet<Genre> Genres =>Set<Genre>();

}
