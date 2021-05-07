module Startup

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection

type Startup() =

  member __.ConfigureServices(services: IServiceCollection) : unit =
    services
      .AddGraphQLServer()
      .AddQueryType<Schema.Query>()
      .BindRuntimeType<EmailAddress, Schema.EmailAddressType>()
      .AddTypeConverter<EmailAddress, string>(fun x -> EmailAddress.value x)
      .AddTypeConverter<string, EmailAddress>(fun x -> x |> EmailAddress.create |> Result.valueOrFail)
    |> ignore

  member __.Configure(app: IApplicationBuilder) : unit =
    app
      .UseRouting()
      .UseEndpoints(fun ep -> ep.MapGraphQL() |> ignore)
    |> ignore
