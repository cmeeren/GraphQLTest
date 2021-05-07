module Schema

open HotChocolate
open HotChocolate.Types
open HotChocolate.Language


type EmailAddressType () =
  inherit ScalarType<EmailAddress, StringValueNode>(NameString "EmailAddress")

  override _.IsInstanceOfType(s: StringValueNode) =
    match EmailAddress.create s.Value with
    | Ok _ -> true
    | Error _ -> false

  override _.IsInstanceOfType(_: EmailAddress) = true

  override _.ParseLiteral(x: StringValueNode) =
    match EmailAddress.create x.Value with
    | Ok x -> x
    | Error errMsg -> failwith errMsg

  override _.ParseValue(x: EmailAddress) =
    StringValueNode(EmailAddress.value x)

  override this.ParseResult(x: obj) =
    this.ParseValue(x)

  override _.Serialize(x: obj) =
    x |> unbox<EmailAddress> |> EmailAddress.value |> box




[<AllowNullLiteral>]
type UserType(u: User) =
  member _.Id = u.Id

  [<GraphQLNonNullType>]
  member _.Name = u.Name

  [<GraphQLNonNullType>]
  member _.EmailAddress = u.EmailAddress



type Query () =
  member _.User(id: int) =
    findUser id |> Option.map UserType |> Option.toObj
