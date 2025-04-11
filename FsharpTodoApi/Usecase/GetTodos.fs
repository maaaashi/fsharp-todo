namespace FsharpTodoApi.Usecase

open FsharpTodoApi.Domain

module GetTodos =
    let execute deps : Async<Todos> = async { return Todos [{
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
