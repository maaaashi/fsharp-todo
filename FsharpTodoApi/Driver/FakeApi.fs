namespace FsharpTodoApi.Driver

open System.Net.Http
open System.Net.Http.Json

type FakerApi(httpClient: HttpClient) =
    member this.client() = httpClient

module FakerApi =
    type TodoJson =
        { userId: int
          id: int
          title: string
          completed: bool }

    type TodosJson = TodoJson list
    let getTodos (client: FakerApi) : Async<TodosJson> =
        task {
            let! response = sprintf "/todos" |> client.client().GetAsync

            return! response.Content.ReadFromJsonAsync<TodosJson>()
        } |> Async.AwaitTask
