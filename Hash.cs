
/*****************************************************************************
 *                                                                           *
 *  Hash.cs                                                                  *
 *  12 July 2006                                                             *
 *  Project: MetaphysicsIndustries.Collections assembly                      *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2006 Metaphysics Industries                                  *
 *                                                                           *
 *  A generic class that acts as an associative array.                       *
 *                                                                           *
 *  Converted from C++/CLI to C# on 6 May 2007                               *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public class Hash<T> : Dictionary<string, T> { }
}
