using System;
using System.Collections.Generic;
using System.Text;

namespace Comic.Business.Interfaces
{
    public interface IServiceFacade
    {
        int Commit();
        void Rollback();
    }
}
