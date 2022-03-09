using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using testApp.Models;

namespace testApp.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db;

        public HomeController(DataBaseContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.groups.Include(u => u.Employees).Include(t => t.Teacher).ToList());
        }

        public IActionResult createGroup()
        {
            return View(db.teachers.ToList());
        }
        [HttpPost]
        public IActionResult createGroup(int teacherId, string groupName)
        {
            Group newGroup = new Group()
            {
                Name = groupName,
                Teacher = db.teachers.Find(teacherId)
            };
            db.groups.Add(newGroup);
            db.SaveChanges();

            return Redirect("~/Home/editGroup/" + newGroup.Id);
        }

        [HttpGet]
        public IActionResult editGroup(int id)
        {
            var gr = db.groups.Include(g => g.Teacher)
                              .Include(g => g.Employees)
                              .ThenInclude(o => o.Org)
                              .FirstOrDefault(g => g.Id == id);

            return View(gr);
        }
        [HttpPost]
        public IActionResult editGroup(int groupId, string newGroupName)
        {
            db.groups.Find(groupId).Name = newGroupName;
            db.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpGet]
        public IActionResult deleteStudent(int studentId, int groupId)
        {
            var employee = db.employees.Include(g => g.Groups)
                                       .FirstOrDefault(e => e.Id == studentId);
            var group = db.groups.Find(groupId);
            employee.Groups.Remove(group);
            db.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public IActionResult addStudent(int id)
        {
            var gp = db.groups.Include(g => g.Teacher)
                              .ThenInclude(o => o.Organizations)
                              .FirstOrDefault(g => g.Id == id);

            return View(gp);
        }
        [HttpPost]
        public IActionResult addStudent(int id, int empId)
        {
            Group ng = db.groups.Find(id);
            db.employees.Find(empId).Groups = new List<Group>();
            db.employees.Find(empId).Groups.Add(ng);
            db.SaveChanges();
            return Redirect("~/Home/editGroup/" + id);
        }
        public  IActionResult getEmployeesByOrgId(int orgId, int groupId)
        {
            List<Employee> exclude = new List<Employee>();
            var data = db.employees.Where(e => e.Org.Id == orgId).ToList();
            var tt = db.groups.Include(e => e.Employees)
                              .FirstOrDefault(g => g.Id == groupId).Employees;

            foreach (var o in tt)
                exclude.Add(o);

            return Json(data.Except(exclude));
        }
    }
}
