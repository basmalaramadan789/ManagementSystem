module LibraryManagementSystemModule.SearchBookForm

open System
open System.Windows.Forms
open System.Drawing
open LibraryManagementSystemModule.LibraryManagement

type SearchBookForm() as this =
    inherit Form(Text = "Search Book", Width = 600, Height = 400)

    let tableLayoutPanel = new TableLayoutPanel(Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 3, Padding = new Padding(50))

    let titleLabel = new Label(Text = "Title:", Font = new Font("Arial", 12.0f), AutoSize = true)
    let titleTextBox = new TextBox(Width = 300, Font = new Font("Arial", 12.0f))

    let searchButton = new Button(Text = "Search Book", Width = 150, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightGreen)
    let resultLabel = new Label(Text = "", Font = new Font("Arial", 12.0f), AutoSize = true)

    do
        this.BackColor <- Color.White
        this.Controls.Add(tableLayoutPanel)

        tableLayoutPanel.Controls.Add(titleLabel, 0, 0)
        tableLayoutPanel.Controls.Add(titleTextBox, 1, 0)
        tableLayoutPanel.Controls.Add(searchButton, 1, 1)
        tableLayoutPanel.Controls.Add(resultLabel, 1, 2)

        searchButton.Click.Add(fun _ ->
            let title = titleTextBox.Text
            match searchBook title with
            | Some book -> resultLabel.Text <- sprintf "Book found: %s by %s (%s)" book.Title book.Author book.Genre
            | None -> resultLabel.Text <- "Book not found!"
        )
