namespace Entidad.Vo
{
    public class Result
    {
        public int Codigo { get; set; }
        public string Message { get; set; }

        public Result(int codigo, string message)
        {
            Codigo = codigo;
            Message = message;
        }
        public Result()
        {

        }
    }
}
