open System

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.HttpLogging
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

open System.Threading.Tasks
open FsharpTodoApi.Handler

open System.Text.Json
open System.Text.Json.Serialization
open System.Text.Json.FSharp

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services.Configure<JsonOptions>(fun options ->
        options.JsonSerializerOptions.Converters.Add(JsonFSharpConverter()))


    builder.Services.AddHttpLogging(fun logger -> logger.LoggingFields <- HttpLoggingFields.All)
    |> ignore

    let app = builder.Build()

    app.MapGet("/v1/systems/ping", Func<IResult>(fun () -> Results.Ok("pong")))
    |> ignore

    let todosGroup = app.MapGroup("/v1/todos")

    todosGroup.MapGet("", Func<Task<GetTodosHandlerResult>>(fun _ -> GetTodosHandler.handler))
    |> ignore

    app.Run()

    0
