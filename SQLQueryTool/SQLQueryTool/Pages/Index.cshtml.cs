using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace SQLQueryTool.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly string _connectionString;
        private readonly string _SqlQuery;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection");
            _SqlQuery = configuration["SqlQueries:SqlQuery"] ?? throw new ArgumentNullException("SqlQueries:SqlQuery");
        }

        public List<string> ColumnNames { get; private set; } = new();
        public List<Dictionary<string, string>> Records { get; private set; } = new();

        public void OnGet()
        {
            try
            {
                using (SqlConnection connection = new(_connectionString))
                {
                    connection.Open();

                    string message = $"Executing SQL query: {_SqlQuery}";
                    _logger.LogInformation(message);

                    using (SqlCommand command = new SqlCommand(_SqlQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Get column names
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            ColumnNames.Add(reader.GetName(i));
                        }

                        // Get records
                        while (reader.Read())
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
            }
            catch (Exception ex)
            {
                string message = $"Error executing SQL query: {ex.Message}";
                _logger.LogError(message);
                throw;
            }
        }
    }
}
