using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace SQLQueryTool.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly string _connectionString;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection");
        }

        [BindProperty]
        public string SqlQuery { get; set; }

        public List<string> ColumnNames { get; private set; } = new();
        public List<Dictionary<string, string>> Records { get; private set; } = new();
        public string ErrorMessage { get; private set; }

        public void OnGet()
        {
            // No need to execute query on GET request
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(SqlQuery))
            {
                ModelState.AddModelError(string.Empty, "SQL Query cannot be empty.");
                return Page();
            }

            try
            {
                await ExecuteQueryAsync(SqlQuery);
            }
            catch (Exception ex)
            {
                string message = $"Error executing SQL query: {ex.Message}";
                _logger.LogError(message);
                ErrorMessage = message;
            }

            return Page();
        }


        private async Task ExecuteQueryAsync(string sqlQuery)
        {
            ColumnNames.Clear();
            Records.Clear();

            await using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                _logger.LogInformation("Database connection opened.");

                await using (SqlCommand command = new(sqlQuery, connection))
                {
                    // Log the SQL query being executed
                    _logger.LogInformation("Executing SQL query: {Query}", sqlQuery);

                    // Start the stopwatch to measure execution time
                    var stopwatch = Stopwatch.StartNew();

                    try
                    {
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            // Log query execution success
                            _logger.LogInformation("SQL query executed successfully.");

                            // Get column names
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                ColumnNames.Add(reader.GetName(i));
                            }

                            // Get records
                            while (await reader.ReadAsync())
                            {
                                var record = new Dictionary<string, string>();
                                foreach (var columnName in ColumnNames)
                                {
                                    record[columnName] = reader[columnName]?.ToString() ?? string.Empty;
                                }
                                Records.Add(record);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log any exceptions that occur during query execution
                        _logger.LogError(ex, "Error executing SQL query.");
                        throw; // Re-throw the exception to be handled by the calling method
                    }
                    finally
                    {
                        // Stop the stopwatch and log the elapsed time
                        stopwatch.Stop();
                        _logger.LogInformation("Query executed in {ElapsedMilliseconds} ms", stopwatch.ElapsedMilliseconds);
                    }
                }
            }
        }

    }
}
