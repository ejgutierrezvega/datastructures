using System.Threading.Tasks;

namespace DataStructureProject
{
    public interface IExercise<T>
    {
        Task<bool> ExecuteTask(T[] numbers);

        bool ExecuteExercise(T[] numbers);
    }
}
