using System.Collections.Generic;


namespace Core.Data
{
    public interface ILinks
    {
        ILink Bind(ITag left, ITag right);

        IReadOnlyList<ITag> Find(ITag withLinkedTag);
    }
}