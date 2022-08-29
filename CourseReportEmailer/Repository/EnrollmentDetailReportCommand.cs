using CourseReportEmailer.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CourseReportEmailer.Repository
{
    internal class EnrollmentDetailReportCommand
    {
        private string _connStr;

        public EnrollmentDetailReportCommand()
        {
            _connStr = @"Data Source=ITALY\SQLEXPRESS;Initial Catalog=CourseReport;TrustServerCertificate=True;Integrated Security=True";
        }

        public IList<EnrollmentDetailReport> Get()
        {
            var list = new List<EnrollmentDetailReport>();

            using (var conn = new SqlConnection(_connStr))
            {
                var sql = "EnrollmentReport_Get";
                list = conn.Query<EnrollmentDetailReport>(sql).ToList();
            }

            return list;
        }
    }
}
