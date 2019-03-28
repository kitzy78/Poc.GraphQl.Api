# Poc.GraphQl.Api

***
<dl>
  <dt>Docker Compose commands</dt>
  <dd>docker-compose up</dd>
</dl>

Exposed on port 5000

Rest API hosting
[http://localhost:5000/api/values](http://localhost:5000/api/values)

GraphQL query tuning can be performed in GraphiQL under the Development environment.
[GraphiQL with basic query](http://localhost:5000/graphql/?query=query%20dataQuery(%24id%3A%20String!)%20%7B%0A%20%20myDataItem%3A%20dataItem(id%3A%20%24id)%20%7B%0A%20%20%20%20id%0A%20%20%20%20description%0A%20%20%7D%0A%20%20dataList%20%7B%0A%20%20%20%20id%0A%20%20%20%20description%0A%20%20%20%20calculatedField%0A%20%20%7D%0A%7D%0A&operationName=dataQuery&variables=%7B%0A%20%20%22id%22%3A%20%22b371e187-2360-44b3-9fd1-1ba3f25e3410%22%0A%7D)