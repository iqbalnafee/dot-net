using gamestore.api.Entities;

List<Game> games = new() {
    new Game()
    {
        Id = 1,
        Name = "Call Of Duty",
        Genre = "Action",
        Price = 10.11M,
        ReleaseDate = new DateTime(2000,2,1),
        ImageUri = "https://www.placehold.co/100"

    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 3!");

app.Run();
