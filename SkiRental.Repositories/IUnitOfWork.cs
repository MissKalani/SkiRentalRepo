using SkiRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Repositories
{
    public interface IUnitOfWork
    {
        IEquipmentRepository EquipmentRepository { get; }
        IRentalRepository RentalRepository { get; }
        IPlansRepository PlansRepository { get; }
        ITypesRepository TypesRepository { get; }
        IEquipmentStatesRepository EquipmentStatesRepository { get; }

        void Save();
    }
}
