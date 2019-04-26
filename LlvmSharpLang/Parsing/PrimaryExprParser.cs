using System;
using LlvmSharpLang.CodeGeneration;
using LlvmSharpLang.CognitiveServices;
using LlvmSharpLang.SyntaxAnalysis;

namespace LlvmSharpLang.Parsing
{
    public class PrimaryExprParser : IParser<Expr>
    {
        public Expr Parse(TokenStream stream)
        {
            TokenType nextTokenType = stream.Peek().Type;

            // Numeric expression.
            if (TokenIdentifier.IsNumeric(nextTokenType))
            {
                return new NumericExprParser().Parse(stream);
            }
            // Identifier expression.
            else if (nextTokenType == TokenType.Identifier)
            {
                return new IdentifierExprParser().Parse(stream);
            }
            // Parentheses expression.
            else if (nextTokenType == TokenType.SymbolParenthesesL)
            {
                return new ParenthesesExprParser().Parse(stream);
            }

            // At this point, return null.
            return null;
        }
    }

}
