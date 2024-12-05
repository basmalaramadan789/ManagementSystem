module LibraryManagementSystemModule.LibraryManagement

open System
open LibraryManagementSystemModule.Book

let library = System.Collections.Generic.Dictionary<string, Book>()

let addBook title author genre =
    let newBook = { Title = title; Author = author; Genre = genre; Status = "Available"; BorrowDate = None }
    library.[title] <- newBook

let searchBook title =
    match library.TryGetValue(title) with
    | true, book -> Some book
    | false, _ -> None

let borrowBook title =
    match searchBook title with
    | Some book when book.Status = "Available" ->
        let borrowedBook = { book with Status = "Borrowed"; BorrowDate = Some DateTime.Now }
        library.[title] <- borrowedBook
        true
    | _ -> false

let returnBook title =
    match searchBook title with
    | Some book when book.Status = "Borrowed" ->
        let returnedBook = { book with Status = "Available"; BorrowDate = None }
        library.[title] <- returnedBook
        true
    | _ -> false

let displayBooks () =
    library |> Seq.map (fun kvp -> kvp.Value) |> Seq.toList
