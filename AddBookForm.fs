module LibraryManagementSystemModule.AddBookForm

open System
open System.Windows.Forms
open System.Drawing
open LibraryManagementSystemModule.LibraryManagement

type AddBookForm() as this =
    inherit Form(Text = "Add Book", Width = 600, Height = 400)

    let tableLayoutPanel = new TableLayoutPanel(Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 4, Padding = new Padding(50))

    let titleLabel = new Label(Text = "Title:", Font = new Font("Arial", 12.0f), AutoSize = true)
    let titleTextBox = new TextBox(Width = 300, Font = new Font("Arial", 12.0f))

    let authorLabel = new Label(Text = "Author:", Font = new Font("Arial", 12.0f), AutoSize = true)
    let authorTextBox = new TextBox(Width = 300, Font = new Font("Arial", 12.0f))

    let genreLabel = new Label(Text = "Genre:", Font = new Font("Arial", 12.0f), AutoSize = true)
    let genreTextBox = new TextBox(Width = 300, Font = new Font("Arial", 12.0f))

    let addButton = new Button(Text = "Add Book", Width = 150, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightBlue)
    let resultLabel = new Label(Text = "", Font = new Font("Arial", 12.0f), AutoSize = true)

    do
        this.BackColor <- Color.White
        this.Controls.Add(tableLayoutPanel)

        tableLayoutPanel.Controls.Add(titleLabel, 0, 0)
        tableLayoutPanel.Controls.Add(titleTextBox, 1, 0)
        tableLayoutPanel.Controls.Add(authorLabel, 0, 1)
        tableLayoutPanel.Controls.Add(authorTextBox, 1, 1)
        tableLayoutPanel.Controls.Add(genreLabel, 0, 2)
        tableLayoutPanel.Controls.Add(genreTextBox, 1, 2)
        tableLayoutPanel.Controls.Add(addButton, 1, 3)
        tableLayoutPanel.Controls.Add(resultLabel, 1, 4)

        addButton.Click.Add(fun _ ->
            let title = titleTextBox.Text
            let author = authorTextBox.Text
            let genre = genreTextBox.Text
            if String.IsNullOrEmpty(title) || String.IsNullOrEmpty(author) || String.IsNullOrEmpty(genre) || title.Trim() = "" || author.Trim() = "" || genre.Trim() = "" then
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
            else
                addBook title author genre
                resultLabel.Text <- sprintf "Book '%s' added successfully!" title
        )