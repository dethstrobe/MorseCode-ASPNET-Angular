using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;

namespace WebApp.Models
{
    public class MorseCodeContext:DbContext
    {
		public DbSet<Morse> Morse { get; set; }
	}
}