namespace RELS.Model
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public int PersonId { get; set; }

        public virtual required Person Person { get; set; }
    }
}
