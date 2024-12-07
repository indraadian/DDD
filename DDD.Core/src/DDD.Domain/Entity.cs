namespace DDD.Domain;

public abstract class Entity
{
    public virtual Guid Id { get; protected set; }
    public virtual bool IsDeleted { get; protected set; }
    public virtual DateTime CreatedDate { get; protected set; }
    public virtual DateTime UpdatedDate { get; protected set; }
    public virtual DateTime? DeletedDate { get; protected set; }
    public virtual string CreatedBy { get; protected set; }
    public virtual string UpdatedBy { get; protected set; }
    public virtual string DeletedBy { get; protected set; }

    //TODO: set user
    public void SetCreated()
    {
        CreatedDate = DateTime.Now;
        SetUpdated();
    }

    public void SetUpdated()
    {
        UpdatedDate = DateTime.Now;
    }

    public void SetDeleted()
    {
        DeletedDate = DateTime.Now;
        SetDeleted();
    }
}
