open Giraffe.ViewEngine
open Domain

type Book = {Name: string; Publisher: string; Formats: string list}

let myBooks =
    [
        { Name = "1,000 Ideas by 100 Manga Artists"; Publisher = "The Quarto Group"; Formats = ["MOBI"; "EPUB"; "PDF"] };
        { Name = "1,000 Ideas by 100 Manga Artists"; Publisher = "The Quarto Group"; Formats = ["MOBI"; "EPUB"; "PDF"] }
    ]

let model = 
  html [] [
    body [] [
      h1 [] [ Text "My Library" ]
      ul [] [
        for book in myBooks do
          li [] [
            div [] [ Text $"{book.Name}" ]
            div [] [ Text $"{book.Publisher}" ]  
            div [] [ Text $"{book.Formats}" ]
          ]
      ]
      p [] [ Text $"{Seq.head books}"]
    ]
  ]

model
|> RenderView.AsString.htmlNode
|> fun code -> System.IO.File.WriteAllText("./index.html", code)