var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// ✅ Add a default endpoint for testing
app.MapGet("/", () => "API is running...");

// Your existing API group
var taxCalculatorGroup = app.MapGroup("/api");

// POST: /api/calcTax
taxCalculatorGroup.MapPost("/calcTax", () => Results.StatusCode(501))
    .WithName("CalcTax");

// GET: /api/reloadWorkflows
taxCalculatorGroup.MapGet("/reloadWorkflows", () => Results.StatusCode(501))
    .WithName("ReloadWorkflows");

app.Run();

