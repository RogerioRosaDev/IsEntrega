namespace SIS_ISENTREGA.Domain
{
    public interface IMatrizRepository :IReading<Matriz>,IRecording<Matriz>
    {
        void DeletarCascate(int id);
    }
}
