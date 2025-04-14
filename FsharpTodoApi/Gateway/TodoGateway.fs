namespace FsharpTodoApi.Gateway

open FsharpTodoApi.Port
open FsharpTodoApi.Domain
open FsharpTodoApi.Driver

open FSharpPlus

module TodoGateway =
    let toTodo (todoJson: FakerApi.TodoJson) : Todo =
        { Task =
            { Tid = TaskId todoJson.id
              Title = TaskTitle todoJson.title
              Status = TaskStatus todoJson.completed }
          User =
            { Uid = UserId todoJson.userId
              Name = UserName "" } }

    let getTodos (api: FakerApi) : GetTodos =
        fun () ->
            async {
                let! todosJson = FakerApi.getTodos api

                return todosJson |> List.map toTodo |> Todos
            }
