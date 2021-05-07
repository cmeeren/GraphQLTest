[<AutoOpen>]
module Domain


type EmailAddress = private EmailAddress of string


module EmailAddress =

  let value (EmailAddress x) = x
  
  let create (str: string) =
    if not <| str.Contains "@" then Error "Not a valid email"
    elif str.Length > 100 then Error "Must be < 100 characters"
    else Ok (EmailAddress str)


type User = {
  Id: int
  Name: string
  EmailAddress: EmailAddress
}



let users = [
  {
    Id = 1
    Name = "John Doe"
    EmailAddress = EmailAddress "john@doe.com"
  }
]




let findUser userId =
  users |> List.tryFind (fun u -> u.Id = userId)
