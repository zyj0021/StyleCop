//-----------------------------------------------------------------------
// <copyright file="BlockStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A statement representing a new scope block.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class BlockStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The variables defined within the statement.
        /// </summary>
        private CodeUnitProperty<IList<IVariable>> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the BlockStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        internal BlockStatement(CodeUnitProxy proxy) 
            : base(proxy, StatementType.Block)
        {
            Param.Ignore(proxy);
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        public override IList<IVariable> Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    List<IVariable> vars = new List<IVariable>();

                    for (VariableDeclarationStatement variableStatement = this.FindFirstChild<VariableDeclarationStatement>();
                        variableStatement != null;
                        variableStatement = variableStatement.FindNextSibling<VariableDeclarationStatement>())
                    {
                        vars.AddRange(variableStatement.Variables);
                    }

                    this.variables.Value = vars.AsReadOnly();
                }

                return this.variables.Value;
            }
        }

        #endregion Public Override Properties
    }
}