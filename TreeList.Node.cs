
/*
 *  MetaphysicsIndustries.Collections
 *  Copyright (C) 2014 Metaphysics Industries, Inc., Richard Sartor
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Collections
{
    public partial class TreeList<T> : IList<T>, System.Collections.IList
    {
        public class Node
        {
            public Node(T value)
            {
                _value = value;
            }

            public T Value
            {
                get
                {
                    return _value;
                }
            }

            public Node ListLeft
            {
                get { return _listLeft; }
                set 
                {
                    if (_listLeft != value)
                    {
                        if (_listLeft != null) { _listLeft.ListRight = null; }
                        _listLeft = value;
                        if (_listLeft != null) { _listLeft.ListRight = this; }
                    }
                }
            }

            public Node ListRight
            {
                get { return _listRight; }
                set
                {
                    if (_listRight != value)
                    {
                        if (_listRight != null) { _listRight.ListRight = null; }
                        _listRight = value;
                        if (_listRight != null) { _listRight.ListRight = this; }
                    }
                }
            }

            public Node TreeParent
            {
                get { return _treeParent; }
                set 
                {
                    if (_treeParent != value)
                    {
                        if (_treeParent != null)
                        {
                            if (_treeParent.TreeLeft == this) { _treeParent.TreeLeft = null; }
                            if (_treeParent.TreeRight == this) { _treeParent.TreeRight = null; }
                        }
                        _treeParent = value;

                        //possible wedge here
                    }
                }
            }

            public Node TreeLeft
            {
                get { return _treeLeft; }
                set
                {
                    if (_treeLeft != value)
                    {
                        if (_treeLeft != null) { _treeLeft.TreeParent = null; }
                        _treeLeft = value;
                        if (_treeLeft != null) { _treeLeft.TreeParent = this; }
                    }
                }
            }

            public Node TreeRight
            {
                get { return _treeRight; }
                set
                {
                    if (_treeRight != value)
                    {
                        if (_treeRight != null) { _treeRight.TreeParent = null; }
                        _treeRight = value;
                        if (_treeRight != null) { _treeRight.TreeParent = this; }
                    }
                }
            }

            private T _value;
            private Node _listLeft;
            private Node _listRight;
            private Node _treeParent;
            private Node _treeLeft;
            private Node _treeRight;
        }
    }
}
