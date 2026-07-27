using OrderManager.Application.Abstractions.Observer;
using OrderManager.Application.Abstractions.Services;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Enums;
using OrderManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<ISubscriber<Order>> Subscribers = new();
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public void Attach(ISubscriber<Order> subscriber)
        {
            if (subscriber is null)
                throw new ArgumentNullException(nameof(subscriber));

            if (Subscribers.Contains(subscriber))
                return;

            Subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber<Order> subscriber)
        {
            if (subscriber is null)
                throw new ArgumentNullException(nameof(subscriber));

            Subscribers.Remove(subscriber);
        }

        public void Notify(Order order)
        {
            List<ISubscriber<Order>> snapshots = new(Subscribers);
            foreach (var subscriber in snapshots)
            {
                try
                {
                    subscriber.Update(order);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Subscriber {subscriber.GetType().Name} failed: {ex.Message}");
                }
            }
        }

        public void ChangeStatus(Order order, OrderStatus newStatus)
        {
            order.ChangeStatus(newStatus);

            Console.WriteLine( $"Order {order.Id} status changed to {order.Status}");

            Notify(order);
        }

        public bool Add(Order order)
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            order.ChangeStatus(OrderStatus.Confirmed);

            bool success = repository.Add(order);

            if (!success) return false;

            Notify(order);

            return success;
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }      
    }
}
