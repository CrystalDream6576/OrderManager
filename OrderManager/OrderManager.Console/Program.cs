using OrderManager.Application.Abstractions.Mediator;
using OrderManager.Application.Abstractions.Services;
using OrderManager.Application.Commands;
using OrderManager.Application.Handlers;
using OrderManager.Application.Mediator;
using OrderManager.Application.Queries;
using OrderManager.Application.Repositories;
using OrderManager.Application.Services;
using OrderManager.Console;
using OrderManager.Domain.Entities;
using OrderManager.Infrastructure.Repositories;
using OrderManager.Notification.Bridge;
using OrderManager.Notification.Providers;
using OrderManager.Notification.Subscribers;

internal static class Program
{
    private static void Main()
    {
        OrderController controller = ConfigureApplication();

        CreateSampleOrders(controller);
        DisplayAllOrders(controller);
        DisplayOrderById(controller, 2);
        DeleteOrder(controller, 3);
        DisplayRemainingOrders(controller);
    }

    private static OrderController ConfigureApplication()
    {
        IOrderRepository orderRepository = new OrderRepository();

        IOrderService orderService = CreateOrderService(orderRepository);

        IHandlerRegistry registry = CreateHandlerRegistry(orderRepository, orderService);

        IMediator mediator = new OrderMediator(registry);

        return new OrderController(mediator);
    }

    private static IOrderService CreateOrderService (IOrderRepository orderRepository)
    {
        var orderService =new OrderService(orderRepository);

        RegisterSubscribers(orderService);

        return orderService;
    }

    private static void RegisterSubscribers(IOrderService orderService)
    {
        IMessageProvider messageProvider = new EmailProvider();

        OrderNotification notification = new EmailNotification(messageProvider);

        var customerSubscriber = new CustomerOrderSubscriber(notification);

        orderService.Attach(customerSubscriber);
    }

    private static IHandlerRegistry CreateHandlerRegistry(IOrderRepository orderRepository, IOrderService orderService)
    {
        IHandlerRegistry registry = new HandlerRegistry();

        RegisterCommandHandlers(registry, orderService);

        RegisterQueryHandlers(registry, orderRepository);

        return registry;
    }

    private static void RegisterCommandHandlers(IHandlerRegistry registry, IOrderService orderService)
    {
        var createOrderHandler = new CreateOrderHandler(orderService);

        var deleteOrderHandler = new DeleteOrderHandler(orderService);

        registry.Register<CreateOrderCommand, bool>(createOrderHandler);

        registry.Register<DeleteOrderCommand, bool>(deleteOrderHandler);
    }

    private static void RegisterQueryHandlers(IHandlerRegistry registry, IOrderRepository orderRepository)
    {
        var getAllOrdersHandler = new GetAllOrdersHandler(orderRepository);

        var getOrderByIdHandler = new GetOrderByIdHandler(orderRepository);

        registry.Register<GetAllOrdersQuery, IEnumerable<Order>>( getAllOrdersHandler);

        registry.Register<GetOrderByIdQuery, Order>(getOrderByIdHandler);
    }

    private static void CreateSampleOrders(OrderController controller)
    {
        bool cheesecakeCreated =controller.CreateOrder("Cheesecake", 30);

        bool fruitTartCreated = controller.CreateOrder("Fruit Tart Cake", 50);

        bool milkCakeCreated = controller.CreateOrder("Milk Cake", 45);

        Console.WriteLine($"First order created: {cheesecakeCreated}");

        Console.WriteLine($"Second order created: {fruitTartCreated}");

        Console.WriteLine($"Third order created: {milkCakeCreated}");

        Console.WriteLine();
    }

    private static void DisplayAllOrders(OrderController controller)
    {
        Console.WriteLine("All orders:");

        IEnumerable<Order> orders = controller.GetAllOrders();

        PrintOrders(orders);

        Console.WriteLine();
    }

    private static void DisplayOrderById(OrderController controller, int id)
    {
        try
        {
            Order order = controller.GetOrderById(id);

            Console.WriteLine("Order found:");

            PrintOrder(order);
        }
        catch (KeyNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }

        Console.WriteLine();
    }

    private static void DeleteOrder(OrderController controller, int id)
    {
        bool deleted =
            controller.DeleteOrder(id);

        if (deleted)
        {
            Console.WriteLine($"Order with ID {id} was deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Order with ID {id} could not be deleted.");
        }

        Console.WriteLine();
    }

    private static void DisplayRemainingOrders(OrderController controller)
    {
        Console.WriteLine("Remaining orders:");

        IEnumerable<Order> orders = controller.GetAllOrders();

        PrintOrders(orders);
    }

    private static void PrintOrders(IEnumerable<Order> orders)
    {
        foreach (Order order in orders)
        {
            PrintOrder(order);
        }
    }

    private static void PrintOrder(Order order)
    {
        string result = string.Format("ID: {0}, Name: {1}, Total: {2:C}, Status: {3}",
            order.Id,
            order.Name,
            order.Total,
            order.Status);

        Console.WriteLine(result);
    }
}