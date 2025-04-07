namespace FsharpTodoApi.Domain

open FSharpPlus
open FSharpPlus.Lens

module TodoTaskId =
    let inline _value f (TodoTaskId x) = f x <&> fun x -> TodoTaskId x
