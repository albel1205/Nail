﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Serialization
{
    public interface ITextSerializer
    {
        void Serialize(TextWriter writer, object graph);

        object Deserialize(TextReader reader);
    }
}
