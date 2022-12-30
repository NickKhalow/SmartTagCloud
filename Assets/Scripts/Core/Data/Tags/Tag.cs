using System;
using System.Diagnostics.CodeAnalysis;


namespace Core.Data
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public record Tag(Guid id, string text) : ITag
    {
        public Guid Id()
        {
            return id;
        }


        public string Text()
        {
            return text;
        }
    }
}