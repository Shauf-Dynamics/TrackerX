using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(DataContext context) : base(context)
        {

        }
    }
}
