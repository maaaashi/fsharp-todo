namespace FsharpTodoApi.Usecase

open FsharpTodoApi.Usecase.GetTodos
open FsharpTodoApi.Domain

open FsUnit
open NUnit.Framework


[<TestFixture>]
module GetTodosTest =
    [<Test>]
    let ``Todoを取得する`` () =
        let getTodos () =
            async {
                return
                    Todos
                        [ { Task =
                              { Tid = TaskId "1"
                                Title = TaskTitle "Todo 1"
                                Status = TaskStatus "Pending" }
                            User =
                              { Uid = UserId "1"
                                Name = UserName "User 1" } } ]
            }

        let deps = { getTodos = getTodos }
        let actual = execute deps |> Async.RunSynchronously

        actual
        |> should
            equal
            (Todos
                [ { Task =
                      { Tid = TaskId "1"
                        Title = TaskTitle "Todo 1"
                        Status = TaskStatus "Pending" }
                    User =
                      { Uid = UserId "1"
                        Name = UserName "User 1" } } ])
