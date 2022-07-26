using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Project02CarRentalWebApp.Models;

namespace Project02CarRentalWebApp.Controllers
{
    public class SurveyController : Controller
    {
        private CarRentalDbContext db = new CarRentalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fill(Guid id, Guid addressId)
        {
            if (id == null || addressId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            Address address = db.Addresses.Find(addressId);
            if (survey == null || address == null)
            {
                return HttpNotFound();
            }
            survey.Questions.SelectMany(q => q.Answers).Intersect(address.Answers, AnswerComparer.Instance).ToList().ForEach(answer => answer.IsChecked = true);
            foreach (var question in survey.Questions)
            {
                question.Answers = question.Answers.OrderBy(o => o.Text).ToList();
            }
            var surveyFillViewModel = new SurveyFillViewModel { Survey = survey, Address = address };

            return View(surveyFillViewModel);
        }
        public String CheckAnswer(String addressId, String answerId)
        {
            if (addressId == null || answerId == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Guid addressIdGuid, newAnswerIdGuid;
            try
            {
                addressIdGuid = Guid.Parse(addressId);
                newAnswerIdGuid = Guid.Parse(answerId);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(addressIdGuid);
            Answer newAnswer = db.Answers.Find(newAnswerIdGuid);
            if (address == null || newAnswer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var result = "false";

            Answer previousAnswer = address.Answers.Find(a => a.Question.Id == newAnswer.Question.Id);
            if (previousAnswer != null && previousAnswer.Id == newAnswer.Id)
            {
                result = "true";
            }
            return result;
        }
        public void SaveAnswer(String addressId, String answerId)
        {
            if (addressId == null || answerId == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Guid addressIdGuid, answerIdGuid;
            try
            {
                addressIdGuid = Guid.Parse(addressId);
                answerIdGuid = Guid.Parse(answerId);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(addressIdGuid);
            Answer answer = db.Answers.Find(answerIdGuid);
            if (address == null || answer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Answer previousAnswer = address.Answers.Find(a => a.Question.Id == answer.Question.Id);
            if (previousAnswer != null)
            {
                address.Answers.RemoveAll(a => a.Id == previousAnswer.Id);
            }
            address.Answers.Add(answer);
            db.SaveChanges();
        }

    }
}
