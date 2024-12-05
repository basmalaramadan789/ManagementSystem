module LibraryManagementSystemModule.ReturnBookForm

open System
open System.Windows.Forms
open System.Drawing
open LibraryManagementSystemModule.LibraryManagement

type ReturnBookForm() as this =
    inherit Form(Text = "Return Book", Width = 600, Height = 400)

    let tableLayoutPanel = new TableLayoutPanel(Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 3, Padding = new Padding(50))

    let titleLabel = new Label(Text = "Title:", Font = new Font("Arial", 12.0f), AutoSize = true)
    let titleTextBox = new TextBox(Width = 300, Font = new Font("Arial", 12.0f))

    let returnButton = new Button(Text = "Return Book", Width = 150, Height = 50, Font = new Font("Arial", 12.0f), BackColor = Color.LightYellow)
    let resultLabel = new Label(Text = "", Font = new Font("Arial", 12.0f), AutoSize = true)

    do
        this.BackColor <- Color.White
        this.Controls.Add(tableLayoutPanel)

        tableLayoutPanel.Controls.Add(titleLabel, 0, 0)
        tableLayoutPanel.Controls.Add(titleTextBox, 1, 0)
        tableLayoutPanel.Controls.Add(returnButton, 1, 1)
        tableLayoutPanel.Controls.Add(resultLabel, 1, 2)

        returnButton.Click.Add(fun _ ->
            let title = titleTextBox.Text
            if returnBook title then
                resultLabel.Text <- sprintf "Book '%s' returned successfully!" title
            else
                resultLabel.Text <- "Book is not borrowed!"
        )

