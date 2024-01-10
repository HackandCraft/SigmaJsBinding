module Views.TagsInput 

open Feliz.Bulma

let element2 (countries: string list) (onChanged: string list -> unit) = 
    Feliz.Bulma.TagsInput.input [
        tagsInput.tagProperties [
            tag.isLarge
            color.isSuccess
        ]
        tagsInput.onTagsChanged onChanged
        tagsInput.placeholder "Click on me to see async loading"
        tagsInput.autoCompleteSource (
            (fun query ->
                async {
                    do! Async.Sleep 1000
                    return countries |> List.filter (fun country -> country.Contains query)
                }
            )
        )
    ]
