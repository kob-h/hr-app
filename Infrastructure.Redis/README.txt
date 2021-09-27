1. Redis can also be used as a message broker as can be seen here https://www.youtube.com/watch?v=jwek4w6als4 on 11:00, 
but it it does not have persistence options for the messages and thus, not always reliable.
Soruce:https://www.educba.com/rabbitmq-vs-redis/
2. 
According to this video https://www.youtube.com/watch?v=jwek4w6als4 on 9:20 this is the command to spin up a redis server:
docker run -p 6389:6379 --name redis-master -e REDIS_REPLICATION_MODE=master -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest
3. To add additional replica, as seen in this video https://www.youtube.com/watch?v=jwek4w6als4 at 15:00:
docker run -p 6389:6379 --name redis-replica --link redis-master:master -e REDIS_REPLICATION_MODE=slave REDIS_MASTER_HOST=master
-e REDIS_MASTER_PORT_NUMBER -e REDIS_MASTER_PASSWORD= -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest

