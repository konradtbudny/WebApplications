using System;
using System.Data.Entity.Migrations;
using Project02CarRentalWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Project02CarRentalWebApp.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Project02CarRentalWebApp.Models.CarRentalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarRentalDbContext context)
        {
            Guid guid1 = new Guid("1F941B15-1BF9-4793-83F1-A5B8523AB118");
            Guid guid2 = new Guid("B0FAC3A3-7955-4A91-B0B3-A666021D4026");
            Guid guid3 = new Guid("0CF1D643-8EB0-4723-8CDA-1856074176F5");
            Guid guid4 = new Guid("9c5f0c7f-9b3a-4038-b33b-63e09c83b48c");
            Guid guid5 = new Guid("fafcf97f-53dc-4aaf-91e8-4bf3a4641b8d");
            Guid guid6 = new Guid("0aedb9d6-c952-44da-9fc1-b77f84b1f959");
            Guid guid7 = new Guid("66a27867-c1cf-4d79-b42e-60139c09fc80");
            Guid guid8 = new Guid("ff0cd57c-9272-4cf2-a042-b412a202f3ad");
            Guid guid9 = new Guid("87b7e23e-d598-404c-87f5-7b28a30d1132");
            Guid guid10 = new Guid("c8ad59d2-c458-4edb-b3b7-11f02228bc8a");
            Guid guid11 = new Guid("3711051f-368c-407f-b460-06d01bf7ca17");
            Guid guid12 = new Guid("df763abb-28ad-434f-ac9f-ca3ebb47ca7c");
            Guid guid13 = new Guid("fdf07d93-404c-43a8-a6e6-d504b6f344c1");
            Guid guid14 = new Guid("5549bd44-ebfa-42c7-8dbe-a993a3a13208");
            Guid guid15 = new Guid("f72670b8-cb91-4b66-ae96-607037a67cb9");
            Guid guid16 = new Guid("fc165813-df4e-4bf4-acc6-c81972a043f1");
            Guid guid17 = new Guid("ddd6e3d2-b983-4897-8b4c-3279a10ad1ff");
            Guid guid18 = new Guid("ee0c3f49-a648-4476-a465-a9fc2c73da6a");
            Guid guid19 = new Guid("e102cdc1-44c5-4e51-91af-ee908fd37eb9");
            Guid guid20 = new Guid("c880d2ca-2a61-4327-bd07-ecdae0da3465");
            Guid guid21 = new Guid("4929a366-7568-4e49-aa98-21916a09d01d");
            Guid guid22 = new Guid("2433d378-5168-4ce1-9761-f0157824e1cd");
            Guid guid23 = new Guid("c2c6900a-c8a7-4a4b-aa65-79cd0317f9d1");
            Guid guid24 = new Guid("fa9cf83b-05a2-4fa0-b2ed-96838f0ebd29");
            Guid guid25 = new Guid("b13a28ab-1139-44c0-ac60-5e0975bec92d");
            Guid guid26 = new Guid("c3ad4234-106c-41cd-a482-a29c31f36623");
            Guid guid27 = new Guid("d72fa8ff-051c-4069-a245-b6aa58f397ec");
            Guid guid28 = new Guid("5c3fdf7b-533a-4489-b77e-a607cdd995a3");
            Guid guid29 = new Guid("11b372f9-92bb-46ff-b2d2-0ab4485c0086");
            Guid guid30 = new Guid("d1f440b9-4339-4539-8cb0-a52158ec4dfd");
            Guid guid31 = new Guid("6c3a1350-e7f9-485f-af0e-26ccce136e2b");
            Guid guid32 = new Guid("ceb8e1b9-ccbf-4efb-9a46-a711b34c0bbe");
            Guid guid33 = new Guid("1c555e69-aed3-4700-94a7-e16fb9515ab3");
            Guid guid34 = new Guid("a109e1c3-a6c6-49b4-88d1-d8b4370b6b7f");
            Guid guid35 = new Guid("1b64f867-2ce9-4c3c-ad6f-09038d160fbb");
            Guid guid36 = new Guid("ca84f809-f757-443a-8a15-b14f8d867970");
            Guid guid37 = new Guid("7ded2844-63e7-4627-b122-4788cea137f3");
            Guid guid38 = new Guid("18939c46-ed2a-4016-9e4b-c53d23253011");
            Address address1 = new Address { Id = guid1, CityName = "New York, NY", StreetName = "Pembina Highway", PhoneNumber = "891-783-749", ZipCode = "551 783", ImportanceLevel = ImportanceLevel.Regular, Email = "kbudny492@gmail.com" };
            Address address2 = new Address { Id = guid2, CityName = "Miami, FL", StreetName = "Donald Street", PhoneNumber = "573-624-942", ZipCode = "738 920", ImportanceLevel = ImportanceLevel.Critical, Email = "kbudny492@gmail.com" };
            Address address3 = new Address { Id = guid3, CityName = "Los Angeles, CA", StreetName = "Regent Avenue", PhoneNumber = "745-361-295", ZipCode = "930 829", ImportanceLevel = ImportanceLevel.VIP, Email = "kbudny492@gmail.com" };
            Address address4 = new Address { Id = guid4, CityName = "Chicago, IL", StreetName = "Fermor Avenue", PhoneNumber = "413-758-382", ZipCode = "592 739", ImportanceLevel = ImportanceLevel.Regular, Email = "kbudny492@gmail.com" };
            Address address5 = new Address { Id = guid5, CityName = "Bufflo, NY", StreetName = "Main Street", PhoneNumber = "554-954-785", ZipCode = "105 674", ImportanceLevel = ImportanceLevel.Critical, Email = "kbudny492@gmail.com" };
            Address address6 = new Address { Id = guid6, CityName = "Orlando, FL", StreetName = "Portage Avenue", PhoneNumber = "843-578-291", ZipCode = "246 964", ImportanceLevel = ImportanceLevel.VIP, Email = "kbudny492@gmail.com" };
            Address address7 = new Address { Id = guid7, CityName = "Atlanta, GA", StreetName = "Osborne Street", PhoneNumber = "483-195-643", ZipCode = "575 103", ImportanceLevel = ImportanceLevel.Regular, Email = "kbudny492@gmail.com" };
            Address address8 = new Address { Id = guid8, CityName = "Nashville, TN", StreetName = "5th Street", PhoneNumber = "612-019-169", ZipCode = "309 142", ImportanceLevel = ImportanceLevel.Critical, Email = "kbudny492@gmail.com" };
            Address address9 = new Address { Id = guid9, CityName = "Indianapolis, IN", StreetName = "University Crescent", PhoneNumber = "213-305-756", ZipCode = "745 102", ImportanceLevel = ImportanceLevel.VIP, Email = "kbudny492@gmail.com" };
            Address address10 = new Address { Id = guid10, CityName = "Kansas, MO", StreetName = "Ulanowska", PhoneNumber = "314-483-795", ZipCode = "901 384", ImportanceLevel = ImportanceLevel.Regular, Email = "kbudny492@gmail.com" };
            Address address11 = new Address { Id = guid11, CityName = "Warszawa", StreetName = "Gleboka", PhoneNumber = "501-518-811", ZipCode = "21943", ImportanceLevel = ImportanceLevel.Critical, Email = "kbudny492@gmail.com" };
            Address address12 = new Address { Id = guid12, CityName = "Krakow", StreetName = "Solidarnosci", PhoneNumber = "509-421-255", ZipCode = "46382", ImportanceLevel = ImportanceLevel.VIP, Email = "kbudny492@gmail.com" };
            Address address13 = new Address { Id = guid13, CityName = "Lublin", StreetName = "Krasnicka", PhoneNumber = "302-281-573", ZipCode = "52845", ImportanceLevel = ImportanceLevel.Regular, Email = "kbudny492@gmail.com" };
            Address address14 = new Address { Id = guid14, CityName = "Rzeszow", StreetName = "Zemborzycka", PhoneNumber = "728-472-674", ZipCode = "68291", ImportanceLevel = ImportanceLevel.Critical, Email = "kbudny492@gmail.com" };
            Address address15 = new Address { Id = guid15, CityName = "Bydgoszcz", StreetName = "Pawia", PhoneNumber = "693-472-193", ZipCode = "57282", ImportanceLevel = ImportanceLevel.VIP, Email = "kbudny492@gmail.com" };
            Address address16 = new Address { Id = guid16, CityName = "Bialystok", StreetName = "Odrodzenia", PhoneNumber = "583-839-100", ZipCode = "10384", ImportanceLevel = ImportanceLevel.Regular, Email = "kbudny492@gmail.com" };
            Address address17 = new Address { Id = guid17, CityName = "Torun", StreetName = "Niepodleglosci", PhoneNumber = "500-638-683", ZipCode = "81924", ImportanceLevel = ImportanceLevel.Critical, Email = "kbudny492@gmail.com" };
            Address address18 = new Address { Id = guid18, CityName = "Szczecin", StreetName = "Paderewskiego", PhoneNumber = "120-499-281", ZipCode = "91024", ImportanceLevel = ImportanceLevel.VIP, Email = "kbudny492@gmail.com" };
            Address address19 = new Address { Id = guid19, CityName = "Katowice", StreetName = "Hutnicza", PhoneNumber = "601-272-572", ZipCode = "42834", ImportanceLevel = ImportanceLevel.Regular, Email = "kbudny492@gmail.com" };
            Address address20 = new Address { Id = guid20, CityName = "Wroclaw", StreetName = "Jana Pawla II", PhoneNumber = "609-478-172", ZipCode = "72924", ImportanceLevel = ImportanceLevel.Critical, Email = "kbudny492@gmail.com" };
            context.Addresses.AddOrUpdate(a => a.Id, new Address[]{
                address1,
                address2,
                address3,
                address4,
                address5,
                address6,
                address7,
                address8,
                address9,
                address10,
                address11,
                address12,
                address13,
                address14,
                address15,
                address16,
                address17,
                address18,
                address19,
                address20,
            });
            Survey survey1 = new Survey { Id = guid21, Title = "Cars" };
            Survey survey2 = new Survey { Id = guid22, Title = "Phones" };
            Question question1 = new Question { Id = guid23, Text = "What type of car do you have?" };
            Question question2 = new Question { Id = guid24, Text = "What size is the engine?" };
            Question question3 = new Question { Id = guid25, Text = "What phone do you have?" };
            Question question4 = new Question { Id = guid26, Text = "What big is the screen?" };
            Answer answer1 = new Answer { Id = guid27, Text = "Sedan", Question = question1 };
            Answer answer2 = new Answer { Id = guid28, Text = "3000", Question = question2 };
            Answer answer3 = new Answer { Id = guid29, Text = "SUV" };
            Answer answer4 = new Answer { Id = guid30, Text = "<1.5" };
            Answer answer5 = new Answer { Id = guid31, Text = "1.5<...<3.5" };
            Answer answer6 = new Answer { Id = guid32, Text = "3.5<" };
            Answer answer7 = new Answer { Id = guid33, Text = "iPhone" };
            Answer answer8 = new Answer { Id = guid34, Text = "Samsung" };
            Answer answer9 = new Answer { Id = guid35, Text = "Huawei" };
            Answer answer10 = new Answer { Id = guid36, Text = "4 inches" };
            Answer answer11 = new Answer { Id = guid37, Text = "5 inches" };
            Answer answer12 = new Answer { Id = guid38, Text = "6 inches" };
            context.Surveys.AddOrUpdate(s => s.Id, survey1, survey2);
            context.Questions.AddOrUpdate(a => a.Id, question1, question2, question3, question4);
            context.Answers.AddOrUpdate(a => a.Id, answer1, answer2, answer3, answer4,
                answer5, answer6, answer7, answer8, answer9, answer10, answer11, answer12);
            context.SaveChanges();
            //wczytywanie obiektow z bazy danych bo z powodu bledow w AddOrUpdate nie sa one sledzone poprawnie
            survey1 = context.Surveys.Find(survey1.Id);
            survey2 = context.Surveys.Find(survey2.Id);
            question1 = context.Questions.Find(question1.Id);
            question2 = context.Questions.Find(question2.Id);
            question3 = context.Questions.Find(question3.Id);
            question4 = context.Questions.Find(question4.Id);
            answer1 = context.Answers.Find(answer1.Id);
            answer2 = context.Answers.Find(answer2.Id);
            answer3 = context.Answers.Find(answer3.Id);
            answer4 = context.Answers.Find(answer4.Id);
            answer5 = context.Answers.Find(answer5.Id);
            answer6 = context.Answers.Find(answer6.Id);
            answer7 = context.Answers.Find(answer7.Id);
            answer8 = context.Answers.Find(answer8.Id);
            answer9 = context.Answers.Find(answer9.Id);
            answer10 = context.Answers.Find(answer10.Id);
            answer11 = context.Answers.Find(answer11.Id);
            answer12 = context.Answers.Find(answer12.Id);
            question1.Survey = survey1;
            question2.Survey = survey1;
            question3.Survey = survey2;
            question4.Survey = survey2;
            answer1.Question = question1;
            answer2.Question = question1;
            answer3.Question = question1;
            answer4.Question = question2;
            answer5.Question = question2;
            answer6.Question = question2;
            answer7.Question = question3;
            answer8.Question = question3;
            answer9.Question = question3;
            answer10.Question = question4;
            answer11.Question = question4;
            answer12.Question = question4;
            context.SaveChanges();
            using (var applicationContext = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(applicationContext));
                if (!roleManager.RoleExists("Administrator"))
                {
                    var role = new IdentityRole();
                    role.Name = "Administrator";
                    roleManager.Create(role);
                }
                if (!roleManager.RoleExists("RegularUser"))
                {
                    var role = new IdentityRole();
                    role.Name = "RegularUser";
                    roleManager.Create(role);
                }
                var store = new UserStore<ApplicationUser>(applicationContext);
                var manager = new ApplicationUserManager(store);
                var user1Email = "a@a.pl";
                if (manager.FindByEmail(user1Email) == null)
                {
                    var user = new ApplicationUser() { Email = user1Email, UserName = user1Email };
                    manager.Create(user, "Password2@");
                    manager.AddToRole(user.Id, "Administrator");
                }
                var user2Email = "b@b.pl";
                if (manager.FindByEmail(user2Email) == null)
                {
                    var user2 = new ApplicationUser() { Email = user2Email, UserName = user2Email };
                    manager.Create(user2, "Password3#");
                    manager.AddToRole(user2.Id, "RegularUser");
                }
            }
        }
    }
}
