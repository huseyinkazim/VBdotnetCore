using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiifferenceLIDI.Models
{
    public interface IGuidGenerator
    {
        public Guid Guid { get; }
    }

    public interface IScoped : IGuidGenerator
    {

    }

    public interface ISingleton : IGuidGenerator
    {

    }

    public interface ITransient : IGuidGenerator
    {

    }


}
