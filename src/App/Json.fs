module Json

open Thoth.Json

let inline encode<'T>(state: 'T) = Encode.Auto.toString(0, state)

let inline decode<'T>(raw: string) = Decode.Auto.fromString<'T> raw