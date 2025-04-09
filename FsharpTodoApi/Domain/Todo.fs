namespace FsharpTodoApi.Domain

open FSharpPlus
open FSharpPlus.Lens

module TaskId =
    let inline _value f (TodoTaskId x) = f x <&> TodoTaskId

module TaskTitle =
    let inline _value f (TodoTaskTitle x) = f x <&> TodoTaskTitle

module TaskStatus =
    let inline _value f (TodoTaskStatus x) = f x <&> TodoTaskStatus

module UserId =
    let inline _value f (UserId x) = f x <&> UserId

module UserName =
    let inline _value f (UserName x) = f x <&> UserName

module Task =
    // let id_ = lens (fun t -> t.todoId) (fun v t -> { t with todoId = v })
    let inline _Id f b = f b.Tid <&> fun a -> { b with Tid = a }

    let inline _TaskId b = _Id << TaskId._value <| b

    let inline _Title f b =
        f b.Title <&> fun a -> { b with Title = a }

    let inline _TaskTitle b = _Title << TaskTitle._value <| b

    let inline _Status f b =
        f b.Status <&> fun a -> { b with Status = a }

    let inline _TaskStatus b = _Status << TaskStatus._value <| b

module User =
    let inline _Id f b = f b.Uid <&> fun a -> { b with Uid = a }

    let inline _UserId b = _Id << UserId._value <| b

    let inline _Name f b =
        f b.Name <&> fun a -> { b with Name = a }

    let inline _username b = _Name << UserName._value <| b
