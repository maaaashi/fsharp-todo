namespace FsharpTodoApi.Gateway

open FsharpTodoApi.Port
open FsharpTodoApi.Domain

module TodoGateway =
    let getTodos () : GetTodos = fun () -> async { return Todos [] }
