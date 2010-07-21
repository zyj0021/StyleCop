//-----------------------------------------------------------------------
// <copyright file="CloseBracketToken.cs" company="Microsoft">
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
    using System.Diagnostics;

    /// <summary>
    /// Describes one closing curly bracket, square bracket, parenthesis,
    /// attribute bracket, or generic bracket.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class CloseBracketToken : BracketToken
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CloseBracketToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal CloseBracketToken(CsDocument document, string text, TokenType tokenType, CodeLocation location, bool generated)
            : base(document, text, tokenType, location, generated)
        {
            Param.Ignore(document, text, tokenType, location, generated);

            Debug.Assert(
                tokenType == TokenType.CloseCurlyBracket ||
                tokenType == TokenType.CloseSquareBracket ||
                tokenType == TokenType.CloseParenthesis ||
                tokenType == TokenType.CloseGenericBracket ||
                tokenType == TokenType.CloseAttributeBracket,
                "The symbol is not a bracket type.");
        }

        #endregion Internal Constructors

        #region Protected Override Methods

        /// <summary>
        /// Finds the matching bracket token.
        /// </summary>
        /// <returns>The matching bracket token.</returns>
        protected override BracketToken FindMatchingBracket()
        {
            return this.FindNextSibling<OpenBracketToken>();
        }

        #endregion Protected Override Methods
    }
}