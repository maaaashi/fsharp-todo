namespace FsharpTodoApi.Driver

open System.Net.Http

type FakerApi(httpClient: HttpClient) =
    member this.client() = httpClient

module FakerApi =
    let getTodos = fun (client: FakerApi) -> async { return [] }
