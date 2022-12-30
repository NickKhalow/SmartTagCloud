using System;
using System.Diagnostics.CodeAnalysis;


namespace Core.Data
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public record Link(Guid id, Guid leftTag, Guid rightTag) : ILink
    {
        public Guid Id()
        {
            return id;
        }


        public Guid LeftTag()
        {
            return leftTag;
        }


        public Guid RightTag()
        {
            return rightTag;
        }
    }
}