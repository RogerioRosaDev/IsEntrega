namespace SIS_ISENTREGA.Domain
{
    public  class Ponto :Base
    {
        public int OidPonto { get; set; }

        public virtual Matriz Matriz { get; set; }
    }
}
