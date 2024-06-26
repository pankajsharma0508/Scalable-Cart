﻿using Cart.Data.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Cart.Data
{
    public class MongoDbContext : DbContext
    {
        public DbSet<UserCart> UserCarts { get; init; }
        public static MongoDbContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<MongoDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options);
        public MongoDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserCart>().ToCollection("UserCarts");
        }
    }
}
