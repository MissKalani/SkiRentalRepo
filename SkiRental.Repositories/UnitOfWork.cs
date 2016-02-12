using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Repositories;
using SkiRental.DataAccess;

namespace SkiRental.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEquipmentRepository EquipmentRepository { get; }
        public IRentalRepository RentalRepository { get; }
        public IPlansRepository PlansRepository { get; }
        public ITypesRepository TypesRepository { get; }      
        public IEquipmentStatesRepository EquipmentStatesRepository { get; }

        public SkiRentalContext SkiRentalContext { get; }
        public UnitOfWork()
            :this(new SkiRentalContext())
        {
        }

        public UnitOfWork(SkiRentalContext context)
        {
            this.SkiRentalContext = context;
            EquipmentRepository = new EquipmentRepository(context);
            RentalRepository = new RentalRepository(context);
            PlansRepository = new PlansRepository(context);
            TypesRepository = new TypesRepository(context);
            EquipmentStatesRepository = new EquipmentStatesRepository(context);
        }
        public void Save()
        {
            SkiRentalContext.SaveChanges();
        }
    }
}
