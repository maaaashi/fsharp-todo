namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open FsharpTodoApi.Domain
open FSharpPlus.Lens

type UserJson = { id: string; name: string }

type TodoJson =
    { id: string
      title: string
      check: string
      user: UserJson }

type TodosJson = { todos: TodoJson list }

module GetTodosHandler =
    let private toResponseJson (Todos(todos: Todo list)) : TodosJson =
        { todos =
            todos
            |> List.map (fun (todo) ->
                { id = view Task._TaskId todo.Task
                  title = view Task._TaskTitle todo.Task
                  check = view Task._TaskStatus todo.Task
                  user =
                    { id = view User._UserId todo.User
                      name = view User._UserName todo.User } }) }

    let handler: Task<IResult> =
        async {
            let todoTask: Task =
                { Tid = TodoTaskId "blog_1"
                  Title = TodoTaskTitle "タイトル1"
                  Status = TodoTaskStatus "done" }

            let user: User =
                { Uid = UserId "user_1"
                  Name = UserName "ユーザー1" }

            let todo = { Task = todoTask; User = user }

            return toResponseJson (Todos [ todo ]) |> Results.Ok
        }
        |> Async.StartAsTask
