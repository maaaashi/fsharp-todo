namespace FsharpTodoApi.Usecase

open FsharpTodoApi.Domain
open FsharpTodoApi.Port

module GetTodos =
    type Deps = { getTodos: GetTodos }
    let execute (deps: Deps) : Async<Todos> = async {
        let! todos = deps.getTodos ()
        return todos
    }
