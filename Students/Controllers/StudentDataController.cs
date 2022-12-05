using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students.Controllers
{
    public class StudentDataController : Controller
    {
        #region Declaration
        private StudentsModel student = new StudentsModel();
        #endregion

        #region GetStudentList
        public ActionResult GetStudentList()
        {
        
            List<StudentMarks> List = new List<StudentMarks>();
            List = student.StudentList();
            return View(List);
        }

        #endregion



        #region 
        public ActionResult GetStudentRecords(int? id)
        {
            StudentMarks edituser = new StudentMarks();
            edituser = student.GetStudentRecords(id);

            return View(edituser);
        }

        [HttpPost]
        public ActionResult SaveStudentRecords(StudentMarks studentDetail)
        {
            bool isRecordSaved = student.SaveStudentRecords(studentDetail);
            if (isRecordSaved)
            {
                return RedirectToAction("GetStudentList");
            }
            return View();

        }
        #endregion

        #region

        public ActionResult Delete(int? id)
        {
            bool isRecordDeleted = student.Delete(id);
            return RedirectToAction("GetStudentList");
            
        }
    }
}
#endregion











