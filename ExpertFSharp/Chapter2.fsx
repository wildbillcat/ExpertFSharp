#r "../packages/FSharp.Data.2.2.5/lib/net40/FSharp.data.dll"

open FSharp.Data

type Species = HtmlProvider<"https://en.wikipedia.org/wiki/The_world's_100_most_threatened_species">

let species = 
    [ for x in Species.GetSample().Tables.``Species list``.Rows ->
        x.Type, x.``Common name`` ]

let speciesSorted =
    species
        |> List.countBy fst
        |> List.sortByDescending snd

#r "../packages/Suave.1.1.0/lib/net40/Suave.dll"

open Suave
open Suave.Http
open Suave.Web

let html =
    [ yield "<html><body><ul>"
      for (category,count) in speciesSorted do
        yield sprintf "<li>Category <b>%s</b>: <b>%d</b></li>" category count
      yield "</ul></body></html>"]
    |> String.concat "\n"


startWebServer defaultConfig (Successful.OK html)
