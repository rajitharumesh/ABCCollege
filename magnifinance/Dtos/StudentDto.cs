namespace magnifinance.Dtos
{
    public class StudentDto
    {
        public int ID { get; set; }
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CourseSubjectID { get; set; }
    }
}
