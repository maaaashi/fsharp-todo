namespace FsharpTodoApi.Domain

open FSharpPlus
open FSharpPlus.Lens

let taskId = lens (fun (t: TodoTask) -> t.id) (fun v t -> { t with id = v })