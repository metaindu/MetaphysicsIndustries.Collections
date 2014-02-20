
/*****************************************************************************
 *                                                                           *
 *  StringEnumerator.cs                                                      *
 *  19 June 2007                                                             *
 *  Project: MetaphysicsIndustries.Build                                     *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2007 Metaphysics Industries, Inc.                            *
 *                                                                           *
 *  Converted from C++ to C# on 4 August 2007                                *
 *                                                                           *
 *  An enumerator class that simplifies the process of deserialization.      *
 *                                                                           *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Collections
{
	public class StringEnumerator : AutoEnumerator<string>
	{
		public StringEnumerator(IEnumerator<string> __base) : base(__base)
		{
		}

	}
}
