using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.SharedInterfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public interface IEntity : IEntity<Guid>
    {

    }
}
