[<AutoOpen>]
module Utils


module Result =


  let valueOrFail = function
    | Ok x -> x
    | Error errMsg -> failwith errMsg
