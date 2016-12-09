using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject
{
    public interface IExercise<T, J>
    {
        void Process(J[] input);
        void PopulateDataStructure(J[] data);
        void Add(J item);
        void ReadAll();
    }
}
