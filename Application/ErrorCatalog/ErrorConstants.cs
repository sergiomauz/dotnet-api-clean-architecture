namespace Application.ErrorCatalog
{
    public static class ErrorConstants
    {
        // Not documented error
        public static string Generic00000 = "G00000";


        // Paginated
        public static ErrorTuple PaginatedFormat00001 = new("Paginated-F00001", "current_page");
        public static ErrorTuple PaginatedFormat00002 = new("Paginated-F00002", "page_size");


        // BasicSearch
        public static ErrorTuple BasicSearchFormat00001 = new("BasicSearch-F00001", "text_filter");


        // Code
        public static ErrorTuple CodeFormat00001 = new("Code-F00001", "code");


        // Ids
        public static ErrorTuple IdsFormat00001 = new("Ids-F00001", "id");
        public static ErrorTuple IdsFormat00002 = new("Ids-F00002", "id");
        public static ErrorTuple IdsFormat00003 = new("Ids-F00003", "id");
        public static ErrorTuple IdsFormat00004 = new("Ids-F00004", "ids");
        public static ErrorTuple IdsFormat00005 = new("Ids-F00005", "ids");
        public static ErrorTuple IdsFormat00006 = new("Ids-F00006", "ids");


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
        public static ErrorTuple GetCoursesByStudentIdFormat00001 = new("GetCoursesByStudentId-F00001", "student_id");
        public static ErrorTuple GetCoursesByStudentIdFormat00002 = new("GetCoursesByStudentId-F00002", "student_id");

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
        public static ErrorTuple GetCoursesByTeacherIdFormat00001 = new("GetCoursesByTeacherId-F00001", "teacher_id");
        public static ErrorTuple GetCoursesByTeacherIdFormat00002 = new("GetCoursesByTeacherId-F00002", "teacher_id");

        public static ErrorTuple GetCoursesByTeacherIdContent00001 = new("GetCoursesByTeacherId-C00001", "teacher_id");


        // GetStudentsByTeacherId
        public static ErrorTuple GetStudentsByTeacherIdFormat00001 = new("GetStudentsByTeacherId-F00001", "teacher_id");
        public static ErrorTuple GetStudentsByTeacherIdFormat00002 = new("GetStudentsByTeacherId-F00002", "teacher_id");

        public static ErrorTuple GetStudentsByTeacherIdContent00001 = new("GetStudentsByTeacherId-C00001", "teacher_id");


        // GetTeacherByCode
        public static ErrorTuple GetTeacherByCodeContent00001 = new("GetTeacherByCode-C00001", "code");


        // GetTeacherById
        public static ErrorTuple GetTeacherByIdContent00001 = new("GetTeacherById-C00001", "id");
    }
}
