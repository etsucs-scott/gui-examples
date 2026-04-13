var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var p1 = new Person("Chandler", 30);
var p2 = new Person("Lilly", 24);

var people = new List<Person>()
{
    p1, p2
};

app.UseStaticFiles();

app.MapGet("/", () => Results.Redirect("/index.html"))

app.MapGet("/person", (string name) =>
{
    var person = people.FirstOrDefault(p =>
        p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    return person is null
        ? Results.NotFound($"No person found with name '{name}'.")
        : Results.Json(person);
});

app.Run();

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = -1;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
