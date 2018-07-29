using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IProcessor
    {
        void Start();
        void Stop();
    }
}
