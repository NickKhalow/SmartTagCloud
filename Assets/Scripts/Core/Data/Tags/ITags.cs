using System.Collections.Generic;


namespace Core.Data
{
    public interface ITags
    {
        ITag New(string tag);


        bool Contains(string tag);


        IReadOnlyList<ITag> All();
    }
}