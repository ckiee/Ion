using System;
using Ion.CodeGeneration.Structure;
using Ion.CognitiveServices;
using Ion.Core;

namespace Ion.Misc
{
    public abstract class Named
    {
        public string Name { get; protected set; }

        protected Named()
        {
            // Set anonymous name as default.
            this.SetNameAnonymous();
        }

        /// <summary>
        /// Sets the name and validates it.
        /// </summary>
        public void SetName(string name)
        {
            // Ensure name is not null nor empty.
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Unexpected name to be null or empty");
            }
            // Ensure identifier pattern matches provided name.
            else if (Pattern.Identifier.IsMatch(name))
            {
                this.Name = name;
            }
            // Otherwise, throw an error.
            else
            {
                throw new Exception($"Invalid name: {name}");
            }
        }

        /// <summary>
        /// Sets the name to the special name of
        /// anonymous.
        /// </summary>
        public void SetNameAnonymous()
        {
            // Retrieve name from the name counter.
            string name = NameCounter.GetAnonymous();

            // Assign the name.
            this.SetName(name);
        }
    }
}
