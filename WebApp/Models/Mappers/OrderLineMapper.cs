using LabProject.Models.Gravity;
using LabProject.Models.GravityEntities;
using LabProject.Models.GravityModels;

namespace LabProject.Models.Mappers;

public static class OrderLineMapper
{
    public static OrderLineEntity ToEntity(OrderLineModel model)
    {
        return new OrderLineEntity
        {
            OrderId = model.OrderId,
            BookId = model.BookId,
            Price = model.Price
        };
    }

    public static OrderLineModel ToModel(OrderLineEntity entity)
    {
        return new OrderLineModel
        {
            OrderId = entity.OrderId,
            BookId = entity.BookId,
            Price = entity.Price
        };
    }
}