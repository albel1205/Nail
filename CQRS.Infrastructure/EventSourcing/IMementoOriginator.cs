namespace Infrastructure.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// a memento class to save current state of object
    /// </summary>
    public interface IMementoOriginator
    {
        IMemento SaveToMemento();
    }
}
