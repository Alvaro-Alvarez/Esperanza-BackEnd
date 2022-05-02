using Esperanza.Core.Models;

namespace Esperanza.Service.Helpers
{
    public static class EntityHelper
    {
        public static void InitEntity(Entity entity, Guid userGuid)
        {
            entity.Guid = Guid.NewGuid();
            entity.CreatedBy = userGuid;
            entity.UpdatedBy = userGuid;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.Deleted = false;
        }

        public static void ModifyEntity(Entity entity, Guid userGuid, bool delete = false)
        {
            entity.UpdatedBy = userGuid;
            entity.UpdatedAt = DateTime.Now;
            if (delete) entity.Deleted = false;
        }
    }
}
