using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.UnitOfWork
{
    public interface IAddLessonUnitOfWork
    {
        ILessonRepository LessonRepository { get; }

        Task Commit();
    }
}
