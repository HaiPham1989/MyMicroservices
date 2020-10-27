namespace Ordering.Core.Entities.Base
{
    interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
