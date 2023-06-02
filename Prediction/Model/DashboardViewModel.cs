namespace Prediction.Model
{
    public class DashboardViewModel
    {
        public List<StudentPerformanceFullModel> StudentPerformanceDetails { get; set; }

        public List<string> TableHeaders { get; set; }

        public IEnumerable<string> Semesters { get; set; }

        public IEnumerable<float> SemesterResults { get; set; }
    }
}
