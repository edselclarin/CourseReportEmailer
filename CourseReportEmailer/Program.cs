using CourseReportEmailer.Repository;
using CourseReportEmailer.Workers;
using System.Net;

try
{
    // Get the enrollment report.
    var cmd = new EnrollmentDetailReportCommand();
    var enrollments = cmd.Get();

    // Generate a spreadsheet.
    string filename = "EnrollmentDetailsReport.xlsx";
    var creator = new EnrollmentDetailReportSpreadsheetCreator();
    creator.Create(filename, enrollments);

    // Prompt the user.
    Console.Write("Enter email address to send to: ");
    string emailTo = Console.ReadLine();
    Console.Write("Enter sender email username: ");
    string emailFrom = Console.ReadLine();
    Console.Write("Enter sender email password: ");
    string password = Console.ReadLine();

    // Email the spreadsheet.
    var emailer = new EnrollmentDetailReportEmailSender();
    emailer.Send(filename, emailTo, new NetworkCredential(emailFrom, password));
}
catch (Exception ex)
{
    Console.WriteLine(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
}
