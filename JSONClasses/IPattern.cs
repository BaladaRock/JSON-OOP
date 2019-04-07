namespace JSONClasses
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
    
}