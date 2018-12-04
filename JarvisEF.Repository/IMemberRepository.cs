using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JarvisEF.Repository
{
    public interface IMemberRepository
    {
        Task Get(int id);
        Task Delete(int id);
    }
}
