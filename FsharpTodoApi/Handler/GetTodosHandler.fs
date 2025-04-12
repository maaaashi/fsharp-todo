namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open FsharpTodoApi.Domain
open FsharpTodoApi.Usecase
open FSharpPlus.Lens

type UserJson = { id: string; name: string }

type TodoJson =
    { id: string
      title: string
      status: string
      user: UserJson }

type TodosJson = { todos: TodoJson list }

module GetTodosHandler =
    let private toResponseJson (Todos(todos: Todo list)) : TodosJson =
        { todos =
            todos
            |> List.map (fun (todo) ->
                { id = view Task._TaskId todo.Task
                  title = view Task._TaskTitle todo.Task
                  status = view Task._TaskStatus todo.Task
                  user =
                    { id = view User._UserId todo.User
                      name = view User._UserName todo.User } }) }

    let handler
      (deps: GetTodos.Deps): Task<IResult> =
        async {
            let! todos = GetTodos.execute deps

            return toResponseJson todos |> Results.Ok
        }
        |> Async.StartAsTask
