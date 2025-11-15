# MassTransit Basic Example

This repository provides a **basic example of using MassTransit** in a distributed system.  
Currently, the sample uses **RabbitMQ** as the message broker, but we plan to add examples for other brokers in the future.

---

## 🚀 Overview

The project demonstrates a simple message flow across three services:

1. **Client**  
   Publishes an initial message to simulate an incoming order (as if coming from a frontend).

2. **OrderService**  
   Consumes the message from the Client, processes the “order”, and then publishes another message for further processing.

3. **InventoryService**  
   Consumes the message from the OrderService and handles inventory-related tasks.

To see the full flow, **all three services must be running**.

---

## 🛠️ Prerequisites

Before running the project, ensure you have RabbitMQ installed and running locally.

### RabbitMQ Requirements

- RabbitMQ server should be running on your local machine  
  - **Port 5672** → Default AMQP port  
- The **Management Plugin** should be enabled if you want to view queues/exchanges in the UI  
  - **Port 15672** → Management Dashboard  
  - You can access it at: `http://localhost:15672`


