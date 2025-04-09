namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open FsharpTodoApi.Domain

type UserJson = { id: string; name: string }

type TodoJson =
    { id: string
      title: string
      check: bool
      user: UserJson }

type TodosJson = { todos: TodoJson list }

module GetTodosHandler =
    let private toResponseJson (Todos(todos: Todo list)) : TodosJson =
        { todos =
            todos
            |> List.map (fun (todo) ->
                { id = todo.Task.Tid.ToString()
                  title = todo.Task.Title.ToString()
                  check = todo.Task.Status.Equals("done")
                  user =
                    { id = todo.User.Uid.ToString()
                      name = todo.User.Name.ToString() } }) }

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
