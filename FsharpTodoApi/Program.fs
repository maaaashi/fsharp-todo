open System

open System.Text.Json
open System.Text.Json.Serialization
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.HttpLogging
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

open System.Threading.Tasks
open FsharpTodoApi.Handler

type DiscriminatedUnionConverter<'T>() =
    inherit JsonConverter<'T>()

    override this.Read(reader: byref<Utf8JsonReader>, typeToConvert: Type, options: JsonSerializerOptions) =
        // カスタム読み取りロジックを実装します
        raise (NotImplementedException())

    override this.Write(writer: Utf8JsonWriter, value: 'T, options: JsonSerializerOptions) =
        // カスタム書き込みロジックを実装します
        raise (NotImplementedException())

type YourDiscriminatedUnionType =
    | Case1 of string
    | Case2 of int

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddHttpLogging(fun logger -> logger.LoggingFields <- HttpLoggingFields.All)
    |> ignore

    builder.Services.Configure<JsonSerializerOptions>(fun (options: JsonSerializerOptions) ->
        options.Converters.Add(DiscriminatedUnionConverter<YourDiscriminatedUnionType>()))
    |> ignore

    let app = builder.Build()

    app.MapGet("/v1/systems/ping", Func<IResult>(fun () -> Results.Ok("pong")))
    |> ignore

    let todosGroup = app.MapGroup("/v1/todos")

    todosGroup.MapGet("", Func<Task<GetTodosHandlerResult>>(fun _ -> GetTodosHandler.handler))
    |> ignore

    app.Run()

    0
