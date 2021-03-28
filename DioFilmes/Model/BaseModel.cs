namespace DioFilmes.Model
{
    public abstract class BaseModel
    {
        public int Id { get; protected set; }
        public bool Excluido { get; protected set; }
    }
}