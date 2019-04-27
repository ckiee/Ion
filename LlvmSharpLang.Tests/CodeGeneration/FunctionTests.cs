using System;
using System.IO;
using System.Runtime.InteropServices;
using LLVMSharp;
using LlvmSharpLang.SyntaxAnalysis;
using NUnit.Framework;
using LlvmSharpLang.Abstraction;

namespace LlvmSharpLang.Tests.CodeGeneration
{
    internal sealed class FunctionTests
    {
        private string storedIr;

        private Abstraction.Module module;

        private Token[] sequence;

        [SetUp]
        public void SetUp()
        {
            // TODO: Cannot compare null to LLVMModuleRef.
            // Dispose previous LLVM module if applicable.
            /*if (this.module != null)
            {
                LLVM.DisposeModule(this.module);
            }*/

            // Create the LLVM module.
            this.module = new LlvmSharpLang.Abstraction.Module();

            // Read the stored IR code to compare.
            this.storedIr = File.ReadAllText("../../../Data/function.ll");

            // Create the sequence.
            this.sequence = new Token[]
            {
                new Token {
                    Type = TokenType.ProgramStart
                },

                new Token {
                    Type = TokenType.KeywordFunction,
                    Value = "fn"
                },

                new Token {
                    Type = TokenType.Identifier,
                    Value = "helloWorld"
                },

                new Token {
                    Type = TokenType.SymbolParenthesesL,
                    Value = "("
                },

                new Token {
                    Type = TokenType.Type,
                    Value = "int"
                },

                new Token {
                    Type = TokenType.Identifier,
                    Value = "myInteger"
                },

                new Token {
                    Type = TokenType.SymbolComma
                },

                new Token {
                    Type = TokenType.Type,
                    Value = "float"
                },

                new Token {
                    Type = TokenType.Identifier,
                    Value = "myFloat"
                },

                new Token {
                    Type = TokenType.SymbolParenthesesR,
                    Value = ")"
                },

                new Token {
                    Type = TokenType.SymbolColon,
                    Value = ":"
                },

                new Token {
                    Type = TokenType.Identifier,
                    Value = "int"
                },

                new Token {
                    Type = TokenType.SymbolBlockL,
                    Value = "{"
                },

                new Token {
                    Type = TokenType.SymbolBlockR,
                    Value = "}"
                }
            };
        }

        [Test]
        public void MatchStoredIr()
        {
            // Create test function to emit.
            this.module.CreateMainFunction();

            // Emit the module.
            string output = this.module.ToString();

            // Compare stored IR code with the actual, emitted output.
            Assert.AreEqual(this.storedIr, output);

            Assert.Pass();
        }
    }
}
