using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.dat
{
    public class PCIMContext : DbContext
    {

        private static PCIMContext pcimContext = null;

        public PCIMContext() : base("PCIMContext")
        {

        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Memory> Memorys { get; set; }
        public DbSet<SolidStateDrive> SSDs { get; set; }
        public DbSet<HardDriveDisk> HDDs { get; set; }
        public DbSet<SolidStateHybridDrive> SSHDs { get; set; }
        public object Computer { get; set; }

        public static PCIMContext Create()
        {
            
            if (pcimContext == null) pcimContext = new PCIMContext();

            return pcimContext;
            
            //return new PCIMContext();
        }
    }
}
