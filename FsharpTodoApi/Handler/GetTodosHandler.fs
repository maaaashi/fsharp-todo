namespace FsharpTodoApi.Handler

open FsharpTodoApi.Domain
open System.Threading.Tasks

type TodoJson =
    { id: string
      title: string
      check: bool }

type TodosJson =
    { todos: TodoJson list }


type GetTodosHandlerResult =
    | Ok of TodosJson
    | Error of string

module GetTodosHandler =
    let private toResponseJson (todos: Todos) : TodosJson =
        { todos = [] }

    let handler: Task<GetTodosHandlerResult> =
        async {
            let todo: TodoTask =
              { id = TodoTaskId "blog_1"
                title = TodoTaskTitle "タイトル1"
                status = TodoTaskStatus "本文1" }
            let user: User =
                { id = UserId "user_1"
                  name = UserName "ユーザー1" }

            return toResponseJson (Todos [ Todo (todo, user)]) |> Ok
        }
        |> Async.StartAsTask
