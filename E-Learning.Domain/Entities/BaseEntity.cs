namespace E_Learning.Domain.Entities
{
    public class BaseEntity<Key>
    {
        public Key Id { get; private set; }

        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }

        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }
        public string? DeletedBy { get; private set; }

        public bool IsDeleted { get; private set; }

        public void SetCreated(string user)
        {
            CreatedOn = DateTime.UtcNow;
            CreatedBy = user;
        }

        public void SetUpdated(string user)
        {
            UpdatedOn = DateTime.UtcNow;
            UpdatedBy = user;
        }

        public void SetDeleted(string user)
        {
            DeletedOn = DateTime.UtcNow;
            DeletedBy = user;
            IsDeleted = true;
        }
    }
}
