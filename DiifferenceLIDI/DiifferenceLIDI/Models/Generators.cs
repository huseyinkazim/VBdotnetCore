﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiifferenceLIDI.Models
{
       
    public class Singleton : ISingleton
    {
        private Guid guid;
        public Singleton()
        {
            guid = Guid.NewGuid();
        }

        public Guid Guid => guid;
    }

    public class Transient : ITransient
    {
        private Guid guid;
        public Transient()
        {
            guid = Guid.NewGuid();
        }
        public Guid Guid => guid;
    }

    public class Scoped : IScoped
    {
        private Guid guid;
        public Scoped()
        {
            guid = Guid.NewGuid();
        }
        public Guid Guid => guid;
    }


}
