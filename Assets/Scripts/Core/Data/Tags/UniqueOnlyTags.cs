using System;
using System.Collections.Generic;


namespace Core.Data.Tags
{
    public class UniqueOnlyTags : ITags
    {
        private readonly ITags origin;


        public UniqueOnlyTags(ITags origin)
        {
            this.origin = origin;
        }


        public ITag New(string tag)
        {
            if (Contains(tag))
            {
                throw new InvalidOperationException("Already contains");
            }

            return origin.New(tag);
        }


        public bool Contains(string tag)
        {
            return origin.Contains(tag);
        }


        public IReadOnlyList<ITag> All()
        {
            return origin.All();
        }
    }
}