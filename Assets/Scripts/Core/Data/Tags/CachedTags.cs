using System.Collections.Generic;
using System.Linq;


namespace Core.Data.Tags
{
    public class CachedTags : ITags
    {
        private readonly ITags origin;
        private IReadOnlyList<ITag>? cachedAll;


        public CachedTags(ITags origin)
        {
            this.origin = origin;
        }


        public ITag New(string tag)
        {
            var @new = origin.New(tag);
            cachedAll = null;
            return @new;
        }


        public bool Contains(string tag)
        {
            return All().Any(t => t.Text() == tag);
        }


        public IReadOnlyList<ITag> All()
        {
            if (cachedAll == null)
            {
                var all = origin.All();
                cachedAll = all;
            }

            return cachedAll;
        }
    }
}