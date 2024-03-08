using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacTest;
using AutofacTest.Services;

var builder = WebApplication.CreateBuilder(args);

// https://ithelp.ithome.com.tw/articles/10295773
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// RootScopeLifetime �OSingleton, CurrentScopeLifetime �O scoped 
#region �ϥ�Autofac RegisterModule �`�J(scope)
builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterModule(new AutofacModuleRegister()));
#endregion

#region �ϥ�Autofac singleton �`�J
//builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterAssemblyTypes(typeof(Program).Assembly)
//.AsImplementedInterfaces()
//.SingleInstance());
#endregion

#region �ۤv�إ�Singleton �`�J
//builder.Services.AddSingleton<IEncryptService, EncryptService>();
//builder.Services.AddSingleton<ILogService, LogService>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
