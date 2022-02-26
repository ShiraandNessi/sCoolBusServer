using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IStudentStatuseDL
    {
        public Task<bool> sentMessege(int studentId);
    }
}
