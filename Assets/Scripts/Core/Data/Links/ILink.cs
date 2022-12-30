using System;


namespace Core.Data
{
    public interface ILink
    {
        Guid Id();


        Guid LeftTag();
        
        Guid RightTag();
    }
}