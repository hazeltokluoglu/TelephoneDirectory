using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Data.Interfaces
{
    public interface IAllRepository
    {
        List<AllList> GetAll();
    }
}
