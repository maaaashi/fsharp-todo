namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open FsharpTodoApi.Domain

type TodoJson =
    { id: string
      title: string
      check: bool }

type TodosJson = { todos: TodoJson list }

module GetTodosHandler =
    let private toResponseJson (Todos todos) : TodosJson =
        { todos =
            todos
            |> List.map (fun (todo, user) ->
                { id = "1"
                  title = "title"
                  check = true }) }

    let handler: Task<IResult> =
        async {
            let todo: TodoTask =
                { id = TodoTaskId "blog_1"
                  title = TodoTaskTitle "タイトル1"
                  status = TodoTaskStatus "本文1" }

            let user: User =
                { id = UserId "user_1"
                  name = UserName "ユーザー1" }

            return toResponseJson (Todos [ Todo(todo, user) ]) |> Results.Ok
        }
        |> Async.StartAsTask
