🧠 Lambda Architecture Workshop (.NET + Kafka)
=============================================

This workshop demonstrates a simplified Lambda Architecture implemented with .NET and Kafka.
It features three processing layers:

- Batch Layer: historical, accurate processing
- Speed Layer: real-time, approximate processing
- Serving Layer: unified access to results

------------------------------------------------------

🚀 Requirements
---------------
- .NET 8 SDK: https://dotnet.microsoft.com/en-us/download
- Docker: https://www.docker.com/products/docker-desktop/
- curl: https://curl.se/ (or use Postman for testing)
- (Optional) Kafka UI: https://github.com/provectus/kafka-ui

------------------------------------------------------

📁 Project Structure
--------------------
├── BatchProcessor/         # Batch processing (accurate/historical)

├── SpeedProcessor/         # Real-time processing (Kafka + MediatR)

├── ServingApi/             # Unified API endpoint

├── Shared/                 # Shared models and events

├── docker-compose.yml      # Kafka + Zookeeper setup + Kafdrop + Rest-proxy

------------------------------------------------------

🔧 Getting Started
------------------

1. Clone the repository:
   git clone https://github.com/your-org/lambda-architecture-demo.git
   cd lambda-architecture-demo

2. Start Kafka and Zookeeper (kafdrop and rest-proxy):
   docker-compose up -d

   This starts:
   - Kafka at localhost:29092
   - Zookeeper at localhost:2181
   - Kafdrop at localhost:9000
   - Rest-proxy at localhost:8082

3. Run the services (in separate terminals):
   dotnet run --project BatchProcessor
   dotnet run --project ServingApi

4. Send an event to Kafka (with REST Proxy on localhost:8082):
   curl --location 'http://localhost:8082/topics/speed-events' \
        --header 'Content-Type: application/vnd.kafka.json.v2+json' \
        --header 'Accept: application/vnd.kafka.v2+json' \
        --data '{
            "records": [
              {
                "value": {
                  "Source": "Kafka-Queue",
                  "Payload": "evento-speed-batch-test",
                  "Timestamp": "2025-06-10T20:00:00Z"
                }
              }
            ]
          }'


   If not using REST Proxy, use tools like kcat or Kafka UI.

6. Verify it was processed:
   Check SpeedProcessor logs for consumed event via MediatR.

7. Query the Serving API:
   curl --location 'http://localhost:5246/api/events' \
        --header 'Content-Type: application/json' \
        --data '{
            "source": "Serving",
            "payload": "evento-speed-batch-test"
        }'

   This returns results from both speed and batch layers.

------------------------------------------------------

🛠️ Customize It
----------------
- Edit Shared/Events/EventReceived.cs for custom event models.
- Add logic inside Handlers of BatchProcessor and SpeedProcessor.
- Expand ServingApi with more endpoints or data aggregation.

------------------------------------------------------

✅ Conclusion
-------------
This workshop shows how to:

- Combine real-time and batch processing
- Ingest/distribute events using Kafka
- Use MediatR, .NET background services, and REST APIs
- Build a data pipeline based on Lambda Architecture

Happy coding! 🎯
