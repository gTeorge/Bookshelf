module Domain
open FSharp.Data

[<Literal>]
let libraryPath = __SOURCE_DIRECTORY__ + """\res\library.csv"""

type Book = CsvProvider<libraryPath, HasHeaders=true>

let library = Book.Load libraryPath

let books = library.Rows