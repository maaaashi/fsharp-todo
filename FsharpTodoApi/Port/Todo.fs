namespace FsharpTodoApi.Port

open FsharpTodoApi.Domain

type GetTodos = unit -> Async<Todos>