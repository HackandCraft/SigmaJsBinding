module Utils

open System

let join (separator: string) (items: string seq) =  
    let data = items |> Seq.toArray 
    String.Join(separator, data)

let random data =
    let random = Random()
    data |> Seq.sortBy (fun _ -> random.Next())