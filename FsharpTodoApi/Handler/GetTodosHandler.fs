namespace FsharpTodoApi.Handler

open FsharpTodoApi.Domain
open System.Threading.Tasks
open System.Text.Json
open FSharp.SystemTextJson

type TodoJson =
    { id: string
      title: string
      check: bool }

type TodosJson = { todos: TodoJson list }

type GetTodosHandlerResult = Ok of TodosJson

module GetTodosHandler =
    let private toResponseJson (Todos todos) : TodosJson =
        { todos =
            todos
            |> List.map (fun (todo, user) ->
                { id = "1"
                  title = "title"
                  check = true }) }

    let handler: Task<GetTodosHandlerResult> =
        async {
            let todo: TodoTask =
                { id = TodoTaskId "blog_1"
                  title = TodoTaskTitle "タイトル1"
                  status = TodoTaskStatus "本文1" }

            let user: User =
                { id = UserId "user_1"
                  name = UserName "ユーザー1" }

            return toResponseJson (Todos [ Todo(todo, user) ]) |> Ok
        }
        |> Async.StartAsTask
