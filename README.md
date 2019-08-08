## Project
- The purpose of this project is to show the use of RabbitMQ + C# (.NET) with a generic and simple to understand implementation.

### What will be shown in this project?

- How to send messages to a specific Exchange on RabbitMQ
- How to bind the Exchange to a queue
- How to consume messages form a specific Queue
- How to set up Dead Letters Exchanges and bind them to a queue

## RabbitMQ Installation

- First if you are on Windows 64 bits go to [Erlang Page](https://www.erlang.org/downloads) and download the latest version
- Download and Install the latest version of [RabbitMQ](https://www.rabbitmq.com/download.html)
- Go to your RabbitMQ installation folder usually on `C:\Program Files\RabbitMQ Server\rabbitmq_server-3.7.17`
- Navigate to sbin folder inside `..\RabbitMQ Server\rabbitmq_server-3.7.17\sbin` and open cmd there
- Execute the above command on cmd
`rabbitmq-plugins enable rabbitmq_management`
- Restart RabbitMQ server
`Search for 'Rabbitmq service - stop' and for 'Rabbitmq service -start' to restart your server`
- Restart your browser
- Go to [RabbitMQ Management Page](http://localhost:15672)
- You should see the above page:
![image]()
- RabbitMQ default credentials:
`Username: guest | Password: guest`
![image]()

## Setting Up RabbitMQ

### Queue Configuration
- Go to `Queues` Tab on RabbitMQ
- Clik on `Add a new queue` bellow the table with all queues
- Create three new queues with the following configuration
```
Name: log_order  
Durabillity: Durable  
Auto delete: No  
Arguments: Leave it empty  
```
```
Name: error_order  
Durabillity: Durable  
Auto delete: No  
Arguments: Leave it empty  
```
```
Name: email_order  
Durabillity: Durable  
Auto delete: No  
Arguments: x-dead-letter-exchange = sale_order_dead_letter, x-dead-letter-routing-key = email_order
```

### Exchange Configuration
- Go to `Exchanges` Tab on RabbitMQ
- Clik on `Add a new Exchange` bellow the table with all exchanges
- Create two new Exchanges named `SaleOrder` and `sale_order_dead_letter` both with `Type: topic | Durabillity: Durable | Auto delete: No | Internal: No` and let `Arguments` empty
#### Remember these configurations are default for the project, if you wish to change the names remember to adapt the project to them on the following steps!
- Click on the new Exchange named SaleOrder
- Inside SaleOrder click on `Bindings`
- Create two new Bidings:
```
To queue: email_order
Routing Key: order
Arguments: Leave it empty
```
```
To queue: log_order
Routing Key: order
Arguments: Leave it empty
```
- Now go back to Exchanges and go to `sale_order_dead_letter` exchange
- Create a new Biding:
```
To queue: error_order
Routing Key: email_order
Arguments: Leave it empty
```

## Running Project

- Open your visual studio and open `SaleOrder.RabbitMq.sln`
- Wait until Visual Studio install all dependencies
- Right click on Solution 'SaleOrder.RabbitMq' -> Properties (or Alt + Enter)
- Expand the Common Properties node and choose Startup Project.
- Choose the Multiple Startup Projects option.
- Mark SaleOrder.RabbitMq.Email, SaleOrder.RabbitMq.Error, SaleOrder.RabbitMq.Log, SaleOrder.RabbitMq.Order as "Start".
- Run the project -> Ctrl + F5 or F5 to debug
- Wait Visual Studio to compile the project
- The project should be running without problems.

## Contact
- If you need to contact me send me a email `xr.emerson@gmail.com`
