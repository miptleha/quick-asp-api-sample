Idea and sample taken from metanit [tutorial](https://metanit.com/sharp/aspnet5/23.2.php) for Web API. Tried not to copy his code blindly.

Test project contains both server and client. Download sources, open in [Visual Studio](https://visualstudio.microsoft.com/vs/) and run.

## Server
* Visual Studio 2019 project from ASP.NET Core Web API template
* Simple get/post/put/delete handler
* Objects stored in localdb, used EF
* Model validation
* Logging (service.log file)

Warning: localdb is not working under IIS, use [shared instance](https://stackoverflow.com/a/66388986/2764727).

## Client
* Bootstrap layout
* Pure JS (Fetch API)

