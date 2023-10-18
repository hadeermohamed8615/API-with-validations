namespace CUXamairnDemo.Models
{
    public static  class StudentBL
    {
       public static  List<Student> students = new List<Student>();
        static StudentBL()
        {
            students.Add(new Student() { Id=1,Name="Ali",Age=22,Address="Cairo"});
            students.Add(new Student() { Id=2,Name="Aya",Age=25,Address="Alex"});
            students.Add(new Student() { Id=3,Name="Ahmed",Age=22,Address="Cairo"});
            students.Add(new Student() { Id=4,Name="Alaa",Age=25,Address="Giza"});
        }
    }
}
