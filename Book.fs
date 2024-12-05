module LibraryManagementSystemModule.Book

type Book = {
    Title: string
    Author: string
    Genre: string
    Status: string
    BorrowDate: System.DateTime option
}

