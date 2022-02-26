using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IStudentStatuseBL
    {
        public Task<bool> sentMessege(int StudentBLId);
    }
}
