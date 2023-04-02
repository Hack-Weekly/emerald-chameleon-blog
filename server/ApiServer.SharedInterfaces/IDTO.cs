using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.SharedInterfaces
{
    public interface IDTO
    {
        public interface IDTO<T>
        {
            T Id { get; set; }
        }

        public interface IDTO : IDTO<Guid>
        {

        }
    }
}
