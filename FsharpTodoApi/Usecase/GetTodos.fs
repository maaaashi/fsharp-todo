namespace FsharpTodoApi.Usecase

open FsharpTodoApi.Domain
open FsharpTodoApi.Port

module GetTodos =
    type Deps = { getTodos: GetTodos }
    let execute (deps: Deps) : Async<Todos> = async { return Todos [{
        Task = {
            Tid = TodoTaskId "1"
            Title = TodoTaskTitle "Todo 1"
            Status = TodoTaskStatus "Pending"
        }
        User = {
            Uid = UserId "1"
            Name = UserName "User 1"
        }
    }] }
