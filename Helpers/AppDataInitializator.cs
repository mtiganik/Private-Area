using System;
using System.Linq;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Helpers
{
    public class AppDataInitializator
    {
        public static void InitializeAppDatabase(ApplicationDbContext context)
        {
            if (!context.ContactTypes.Any())
            {
                context.ContactTypes.Add(new ContactType()
                {
                    ContactTypeName = "Skype"
                });
                context.ContactTypes.Add(new ContactType()
                {
                    ContactTypeName = "Email"
                });
                context.ContactTypes.Add(new ContactType()
                {
                    ContactTypeName = "Telephone"
                });
                context.SaveChanges();
            }

            if (!context.CompanyFieldOfActivities.Any())
            {
                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity {
                    ActivityName = "Company",
                    ActivityNameEst = "Firma"
                });
                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity
                {
                    ActivityName = "VIP",
                    ActivityNameEst = "VIP"
                });
                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity
                {
                    ActivityName = "Hosting place",
                    ActivityNameEst = "Majutuskoht"
                });
                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity
                {
                    ActivityName = "Party place",
                    ActivityNameEst = "Peokoht"
                });
            }

            if (!context.CompanyTypes.Any())
            {
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = "IT",
                    CompanyTypeNameEst = "IT"
                });
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = "Construction",
                    CompanyTypeNameEst = "Ehitus"
                });
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = "Chemistry",
                    CompanyTypeNameEst = "Keemia"
                });
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = "Business",
                    CompanyTypeNameEst = "Majandus"
                });
            }


            if (!context.ProjectTypes.Any())
            {

                context.ProjectTypes.Add(new ProjectType
                {
                    ProjectTypeName = "Job Fair",
                    ProjectTypeNameEst = "Karjäärimess",
                    ProjectTypeComments = "Companies have their stalls and present themselves",
                    ProjectTypeCommentsEst = "Firmapäev, kus tudengid saavad firmadega tutvuda"
                });

                context.ProjectTypes.Add(new ProjectType
                {
                    ProjectTypeName = "Carreer Day",
                    ProjectTypeNameEst = "Firmapäev",
                    ProjectTypeComments = "Seminar where company worker gives a lecture",
                    ProjectTypeCommentsEst = "Firma esindaja tutvustab firma tegemisi"
                });

                context.ProjectTypes.Add(new ProjectType
                {
                    ProjectTypeName = "Summer Days",
                    ProjectTypeNameEst = "Suvepäevad",
                    ProjectTypeComments = "Annual organization Summerdays. If you havent been there, you haven't seen real life!",
                    ProjectTypeCommentsEst = "Iga aastane organisatsiooni suvepäevade üritus. Sa pole elu näinud, kui seal pole olnud"
                });

               
            }

            if (!context.UserStatuses.Any())
            {
                context.UserStatuses.Add(new UserStatus
                {
                    UserStatusName = "New member",
                    UserStatusNameEst = "Uus liige"
                });

                context.UserStatuses.Add(new UserStatus
                {
                    UserStatusName = "Baby member",
                    UserStatusNameEst = "Beebiliige"
                });

                context.UserStatuses.Add(new UserStatus
                {
                    UserStatusName = "Full member",
                    UserStatusNameEst = "Täisliige"
                });

                context.UserStatuses.Add(new UserStatus
                {
                    UserStatusName = "Ex-member",
                    UserStatusNameEst = "Eksliige"
                });
                context.UserStatuses.Add(new UserStatus
                {
                    UserStatusName = "Alumni",
                    UserStatusNameEst = "Alumni"
                });
            }

            if (!context.Specialities.Any())
            {
                context.Specialities.Add(new Speciality
                {
                    SpecialityName = "IT",
                    SpecialityNameEst = "IT"
                });
                context.Specialities.Add(new Speciality
                {
                    SpecialityName = "Engineering Physics",
                    SpecialityNameEst = "Tehniline Füüsika"
                });
                context.Specialities.Add(new Speciality
                {
                    SpecialityName = "Business Management",
                    SpecialityNameEst = "Avalik Haldus"
                });
                context.Specialities.Add(new Speciality
                {
                    SpecialityName = "Civil Engineering",
                    SpecialityNameEst = "Ehitus"
                });
                context.Specialities.Add(new Speciality
                {
                    SpecialityName = "Mechatronics",
                    SpecialityNameEst = "Mehhatroonika"
                });
                context.Specialities.Add(new Speciality
                {
                    SpecialityName = "Electronics",
                    SpecialityNameEst = "Elektroonika"
                });
            }

            if (!context.PositionNames.Any())
            {
                context.PositionNames.Add(new PositionName
                {
                    PositionNameEng = "Project manager",
                    PositionNameEst = "Projektijuht"
                });

                context.PositionNames.Add(new PositionName
                {
                    PositionNameEng = "IT Coordinator",
                    PositionNameEst = "IT koordinaator"
                });

                context.PositionNames.Add(new PositionName
                {
                    PositionNameEng = "Sales lead",
                    PositionNameEst = "Müügijuht"
                });

                context.PositionNames.Add(new PositionName
                {
                    PositionNameEng = "Marketer",
                    PositionNameEst = "Marketer"
                });

                context.PositionNames.Add(new PositionName
                {
                    PositionNameEng = "Organizer",
                    PositionNameEst = "Korraldaja"
                });

                context.PositionNames.Add(new PositionName
                {
                    PositionNameEng = "Food responsible",
                    PositionNameEst = "Toiduvastutaja"
                });
            }


        }
        private static readonly string[] Roles = new[]
        {
            "User",
            "Admin"
        };

        public static void InitializeIdentity(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }

            var userName = "admin@eesti.ee";
            var userPass = "Foobar.foobar1";

            if (userManager.FindByNameAsync(userName).Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName =  userName,
                    Email = userName
                };

                var res = userManager.CreateAsync(user, userPass).Result;
                if (res == IdentityResult.Success)
                {
                    foreach (var role in Roles)
                    {
                        userManager.AddToRoleAsync(user, role).Wait();
                    }
                }
            }
        }
    }
}
