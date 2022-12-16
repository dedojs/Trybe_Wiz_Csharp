namespace SchoolQueries;

public class SchoolDatabase : ISchoolDatabase
{
    public Student[] Students { get; set; }
    public Project[] Projects { get; set; }
    public ProjectGrade[] ProjectGrades { get; set; }

    public Student[] GetStudentsByName(string name)
    {
        var studentsByName = Students.Where(s => s.Name == name);
        return studentsByName.ToArray();
    }

    public Student[] GetStudentsWithAverageGradeInProjectAbove(int gradeInput)
    {
        var result = 
            from grades in ProjectGrades
            where grades.Grades.Average() > gradeInput

            from student in Students
            where grades.StudentId == student.Id
            select student;

        return result.ToArray();
    }

    public Project[] GetProjectsWithMinimumGradeInProjectBelow(int gradeInput)
    {
        var result =
            from grades in ProjectGrades
            where grades.Grades.Min() < gradeInput

            from project in Projects
            where grades.ProjectId == project.Id
            select project;

        return result.ToArray();
    }

    public Student[] GetStudentsDoneProject(string projectName)
    {
        var result =
            from project in Projects
            where project.Name == projectName

            from projectId in ProjectGrades
            where project.Id == projectId.ProjectId

            from student in Students
            where student.Id == projectId.StudentId
            select student;

        return result.ToArray();
    }
}
