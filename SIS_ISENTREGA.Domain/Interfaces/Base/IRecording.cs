using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.Domain
{
  public interface IRecording<TEntidade> where TEntidade:class
    {
        void Add(TEntidade newRegister);
        TEntidade AddReturnEntity(TEntidade newRegister);
        void Update(TEntidade registerUpdate);
        void Delete(int id);
        void DeleteEntity(TEntidade entity);
    }
}
