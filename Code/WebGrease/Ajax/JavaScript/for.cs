// for.cs
//
// Copyright 2010 Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;

namespace Microsoft.Ajax.Utilities
{

    public sealed class ForNode : IterationStatement
    {
        private AstNode m_initializer;
        private AstNode m_condition;
        private AstNode m_incrementer;

        public AstNode Initializer
        {
            get { return m_initializer; }
            set
            {
                m_initializer.IfNotNull(n => n.Parent = (n.Parent == this) ? null : n.Parent);
                m_initializer = value;
                m_initializer.IfNotNull(n => n.Parent = this);
            }
        }

        public AstNode Condition
        {
            get { return m_condition; }
            set
            {
                m_condition.IfNotNull(n => n.Parent = (n.Parent == this) ? null : n.Parent);
                m_condition = value;
                m_condition.IfNotNull(n => n.Parent = this);
            }
        }

        public AstNode Incrementer
        {
            get { return m_incrementer; }
            set
            {
                m_incrementer.IfNotNull(n => n.Parent = (n.Parent == this) ? null : n.Parent);
                m_incrementer = value;
                m_incrementer.IfNotNull(n => n.Parent = this);
            }
        }

        /// <summary>Context for the first semicolon, separating the initializer and the condition</summary>
        public Context Separator1Context { get; set; }

        /// <summary>Context for the second semicolon, separating the condition and the incrementor</summary>
        public Context Separator2Context { get; set; }

        public BlockScope BlockScope { get; set; }

        public override Context TerminatingContext
        {
            get
            {
                // if we have one, return it. If not, return what the body has (if any)
                return base.TerminatingContext ?? Body.IfNotNull(b => b.TerminatingContext);
            }
        }

        public ForNode(Context context)
            : base(context)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            if (visitor != null)
            {
                visitor.Visit(this);
            }
        }

        internal override bool EncloseBlock(EncloseBlockType type)
        {
            // pass the query on to the body
            return Body == null || Body.Count == 0 ? false : Body.EncloseBlock(type);
        }

        public override IEnumerable<AstNode> Children
        {
            get
            {
                return EnumerateNonNullNodes(Initializer, Condition, Incrementer, Body);
            }
        }

        public override bool ReplaceChild(AstNode oldNode, AstNode newNode)
        {
            if (Initializer == oldNode)
            {
                Initializer = newNode;
                return true;
            }
            if (Condition == oldNode)
            {
                Condition = newNode;
                return true;
            }
            if (Incrementer == oldNode)
            {
                Incrementer = newNode;
                return true;
            }
            if (Body == oldNode)
            {
                Body = ForceToBlock(newNode);
                return true;
            }
            return false;
        }
    }
}
