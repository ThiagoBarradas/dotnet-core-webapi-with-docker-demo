# DotNetCore.WebApi.Docker.Demo

[ASP.NET Core](https://www.microsoft.com/net/core "ASP.NET Core") Web API Demo with [Docker](https://docs.docker.com/ "Docker"), [Nancy](http://nancyfx.org/ "Nancy") and [Kestrel](https://github.com/aspnet/KestrelHttpServer "Kestrel").

# How to run project? 

Running with docker (your terminal must be in same directory that the DockerFile):

```
docker build -t dotnetapidemo . --no-cache
docker run -t -p 1234:5000 dotnetapidemo
```

First line builds app and sets image name to *dotnetapidemo* (you can change). The next line run app in a container exposing your port 5000 in port 1234 (you can change too).

To check if app is running, access `http://localhost:1234/test`. You should see something like:

```
{"message":"This is a simple test"}
```

# Build Status

[![Build status](https://ci.appveyor.com/api/projects/status/4wrul3qj9iyv0pwh?svg=true)](https://ci.appveyor.com/project/ThiagoBarradas/dotnetcore-webapi-docker-demo)

# Author

[Thiago Barradas](https://www.linkedin.com/in/thiagobarradas "Linkedin")
