
//-----------------------------------------------------------------------
// <copyright file="IValueObject.cs" company="Lifeprojects.de">
//     Class: IValueObject
//     Copyright © Lifeprojects.de 2022
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>02.01.2022</date>
//
// <summary>
// Interface Klasse für ValueObject Basisklasse
// </summary>
//-----------------------------------------------------------------------

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
