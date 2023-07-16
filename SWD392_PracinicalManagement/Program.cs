var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddSession();
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapRazorPages();
app.Run();
