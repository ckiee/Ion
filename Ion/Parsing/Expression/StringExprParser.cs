using System;
using Ion.CodeGeneration;
using Ion.CognitiveServices;
using Ion.SyntaxAnalysis;

namespace Ion.Parsing
{
    public class StringExprParser : IParser<StringExpr>
    {
        public StringExpr Parse(ParserContext context)
        {
            // Ensure current token is string literal.
            context.Stream.EnsureCurrent(TokenType.LiteralString);

            // Capture string literal token.
            Token token = context.Stream.Get();

            // Skip string literal token.
            context.Stream.Skip();

            // TODO: Hard-coded.
            // Remove string quotes.
            string value = token.Value.Substring(1, token.Value.Length - 2);

            // Create the string expression entity.
            StringExpr stringExpr = new StringExpr(token.Type, Resolvers.TypeFromToken(token), value);

            // Return the string expression entity.
            return stringExpr;
        }
    }
}