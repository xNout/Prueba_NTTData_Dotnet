using PRUEBA.BACKEND.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddServices();

builder
    .Build()
    .UseServices()
    .Run();