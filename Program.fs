open System
open System.Windows.Forms
open LibraryManagementSystemNamespace

[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    Application.Run(MainForm())
    0