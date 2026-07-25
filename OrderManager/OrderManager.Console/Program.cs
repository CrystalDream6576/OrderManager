using Microsoft.Win32;
using OrderManager.Application.Abstractions;
using OrderManager.Application.Commands;
using OrderManager.Application.Handlers;
using OrderManager.Application.Mediator;
using OrderManager.Application.Queries;
using OrderManager.Console;
using OrderManager.Domain.Domain.Order;
using OrderManager.Infrastructure.Repositories;

class Program
{
    static void Main()
    {
        // 1. Create repository
        IOrderRepository orderRepository = new OrderRepository();

        // 2. Create handlers
        var createOrderHandler = new CreateOrderHandler(orderRepository);
        var deleteOrderHandler = new DeleteOrderHandler(orderRepository);
        var getAllOrdersHandler = new GetAllOrdersHandler(orderRepository);
        var getOrderByIdHandler = new GetOrderByIdHandler(orderRepository);

        // 3. Create registry
        IHandlerRegistry registry = new HandlerRegistry();

        // 4. Register handlers
        registry.Register<CreateOrderCommand, bool>(createOrderHandler);
        registry.Register<DeleteOrderCommand, bool>(deleteOrderHandler);
        registry.Register<GetAllOrdersQuery, IEnumerable<Order>>(getAllOrdersHandler);
        registry.Register<GetOrderByIdQuery, Order>(getOrderByIdHandler);

        // 5. Create mediator
        IMediator mediator = new OrderMediator(registry);

        // 6. Create controller
        var controller = new OrderController(mediator);

        // 7. Create orders
        bool Cheesecake = controller.CreateOrder("cheesecake",30);

        bool FruitTartCake = controller.CreateOrder("fruit tart cake", 50);

        bool MilkCake = controller.CreateOrder("Milk Cake", 45);

        Console.WriteLine($"First order created: {Cheesecake}");
        Console.WriteLine($"Second order created: {FruitTartCake}");
        Console.WriteLine($"Third order created: {MilkCake}");
        Console.WriteLine();

        // 8. Get all orders
        Console.WriteLine("All orders:");

        IEnumerable<Order> orders = controller.GetAllOrders();

        foreach (Order order in orders)
        {
            string result = string.Format("ID: {0}, Name: {1}, Total: {2}", order.Id, order.Name, order.Total);
            Console.WriteLine(result);
        }
        Console.WriteLine();

        // 9. Get one order
        try
        {
            Order order = controller.GetOrderById(2);

            Console.WriteLine("Order found:");
            string result = string.Format("ID: {0}, Name: {1}, Total: {2}", order.Id, order.Name, order.Total);
            Console.WriteLine(result);
        }
        catch (KeyNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        Console.WriteLine();

        // 10. Delete order
        int id = 3;
        bool deleted = controller.DeleteOrder(id);
        Console.WriteLine($"Order with ID {id} was deleted successfully.");
        Console.WriteLine();

        // 11. Display remaining orders
        Console.WriteLine("Remaining orders:");

        foreach (Order order in controller.GetAllOrders())
        {
            string result = string.Format("ID: {0}, Name: {1}, Total: {2}", order.Id, order.Name, order.Total);
            Console.WriteLine(result);
        }
    }
}