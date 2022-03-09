using System.Collections.Generic;
using System.Linq;
using testApp.Models;

namespace testApp
{
    public class SampleData
    {
        public static void Initialize(DataBaseContext context)
        {
            Organization ttb = new Organization
            {
                Name = "ТрансТелеБом",
                Tin = "545-100-854"
            };
            Organization hmc = new Organization
            {
                Name = "HruMuCorp",
                Tin = "8-800-555-35-35"
            };
            Organization bi = new Organization
            {
                Name = "BelkaInc",
                Tin = "975-842-187"
            };
            Organization khc = new Organization
            {
                Name = "KrotyHomyakiCorp",
                Tin = "111-111-111"
            };
            Organization fvi = new Organization
            {
                Name = "FilkaVstakaneInd",
                Tin = "975-842-187"
            };
            if (!context.organizations.Any())
            {
                context.organizations.AddRange(ttb, hmc, bi, khc, fvi);
            }
            if (!context.teachers.Any())
            {
                context.teachers.AddRange(
                    new Teacher
                    {
                        Name = "Петров П.П.",
                        Email = "petr@petrov",
                        Organizations = new List<Organization>() { ttb, hmc }
                    },
                    new Teacher
                    {
                        Name = "Иванов И.И.",
                        Email = "ivan@ivanov",
                        Organizations = new List<Organization>() { bi }
                    },
                    new Teacher
                    {
                        Name = "Сидоров С.С.",
                        Email = "sergey@sidorov",
                        Organizations = new List<Organization>() { khc, fvi }
                    }
                );
            }
            if (!context.employees.Any())
            {
                context.employees.AddRange(
                    new Employee
                    {
                        Name = "Лебедев В.К.",
                        Org = ttb
                    },
                    new Employee
                    {
                        Name = "Акимова В.Г.",
                        Org = ttb
                    },
                    new Employee
                    {
                        Name = "Осипов Г.М.",
                        Org = hmc
                    },
                    new Employee
                    {
                        Name = "Рыбаков К.Г.",
                        Org = hmc
                    },
                    new Employee
                    {
                        Name = "Соловьева Ю.Г.",
                        Org = khc
                    },
                    new Employee
                    {
                        Name = "Михеева М.Л.",
                        Org = fvi
                    },
                    new Employee
                    {
                        Name = "Белов Н.И.",
                        Org = bi
                    },
                    new Employee
                    {
                        Name = "Панкова С.И.",
                        Org = bi
                    }
                );
            }
            if (!context.courses.Any())
            {
                context.courses.AddRange(
                    new Course
                    {
                        Name = "Первый"
                    },
                    new Course
                    {
                        Name = "Второй"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
