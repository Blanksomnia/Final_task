using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
    internal class Casino
    {
        public interface IBuilderSupporter<T, U>
        {
            void BuildService(T service);
            void BuildCustom(U[] customClasses);
        }
    }
}
