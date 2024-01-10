module ActivePatterns 

open System

let (|NullOrEmpty|NotNullOrEmpty|) (input: string) =
    if String.IsNullOrWhiteSpace input then
        NullOrEmpty
    else
        NotNullOrEmpty input