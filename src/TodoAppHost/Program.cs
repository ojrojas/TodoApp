var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
.WithImageTag("latest").WithPgAdmin(conf =>
{
    conf.WithImageTag("latest");
});

var seq = builder.AddSeq("seq");

var identitydb = postgres.AddDatabase("identitydb");
var tododb = postgres.AddDatabase("tododb");

var identityServer = builder.AddProject<Projects.Identity>("identity-server");

var todoResourceApi = builder.AddProject<Projects.Todo>("todo-resource-api");
todoResourceApi
.WithReference(tododb);

var TodoAppApp = builder.AddNpmApp("bolundertodo", "../Frontends/todoapp-web");
var IdentityWeb = builder.AddNpmApp("identity-web", "../Frontends/identity-web");

TodoAppApp
.WithHttpEndpoint(env: "PORT")
.WithExternalHttpEndpoints()
.PublishAsDockerFile();

IdentityWeb
.WithHttpEndpoint(env: "PORT")
.WithExternalHttpEndpoints()
.PublishAsDockerFile();


identityServer
.WithReference(identitydb)
.WithReference(todoResourceApi)
.WithReference(seq)
.WithReference(TodoAppApp)
.WithReference(IdentityWeb)
.WaitFor(postgres)
.WithExternalHttpEndpoints();

await builder.Build().RunAsync();
