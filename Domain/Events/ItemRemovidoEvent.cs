
using Domain.Entities;
using MediatR;

namespace Domain.Events
{
	public class ItemRemovidoEvent : INotification
	{
		public Pedido Pedido { get; init; }
		public int ItemId { get; init; }

		public ItemRemovidoEvent(Pedido pedido, int itemId)
		{
			Pedido = pedido;
			ItemId = itemId;
		}
	}
}
