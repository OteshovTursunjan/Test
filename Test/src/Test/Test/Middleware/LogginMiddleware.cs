using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Tests.Core.Enteties;
namespace Test.Middleware;
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _rabbitMqConnectionString;
    private readonly string _queueName;

    public LoggingMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _rabbitMqConnectionString = configuration["RabbitMQ:ConnectionString"];
        _queueName = configuration["RabbitMQ:QueueName"] ?? "logs_queue";
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Логирование запроса и ответа (ваш существующий код)
        var combinedData = new
        {
            Method = context.Request.Method,
            Path = context.Request.Path,
            QueryString = context.Request.QueryString.ToString(),
            Headers = context.Request.Headers,
            Timestamp = DateTime.Now
        };

        // Создаем объект лога на основе модели ExamLog
        var logEntry = new ExamLogs
        {
            Message = JsonSerializer.Serialize(combinedData),
            DateTime = DateTime.Now
        };

        // Использование строки подключения и имени очереди из конфигурации
        SendToRabbitMq(_queueName, logEntry, _rabbitMqConnectionString);

        // Продолжаем выполнение пайплайна
        await _next(context);
    }

    private static void SendToRabbitMq(string queueName, object data, string connectionString)
    {
        try
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(connectionString)
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: queueName,
                durable: true, // Изменено на true для сохранения сообщений при перезапуске RabbitMQ
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: queueName,
                basicProperties: null,
                body: body);
        }
        catch (Exception ex)
        {
            // Добавляем обработку ошибок, чтобы middleware не вызывал сбой приложения
            Console.WriteLine($"Ошибка при отправке в RabbitMQ: {ex.Message}");
        }
    }
}
