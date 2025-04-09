namespace FsharpTodoApi.Domain

type TaskId = TodoTaskId of string
type TaskTitle = TodoTaskTitle of string
type TaskStatus = TodoTaskStatus of string

type Task =
    { Tid: TaskId
      Title: TaskTitle
      Status: TaskStatus }

type UserId = UserId of string
type UserName = UserName of string

type User = { Uid: UserId; Name: UserName }

type Todo = { Task: Task; User: User }

type Todos = Todos of Todo list
