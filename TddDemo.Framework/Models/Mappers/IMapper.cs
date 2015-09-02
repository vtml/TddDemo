namespace TddDemo.Framework.Models.Mappers
{
    public interface IMapper<in TSource, out TTarget>
    {
        TTarget Map(TSource source);
    }
}
