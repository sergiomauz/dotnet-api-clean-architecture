namespace Application.ErrorCatalog
{
    public static class ErrorConstants
    {
        // Not documented error
        public static string Generic00000 = "G00000";


        // CreateCourse
        public static ErrorTuple CreateCourseFormat00001 = new("CreateCourse-F00001", "name");
        public static ErrorTuple CreateCourseFormat00002 = new("CreateCourse-F00002", "name");
        public static ErrorTuple CreateCourseFormat00003 = new("CreateCourse-F00003", "teacher_id");
        public static ErrorTuple CreateCourseFormat00004 = new("CreateCourse-F00004", "teacher_id");
        public static ErrorTuple CreateCourseFormat00005 = new("CreateCourse-F00005", "code");
        public static ErrorTuple CreateCourseFormat00006 = new("CreateCourse-F00006", "code");
        public static ErrorTuple CreateCourseFormat00007 = new("CreateCourse-F00007", "description");
        public static ErrorTuple CreateCourseFormat00008 = new("CreateCourse-F00008", "description");

        public static ErrorTuple CreateCourseContent00001 = new("CreateCourse-C00001", "code");
        public static ErrorTuple CreateCourseContent00002 = new("CreateCourse-C00002", "teacher_id");


        // UpdateCourse
        public static ErrorTuple UpdateCourseContent00001 = new("UpdateCourse-C00001", "id");
        public static ErrorTuple UpdateCourseContent00002 = new("UpdateCourse-C00002", "code");
        public static ErrorTuple UpdateCourseContent00003 = new("UpdateCourse-C00003", "teacher_id");


        // GetCourseByCode
        public static ErrorTuple GetCourseByCodeContent00001 = new("GetCourseByCode-C00001", "code");


        // GetCourseById
        public static ErrorTuple GetCourseByIdContent00001 = new("GetCourseById-C00001", "id");


        // CreateEnrollment
        public static ErrorTuple CreateEnrollmentContent00001 = new("CreateEnrollment-C00001", "id");
        public static ErrorTuple CreateEnrollmentContent00002 = new("CreateEnrollment-C00002", "course_id");
        public static ErrorTuple CreateEnrollmentContent00003 = new("CreateEnrollment-C00003", "student_id");


        // CreateStudent
        public static ErrorTuple CreateStudentContent00001 = new("CreateStudent-C00001", "code");


        // UpdateStudent
        public static ErrorTuple UpdateStudentContent00001 = new("UpdateStudent-C00001", "id");
        public static ErrorTuple UpdateStudentContent00002 = new("UpdateStudent-C00002", "code");


        // GetCoursesByStudentId
        public static ErrorTuple GetCoursesByStudentIdContent00001 = new("GetCoursesByStudentId-C00001", "student_id");


        // GetStudentByCode
        public static ErrorTuple GetStudentByCodeContent00001 = new("GetStudentByCode-C00001", "code");


        // GetStudentById
        public static ErrorTuple GetStudentByIdContent00001 = new("GetStudentById-C00001", "id");


        // CreateTeacher
        public static ErrorTuple CreateTeacherContent00001 = new("CreateTeacher-C00001", "code");


        // UpdateTeacher
        public static ErrorTuple UpdateTeacherContent00001 = new("UpdateTeacher-C00001", "id");
        public static ErrorTuple UpdateTeacherContent00002 = new("UpdateTeacher-C00002", "code");


        // GetCoursesByTeacherId
        public static ErrorTuple GetCoursesByTeacherIdContent00001 = new("GetCoursesByTeacherId-C00001", "teacher_id");


        // GetStudentsByTeacherId
        public static ErrorTuple GetStudentsByTeacherIdContent00001 = new("GetStudentsByTeacherId-C00001", "teacher_id");


        // GetTeacherByCode
        public static ErrorTuple GetTeacherByCodeContent00001 = new("GetTeacherByCode-C00001", "code");


        // GetTeacherById
        public static ErrorTuple GetTeacherByIdContent00001 = new("GetTeacherById-C00001", "id");
    }
}
