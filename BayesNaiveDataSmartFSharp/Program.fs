open FSharp.Data

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let appTweets = CsvFile.Load("../../../Csv/appTweets.csv").Cache()
    let otherTweets = CsvFile.Load("../../../Csv/otherTweets.csv").Cache()
    printfn "Number of columns in app tweets file: %s" (appTweets.NumberOfColumns.ToString())
    printfn "Number of columns in other tweets file: %s" (otherTweets.ToString())
    let app = appTweets.Rows
                |> Seq.map(fun line ->
                    let array = Seq.filter(fun array -> array <> "") (line.[0].Split [|' '|])
                        
                    array)
    let other = otherTweets.Rows
                |> Seq.map(fun line ->
                    let array = line.[0].Split [|' '|]
                    array)

    
    printfn "Number of words in first tweet: %i" (app |> Seq.head |> Array.length )
    for tweet in (Seq.head app) do
        printfn "%s" tweet
    //        for word in tweet do
    //            printfn "%s" word
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code

let filterCsv (rows:seq<CsvRow>) =
    Seq.map(fun line -> Seq.filter(fun array -> array <> "") (line.[0].Split [|' '|]))