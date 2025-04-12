open System

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.HttpLogging
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

open System.Threading.Tasks
open FsharpTodoApi.Handler
open FsharpTodoApi.Domain
open FsharpTodoApi.Usecase

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddHttpLogging(fun logger -> logger.LoggingFields <- HttpLoggingFields.All)
    |> ignore

    let app = builder.Build()

    app.MapGet("/v1/systems/ping", Func<IResult>(fun () -> Results.Ok("pong")))
    |> ignore

    let todosGroup = app.MapGroup("/v1/todos")

    let deps: GetTodos.Deps = { getTodos = fun () -> async { return Todos [] } }

    todosGroup.MapGet("", Func<Task<IResult>>(fun _ -> GetTodosHandler.handler deps))
    |> ignore

    app.Run()

    0
