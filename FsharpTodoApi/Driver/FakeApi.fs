namespace FsharpTodoApi.Driver

open System.Net.Http

type FakerApi(httpClient: HttpClient) =
    member this.client() = httpClient

module FakerApi =
    type TodoJson =
        { userId: string
          id: string
          title: string
          completed: string }

    type TodosJson = TodoJson list
    let getTodos (client: FakerApi) : Async<TodosJson> = task { return [] } |> Async.AwaitTask
