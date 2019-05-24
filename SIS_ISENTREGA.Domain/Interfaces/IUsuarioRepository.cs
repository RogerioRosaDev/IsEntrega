namespace SIS_ISENTREGA.Domain
{
    public interface IUsuarioRepository : IReading<Usuario>,IRecording<Usuario>
    {
        Usuario FindLogin(string login, string senha);
    }
}
