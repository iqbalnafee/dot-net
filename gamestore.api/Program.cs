using gamestore.api.Entities;

const string getGameEndPoint = "GetGameEndPoint";
List<Game> games = new() {
    new Game()
    {
        Id = 1,
        Name = "Call Of Duty",
        Genre = "Action",
        Price = 10.11M,
        ReleaseDate = new DateTime(2000,2,1),
        ImageUri = "https://www.placehold.co/100"

    },
    new Game()
    {
        Id = 2,
        Name = "PUBG",
        Genre = "Action",
        Price = 2.11M,
        ReleaseDate = new DateTime(2017,9,10),
        ImageUri = "https://www.placehold.co/100"

    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (int id) =>
{
    Game? game = games.Find(g => g.Id == id);
    if (game is null) return Results.NotFound();
    return Results.Ok(game);
}).WithName(getGameEndPoint);

app.MapPost("/games", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);
    return Results.CreatedAtRoute(getGameEndPoint, new { id = game.Id }, game);
});

app.Run();
