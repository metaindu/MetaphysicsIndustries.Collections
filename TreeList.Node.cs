
/*****************************************************************************
 *                                                                           *
 *  TreeList.Node.cs                                                         *
 *  6 October 2007                                                           *
 *  Project: MetaphysicsIndustries.Collections assembly                      *
 *  Written by: Richard Sartor                                               *
 *  Copyright © 2007 Metaphysics Industries                                  *
 *                                                                           *
 *  A node within a TreeList.                                                *
 *                                                                           *
 *****************************************************************************/

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
