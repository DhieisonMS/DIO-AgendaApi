# DIO-AgendaApi

## Packages
- [x] dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0
- [x] dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.0
- [x] dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
- [x] dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 7.0.0

## Task
- [x] create dbcontext
- [x] create entidade
- [x] dotnet-ef migrations add ""
- [x] dotnet-ef database update
- [ ] create controller
- [] fix Datetime =>

## Start application

```bash
dotnet watch run

```
## Start application SDK in docker

```bash
    docker-composer up
    dotnet watch run
```
## dotnet-ef in docker shell

```bash
    dotnet tool install --global dotnet-ef --version 6.*
    alias dotnet-ef="/root/.dotnet/tools/dotnet-ef
```