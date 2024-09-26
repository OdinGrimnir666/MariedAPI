namespace Infrastructure.Intefaces;

public interface ICSVReader<T>
{
    public List<T> Read(StreamReader reader);
}