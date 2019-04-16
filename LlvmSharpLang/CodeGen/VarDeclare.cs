using LLVMSharp;
using LlvmSharpLang.CodeGen;
using LlvmSharpLang.CodeGen.Structure;

namespace LlvmSharpLang
{
    // TODO: This should be somehow boxed around "statement" so it emits within a body.
    public class VarDeclare : Named, IStatement, IEntity<LLVMValueRef, LLVMBuilderRef>
    {
        public StatementType StatementType => StatementType.Declaration;

        public Type Type { get; protected set; }

        public Expr Value { get; set; }

        public VarDeclare(Type type, Expr value)
        {
            this.Type = type;
            this.Value = value;
        }

        public LLVMValueRef Emit(LLVMBuilderRef context)
        {
            // Create the variable.
            LLVMValueRef variable = LLVM.BuildAlloca(context, this.Type.Emit(), this.Name);

            // Assign value if applicable.
            if (this.Value != null)
            {
                LLVM.BuildStore(context, this.Value.Emit(), variable);
            }

            return variable;
        }
    }
}
