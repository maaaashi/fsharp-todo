namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open FsharpTodoApi.Domain

type UserJson =
    { id: string
      name: string }

type TodoJson =
    { id: string
      title: string
      check: bool
      user: UserJson }

type TodosJson = { todos: TodoJson list }

module GetTodosHandler =
    let private toResponseJson (Todos (todos: Todo list)) : TodosJson =
        { todos =
            todos
            |> List.map (fun (todo, user) ->
                { id = todo.id.ToString()
                  title = todo.title.ToString()
                  check = todo.status.Equals("done")
                  user = {
                    id = user.id.ToString()
                    name = user.name.ToString()
                  }}) }

    let handler: Task<IResult> =
        async {
            let todo: TodoTask =
                { id = TodoTaskId "blog_1"
                  title = TodoTaskTitle "タイトル1"
                  status = TodoTaskStatus "done" }

            let user: User =
                { id = UserId "user_1"
                  name = UserName "ユーザー1" }

            return toResponseJson (Todos [ Todo(todo, user) ]) |> Results.Ok
        }
        |> Async.StartAsTask
