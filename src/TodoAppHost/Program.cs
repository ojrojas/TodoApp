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
var MasterWeb = builder.AddNpmApp("master-web", "../Frontends/master-web");


TodoAppApp
.WithHttpEndpoint(env: "PORT")
.WithReference(seq)
.WaitFor(seq)
.WithExternalHttpEndpoints()
.PublishAsDockerFile();

MasterWeb
.WithHttpEndpoint(env: "PORT")
.WithExternalHttpEndpoints()
.PublishAsDockerFile();

IdentityWeb
.WithHttpEndpoint(env: "PORT")
.WithReference(seq)
.WaitFor(seq)
.WithExternalHttpEndpoints()
.PublishAsDockerFile();

identityServer
.WithReference(identitydb)
.WithReference(todoResourceApi)
.WithReference(seq)
.WithReference(MasterWeb)
.WithReference(TodoAppApp)
.WithReference(IdentityWeb)
.WaitFor(postgres)
.WaitFor(seq)
.WithExternalHttpEndpoints();

await builder.Build().RunAsync();
