namespace FsharpTodoApi.Domain

open FSharpPlus
open FSharpPlus.Lens

module TodoTaskId =
    let inline _value f (TodoTaskId x) = f x <&> TodoTaskId

module TodoTaskTitle =
    let inline _value f (TodoTaskTitle x) = f x <&> TodoTaskTitle

module TodoTaskStatus =
    let inline _value f (TodoTaskStatus x) = f x <&> TodoTaskStatus

module UserId =
    let inline _value f (UserId x) = f x <&> UserId

module UserName =
    let inline _value f (UserName x) = f x <&> UserName

module TodoTask =
    // let id_ = lens (fun t -> t.todoId) (fun v t -> { t with todoId = v })
    let inline _id f b = f b.tid <&> fun a -> { b with tid = a }

    let inline _todoId b = _id << TodoTaskId._value <| b

    let inline _title f b =
        f b.title <&> fun a -> { b with title = a }

    let inline _todoTitle b = _title << TodoTaskTitle._value <| b

    let inline _status f b =
        f b.status <&> fun a -> { b with status = a }

    let inline _todoStatus b = _status << TodoTaskStatus._value <| b

module User =
    let inline _id f b = f b.uid <&> fun a -> { b with uid = a }

    let inline _userId b = _id << UserId._value <| b

    let inline _name f b =
        f b.name <&> fun a -> { b with name = a }

    let inline _username b = _name << UserName._value <| b
