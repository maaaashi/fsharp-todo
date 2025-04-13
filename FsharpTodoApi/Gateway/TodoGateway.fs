namespace FsharpTodoApi.Gateway

open FsharpTodoApi.Port
open FsharpTodoApi.Domain
open FsharpTodoApi.Driver

module TodoGateway =
    let getTodos (api: FakerApi) : GetTodos =
        fun () ->
            async {
                let! todosResponseJson = FakerApi.getTodos api
                return Todos []
            }
