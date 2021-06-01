namespace CampusCourses.WebApi.Data
{
    public abstract class UnitOfWork
    {
        public UnitOfWork(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IDataContext DataContext { get; }
    }
}