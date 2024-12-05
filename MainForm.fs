namespace LibraryManagementSystemNamespace

open System.Windows.Forms
open System.Drawing
open LibraryManagementSystemModule.AddBookForm
open LibraryManagementSystemModule.SearchBookForm
open LibraryManagementSystemModule.BorrowBookForm
open LibraryManagementSystemModule.ReturnBookForm
open LibraryManagementSystemModule.DisplayBooksForm

type MainForm() as this =
    inherit Form(Text = "Library Management System", Width = 800, Height = 600)

    let flowLayoutPanel = new FlowLayoutPanel(Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(50))

    let addButton = new Button(Text = "Add Book", Width = 200, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightBlue)
    let searchButton = new Button(Text = "Search Book", Width = 200, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightGreen)
    let borrowButton = new Button(Text = "Borrow Book", Width = 200, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightCoral)
    let returnButton = new Button(Text = "Return Book", Width = 200, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightYellow)
    let displayButton = new Button(Text = "Display Books", Width = 200, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightCyan)

    do
        this.BackColor <- Color.White
        this.Controls.Add(flowLayoutPanel)

        flowLayoutPanel.Controls.Add(addButton)
        flowLayoutPanel.Controls.Add(searchButton)
        flowLayoutPanel.Controls.Add(borrowButton)
        flowLayoutPanel.Controls.Add(returnButton)
        flowLayoutPanel.Controls.Add(displayButton)

        addButton.Click.Add(fun _ ->
            let addBookForm = new AddBookForm()
            addBookForm.ShowDialog() |> ignore
        )

        searchButton.Click.Add(fun _ ->
            let searchBookForm = new SearchBookForm()
            searchBookForm.ShowDialog() |> ignore
        )

        borrowButton.Click.Add(fun _ ->
            let borrowBookForm = new BorrowBookForm()
            borrowBookForm.ShowDialog() |> ignore
        )

        returnButton.Click.Add(fun _ ->
            let returnBookForm = new ReturnBookForm()
            returnBookForm.ShowDialog() |> ignore
        )

        displayButton.Click.Add(fun _ ->
            let displayBooksForm = new DisplayBooksForm()
            displayBooksForm.ShowDialog() |> ignore
        )