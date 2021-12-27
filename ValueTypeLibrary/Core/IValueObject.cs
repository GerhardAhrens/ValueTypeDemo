namespace ValueTypeLibrary.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IValueObject<TTyp,TEntity>
    {
        TTyp Value { get; }

        bool Equals(object @this);

        int GetHashCode();

        string ToString();
    }
}
