namespace View.Binds
{
    public interface IBind<in T>
    {
        void Bind(T value);
    }
}