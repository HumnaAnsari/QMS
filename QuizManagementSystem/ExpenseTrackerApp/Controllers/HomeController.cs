using ExpenseTrackerApp.Models;

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ExpenseTrackerApp.Models.DAL;

namespace ExpenseTrackerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult AdminView()
        {
            return View();
        }

        public ActionResult AgentView()
        {
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult CreateQuestions()
        {
            return View();
        }
        public ActionResult CreateSubjects()
        {
            return View();
        }

        public ActionResult CreateQuiz()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult ViewQuiz()
        {
            return View();
        }
        public ActionResult AddUser(AddUserModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.addUser(model.UserName, model.FirstName, model.LastName, model.Password, model.Email, model.PhoneNumber, model.SecretQuestion, model.SecretAnswer, model.Role);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult AddSignUpUser(AddUserModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.addSignUpUser(model.UserName, model.FirstName, model.LastName, model.Password, model.Email, model.PhoneNumber, model.SecretQuestion, model.SecretAnswer, model.Role);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult EditUser(AddUserModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.editUser(model.UserId, model.UserName, model.FirstName, model.LastName, model.Password, model.Email, model.PhoneNumber, model.SecretQuestion, model.SecretAnswer, model.RoleName);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            //return null;
        }

        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult LeftPanel()
        {
            return PartialView("~/Views/Shared/_LeftPanel.cshtml");
        }
        public ActionResult Get_ExpenseDataType()
        {
            return null;
        }


        public ActionResult DeleteUser(int UserId)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var data = db.deleteUser(UserId);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult DeleteQuiz(int QuizId)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var data = db.deleteQuiz(QuizId);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult AssignQuiz(AssignQuizModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var data = db.assignQuizToAgent(model.QuizId, model.TeacherId, model.ExpireDate, model.Agents);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ActionResult AgentGridData(int uid)
        {
            try
            {
                List<getAgentGridData_Result> data = new List<getAgentGridData_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getAgentGridData(uid).ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult ListUsers()
        {
            try
            {
                List<getUserDetails_Result> data = new List<getUserDetails_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getUserDetails().ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult GetTestCategories()
        {
            try
            {
                List<getTestCategories_Result> data = new List<getTestCategories_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getTestCategories().ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult ListSubjects()
        {
            try
            {
                List<getSubjectsList_Result> data = new List<getSubjectsList_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getSubjectsList().ToList();

                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult AddSubject(AddSubjectModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.addSubject(model.SubjectName, model.Category, model.ActiveF);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult EditQuestion(AddQuestionModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.editQuestion(model.QuestionType,model.Category,model.Question,model.OptionA,model.OptionB,model.OptionC,model.OptionD,model.Answer,model.SerialNumber);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult EditQuiz(AddQuizModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.editQuiz(model.QuizName,model.TotalQuestions,model.TimeAllocated,model.PassingScore,model.Subjects,model.CatID,model.QuizID);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }


        public ActionResult EditSubject(AddSubjectModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.editSubject(model.SubjectName, model.Category, model.ActiveF, model.SubjectId);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult ListQuestions()
        {
            try
            {
                List<getQuestionList_Result> data = new List<getQuestionList_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getQuestionList().ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult AddQuestion(AddQuestionModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.addQuestion(model.QuestionType, model.Category, model.Question, model.OptionA, model.OptionB, model.OptionC, model.OptionD, model.Answer);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult DeleteQuestion(int QId)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var data = db.deleteQuestion(QId);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult GetSubjects(string catid)
        {
            try
            {
                int cid = Convert.ToInt32(catid);
                List<getSubjects_Result> data = new List<getSubjects_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getSubjects(cid).ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult GetAgents()
        {
            try
            {

                List<getAgents_Result> data = new List<getAgents_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getAgents().ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult ListQuiz()
        {
            try
            {
                List<getQuizList_Result> data = new List<getQuizList_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getQuizList().ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }
        public ActionResult ViewReport(int roleid, int userid)
        {
            try
            {
                List<viewReport_Result> list = new List<viewReport_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    list = db.viewReport(roleid, userid).ToList();
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }

        public ActionResult DeleteSubject(int SId)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var data = db.deleteSubject(SId);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception e)
            {

            }
            return null;
        }



        public ActionResult AddQuiz(AddQuizModel model)
        {
            try
            {
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    var result = db.addQuiz(model.QuizName, model.TotalQuestions, model.TimeAllocated, model.PassingScore, model.Subjects, model.CatID);
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public ActionResult GetSecretQuestion()
        {
            try
            {
                List<getSecretQuestions_Result> data = new List<getSecretQuestions_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {

                    data = db.getSecretQuestions().ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                return null;
            }
        }
        public ActionResult GetRoles()
        {
            try
            {
                List<getRoles_Result> data = new List<getRoles_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.getRoles().ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                return null;
            }
        }
        /*Sharoz New Work*/
        public ActionResult GetQuizData_Agent(int uid)
        {
            try
            {
                List<GetQuizData_Agent_Result> data = new List<GetQuizData_Agent_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.GetQuizData_Agent(uid).ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }
        public ActionResult Result(int QuizID)
        {
            try
            {
                ViewBag.QuizID = QuizID;
                var profileData = Session["UserProfile"] as UserProfileSessionData;
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    List<GetResults_Result> data = db.GetResults(profileData.User_ID, QuizID).ToList();
                    ViewBag.Status = data.FirstOrDefault().Status.ToString();
                    ViewBag.Marks = data.FirstOrDefault().Marks.ToString();
                    ViewBag.CompleteDate = data.FirstOrDefault().CompleteDate.ToString();
                    ViewBag.QuestionCount = data.FirstOrDefault().QuestionCount.ToString();
                    ViewBag.CorrectAnswer = data.FirstOrDefault().CorrectAnswers.ToString();
                    ViewBag.WrongAnswer = data.FirstOrDefault().WrongAnswers.ToString();
                    ViewBag.QuizName = data.FirstOrDefault().QuizName.ToString();
                }

                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveAnswers(List<result_obj> result_obj)
        {
            try
            {
                var profileData = Session["UserProfile"] as UserProfileSessionData;
                int result = 0;
                foreach (var item in result_obj)
                {
                    using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                    {
                        result = db.InsertAnswers(profileData.User_ID, item.quizid, item.questionnumber, item.answer, item.isCorrect, item.questionid);
                    }
                }
                if (result == 1)
                {
                    using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                    {
                        result = db.UpdateMarks(result_obj.FirstOrDefault().quizid, profileData.User_ID);
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult GetCompleteResult(int uid, int qid)
        {
            try
            {
                List<GetResultsGrid_Data_Result> data = new List<GetResultsGrid_Data_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.GetResultsGrid_Data(uid, qid).ToList();
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                return null;
            }
        }

        public ActionResult GetQuizQuestions(int UserId, int QuizID, int TimeAllocated)
        {
            var obj = this.DeserializeObject<QuizModel>("QuizModel");
            ViewBag.TimeAllocated = TimeAllocated.ToString();
            try
            {
                List<GetQuizQuestions_Result> data = new List<GetQuizQuestions_Result>();
                using (DBONLINETESTEntities db = new DBONLINETESTEntities())
                {
                    data = db.GetQuizQuestions(UserId, QuizID).ToList();
                }

                List<QuestionsModel> list = new List<QuestionsModel>();
                for (int i = 0; i < data.Count(); i++)
                {
                    QuestionsModel ques = new QuestionsModel();
                    ques.Answer = data[i].Answer.ToString();
                    ques.ChoiceType = data[i].ChoiceType.ToString();
                    ques.Option1 = data[i].Option1.ToString();
                    ques.Option2 = data[i].Option2.ToString();
                    ques.Option3 = data[i].Option3.ToString();
                    ques.Option4 = data[i].Option4.ToString();
                    ques.Question = data[i].Question.ToString();
                    ques.QuestionID = Convert.ToInt32(data[i].QuestionID.ToString());
                    ques.QuizID = Convert.ToInt32(data[i].QuizID.ToString());
                    ques.SubjectID = Convert.ToInt32(data[i].SubjectID.ToString());
                    ques.SubjectName = data[i].SubjectName.ToString();
                    list.Add(ques);
                }

                return View("Quiz", list);
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
            }

            return null;

        }
        //public ActionResult Quiz(QuizModel Model)
        //{
        //    try
        //    {


        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return null;
        //}
        /*Sharoz New Work*/


    }
}