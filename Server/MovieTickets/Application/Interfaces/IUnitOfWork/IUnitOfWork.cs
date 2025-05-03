using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        IActorRepository Actors { get; }
        IMovieActorRepository MovieActors { get; }
        Task<int> SaveChangesAsync();
    }
}
