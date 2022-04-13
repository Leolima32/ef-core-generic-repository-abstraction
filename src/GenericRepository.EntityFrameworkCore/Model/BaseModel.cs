namespace GenericRepository.EntityFrameworkCore.Model
{
    public abstract class BaseModel
    {

        public BaseModel()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }

        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public bool Active { get; private set; }

        public void Deactivate()
        {
            this.Active = false;
        }
    }
}
