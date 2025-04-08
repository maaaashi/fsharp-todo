namespace FsharpTodoApi.Domain

type TodoTaskId = TodoTaskId of string
type TodoTaskTitle = TodoTaskTitle of string
type TodoTaskStatus = TodoTaskStatus of string

type TodoTask =
    { tid: TodoTaskId
      title: TodoTaskTitle
      status: TodoTaskStatus }

type UserId = UserId of string
type UserName = UserName of string

type User = { uid: UserId; name: UserName }

type Todo = TodoTask * User

type Todos = Todos of Todo list
