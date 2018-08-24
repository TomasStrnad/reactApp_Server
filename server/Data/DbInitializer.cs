using WebApi.Entities;
using System;
using System.Linq;
using WebApi.Helpers;

namespace WebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            
        }
    }
}