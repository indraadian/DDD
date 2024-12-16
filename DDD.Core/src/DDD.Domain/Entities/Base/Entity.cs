using Newtonsoft.Json;

namespace DDD.Domain.Entities.Base;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public bool IsDeleted { get; protected set; }
    public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; protected set; } = DateTime.UtcNow;
    public DateTime? DeletedDate { get; protected set; }
    public string CreatedBy { get; protected set; } = string.Empty;
    public string? UpdatedBy { get; protected set; } = string.Empty;
    public string? DeletedBy { get; protected set; } = string.Empty;
    public string? Properties { get; protected set; } = string.Empty;
    public virtual PropertiesModel PropertiesModel
    {
        get
        {
            var propertiesModel = new PropertiesModel();
            if (!string.IsNullOrEmpty(Properties))
            {
                try
                {
                    propertiesModel = JsonConvert.DeserializeObject<PropertiesModel>(Properties);
                }
                catch (Exception)
                {
                    propertiesModel = new PropertiesModel();
                }
            }
            return propertiesModel!;
        }
    }

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

    public void UpateProperties()
    {
        if (PropertiesModel != null)
        {
            Properties = JsonConvert.SerializeObject(PropertiesModel);
        }
    }
}

public class PropertiesModel
{

}
