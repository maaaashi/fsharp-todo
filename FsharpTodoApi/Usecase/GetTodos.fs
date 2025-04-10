namespace FsharpTodoApi.Usecase

open FsharpTodoApi.Domain

module GetTodos =
    let execute deps : Async<Todos> = async { return Todos [] }
