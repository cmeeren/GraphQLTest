module Program

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Startup

[<EntryPoint>]
let main args =
  Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(fun builder -> builder.UseStartup<Startup>() |> ignore)
    .Build()
    .Run()
  0
