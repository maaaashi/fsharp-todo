namespace FsharpTodoApi.Gateway

open FsharpTodoApi.Port
open FsharpTodoApi.Domain
open FsharpTodoApi.Driver

open FSharpPlus

module TodoGateway =
    let toTodo (todoJson: FakerApi.TodoJson) : Todo =
        { Task =
            { Tid = TaskId (string todoJson.id)
              Title = TaskTitle todoJson.title
              Status = TaskStatus (match todoJson.completed with
                                   | true -> "completed"
                                   | false -> "pending") }
          User =
            { Uid = UserId (string todoJson.userId)
              Name = UserName (sprintf "User_%d" todoJson.userId) } }

    let getTodos (api: FakerApi) : GetTodos =
        fun () ->
            async {
                let! todosJson = FakerApi.getTodos api

                return todosJson |> List.map toTodo |> Todos
            }
