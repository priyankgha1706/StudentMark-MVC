using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students.Models
{
    public class StudentsModel
    {


        public List<StudentMarks> StudentList()
        {
            List<StudentMarks> studentList = new List<StudentMarks>();
            using (var entity = new Student_ReportEntities())
            {
                var dbdetails = entity.Student_Value.Where(x => x.Is_Deleted == false).ToList();
                if (dbdetails != null && dbdetails.Count > 0)
                {
                    foreach (var item in dbdetails)
                    {
                        StudentMarks NewStudent = new StudentMarks();
                        NewStudent.Std_Id = item.Std_Id;
                        NewStudent.Roll_No = item.Roll_No;
                        NewStudent.Name = item.Name;
                        NewStudent.Tamil = item.Tamil;
                        NewStudent.English = item.English;
                        NewStudent.Maths = item.Maths;
                        NewStudent.Science = item.Science;
                        NewStudent.Social = item.Social;
                        NewStudent.Total = item.Total;
                        NewStudent.Average = item.Average;
                        
                        studentList.Add(NewStudent);
                    }
                }
            }
            return studentList;
        }

        public StudentMarks GetStudentRecords(int? id)
        {
            StudentMarks edituser = null;
            if (id != null && id > 0)
            {
                edituser = new StudentMarks();
                using (var entity = new Student_ReportEntities())
                {
                    var dbdetails = entity.Student_Value.Where(x => x.Std_Id == id).SingleOrDefault();
                    if (dbdetails != null)
                    {
                        edituser.Std_Id = dbdetails.Std_Id;
                        edituser.Roll_No = dbdetails.Roll_No;
                        edituser.Name = dbdetails.Name;
                        edituser.Tamil = dbdetails.Tamil;
                        edituser.English = dbdetails.English;
                        edituser.Science = dbdetails.Science;
                        edituser.Social = dbdetails.Social;
                    }
                }
            }
            return edituser;
        }


        public bool SaveStudentRecords(StudentMarks studentDetail)

        {
            bool recordSaved = false;
            if (studentDetail != null)
            {
                using (
                    var entity = new Student_ReportEntities())
                {
                    bool isRecordExist = false;
                    Student_Value entityclass = null;
                    entityclass = entity.Student_Value.Where(x => x.Std_Id == studentDetail.Std_Id && !x.Is_Deleted).SingleOrDefault();
                    if (entityclass != null)
                    {
                        isRecordExist = true;
                    }
                    else
                    {
                        entityclass = new Student_Value();
                    }

                    entityclass.Roll_No = studentDetail.Roll_No;
                    entityclass.Name = studentDetail.Name;
                    entityclass.Tamil = studentDetail.Tamil;
                    entityclass.English = studentDetail.English;
                    entityclass.Science = studentDetail.Science;
                    entityclass.Social = studentDetail.Social;
                    entityclass.Maths = studentDetail.Maths;
                    entityclass.Total = studentDetail.Tamil + studentDetail.English + studentDetail.Maths+ studentDetail.Science + studentDetail.Social;
                    entityclass.Average = (entityclass.Total / 5);
                    entityclass.Update_Time_Stamp = DateTime.Now;
                    if (isRecordExist == false)
                    {
                        entityclass.Is_Deleted = false;
                        entityclass.Create_Time_Stamp = DateTime.Now;
                        entity.Student_Value.Add(entityclass);
                    }

                    entity.SaveChanges();

                    recordSaved = true;
                }
            }
            return recordSaved;
        }

        public bool Delete(int? id)
        
            {
            bool isSaved = false;
                if (id > 0)
                {
                    using (var entity = new Student_ReportEntities())
                    {
                       
                        var dbdetails = entity.Student_Value.Where(x => x.Std_Id == id && !x.Is_Deleted).SingleOrDefault();
                        if (dbdetails != null)

                        {
                            dbdetails.Is_Deleted = true;
                            dbdetails.Update_Time_Stamp = DateTime.Now;
                            entity.SaveChanges();
                            isSaved = true;
                        }

                    }
                }
            return isSaved;
            }
        }
    }


