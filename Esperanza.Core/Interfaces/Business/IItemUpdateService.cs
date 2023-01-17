namespace Esperanza.Core.Interfaces.Business
{
    public interface IItemUpdateService
    {
        Task UpdateProducts();
        Task UpdateCtaCte();
        Task UpdateLists();
        //Task UpdateTranspors();
        Task UpdateConditions();
    }
}
