module LibraryManagementSystemModule.DisplayBooksForm

open System
open System.Windows.Forms
open System.Drawing
open LibraryManagementSystemModule.LibraryManagement

type DisplayBooksForm() as this =
    inherit Form(Text = "Display Books", Width = 800, Height = 600)

    let tableLayoutPanel = new TableLayoutPanel(Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(50))

    let displayButton = new Button(Text = "Display Books", Width = 150, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightCyan)
    let resultLabel = new Label(Text = "", Font = new Font("Arial", 12.0f), AutoSize = true)

    do
        this.BackColor <- Color.White
        this.Controls.Add(tableLayoutPanel)

        tableLayoutPanel.Controls.Add(displayButton, 0, 0)
        tableLayoutPanel.Controls.Add(resultLabel, 0, 1)

        displayButton.Click.Add(fun _ ->
            let books = displayBooks ()
            let bookList = books |> List.map (fun book -> sprintf "%s by %s (%s) - %s" book.Title book.Author book.Genre book.Status) |> String.concat "\n"
            resultLabel.Text <- bookList
        )

