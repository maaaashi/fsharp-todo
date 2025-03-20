namespace FsharpTodoApi.Domain

type TodoTaskId = TodoTaskId of string
type TodoTaskTitle = TodoTaskTitle of string
type TodoTaskStatus = TodoTaskStatus of string

type TodoTask =
    { id: TodoTaskId
      title: TodoTaskTitle
      status: TodoTaskStatus }

type UserId = UserId of string
type UserName = UserName of string

type User =
    { id: UserId
      name: UserName }

type Todo = TodoTask * User

type Todos = Todos of Todo list