using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacTest;
using AutofacTest.Services;

var builder = WebApplication.CreateBuilder(args);

// https://ithelp.ithome.com.tw/articles/10295773
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// RootScopeLifetime 是Singleton, CurrentScopeLifetime 是 scoped 
#region 使用Autofac RegisterModule 注入(scope)
builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterModule(new AutofacModuleRegister()));
#endregion

#region 使用Autofac singleton 注入
//builder.Host.ConfigureContainer<ContainerBuilder>(container => container.RegisterAssemblyTypes(typeof(Program).Assembly)
//.AsImplementedInterfaces()
//.SingleInstance());
#endregion

#region 自己建立Singleton 注入
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
