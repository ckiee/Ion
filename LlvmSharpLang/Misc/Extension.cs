using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LLVMSharp;
using LlvmSharpLang.SyntaxAnalysis;

using TokenTypeMap = System.Collections.Generic.Dictionary<string, LlvmSharpLang.SyntaxAnalysis.TokenType>;

namespace LlvmSharpLang.Misc
{
    public static class Extension
    {
        public static string Capitalize(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));

                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));

                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        /// <summary>
        /// Create a new LLVM block builder and position
        /// it accordingly.
        /// </summary>
        public static LLVMBuilderRef CreateBuilder(this LLVMBasicBlockRef block, bool positionAtStart = true)
        {
            // Create a new builder.
            LLVMBuilderRef builder = LLVM.CreateBuilder();

            // Position the builder at the beginning of the block.
            if (positionAtStart)
            {
                LLVM.PositionBuilderBefore(builder, block.GetLastInstruction());
            }
            // Otherwise, at the end of the block.
            else
            {
                LLVM.PositionBuilderAtEnd(builder, block);
            }

            // Return the linked builder.
            return builder;
        }

        public static bool Some(this TokenTypeMap map, Func<string, bool> callback)
        {
            foreach (string str in map.Keys)
            {
                if (callback(str))
                {
                    return true;
                }
            }

            return false;
        }

        public static TokenTypeMap SortByKeyLength(this TokenTypeMap map)
        {
            string[] keys = new string[map.Count];

            map.Keys.CopyTo(keys, 0);

            List<String> keyList = new List<string>(keys);

            // Sort the keys by length.
            keyList.Sort((a, b) =>
            {
                if (a.Length > b.Length)
                {
                    return -1;
                }
                else if (b.Length > a.Length)
                {
                    return 1;
                }

                return 0;
            });

            TokenTypeMap updated = new Dictionary<string, TokenType>();

            foreach (var item in keyList)
            {
                updated[item] = map[item];
            }

            return updated;
        }
    }
}
