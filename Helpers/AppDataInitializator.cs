using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Helpers
{
    public class AppDataInitializator
    {
        public static void InitializeAppDatabase(ApplicationDbContext context)
        {
            if (!context.CompanyWorkerPositions.Any())
            {
                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition
                {
                    PositionName = "HR",
                    PositionNameEst = "Personalijuht"
                });

                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition
                {
                    PositionName = "Board Member",
                    PositionNameEst = "juhatuse liige"
                });

                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition
                {
                    PositionName = "CEO",
                    PositionNameEst = "Juhatuse esimees"
                });

                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition
                {
                    PositionName = "Marketer",
                    PositionNameEst = "Müügiosakonna esindaja"
                });

                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition
                {
                    PositionName = "Secretary",
                    PositionNameEst = "Sekretär"
                });

                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition
                {
                    PositionName = "IT person",
                    PositionNameEst = "IT mees"
                });


            }

            if (!context.ContactTypes.Any())
            {
                context.ContactTypes.Add(new ContactType()
                {
                    ContactTypeName = new MultiLangString()
                    {
                        Value = "Skype",
                    }
                });

                context.ContactTypes.Add(new ContactType()
                {
                    ContactTypeName = new MultiLangString()
                    {
                        Value = "Email"
                    }
                });

                context.ContactTypes.Add(new ContactType()
                {
                    ContactTypeName = new MultiLangString()
                    {
                        Value = "Telephone",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Telephone"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Telefonivestlus"
                            }

                        }
                    }
                });

                context.ContactTypes.Add(new ContactType()
                {
                    ContactTypeName = new MultiLangString()
                    {
                        Value = "Meeting",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Meeting"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Kohtumine"
                            }

                        }
                    }
                });

            }

            if (!context.CompanyFieldOfActivities.Any())
            {
                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity()
                {
                    ActivityName = new MultiLangString()
                    {
                        Value = "Company",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Firma"
                            },
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Company"
                            }
                        }
                    }
                });

                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity()
                {
                    ActivityName = new MultiLangString()
                    {
                        Value = "VIP",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="et",
                                Value = "VIP"
                            },
                            new Translation()
                            {
                                Culture = "en",
                                Value = "VIP"
                            }
                        }
                    }
                });

                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity()
                {
                    ActivityName = new MultiLangString()
                    {
                        Value = "Hosting place",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Majutuskoht"
                            },
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Hosting place"
                            }
                        }
                    }
                });

                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity()
                {
                    ActivityName = new MultiLangString()
                    {
                        Value = "Party place",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Peokoht"
                            },
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Party place"
                            }
                        }
                    }
                });

                context.CompanyFieldOfActivities.Add(new CompanyFieldOfActivity()
                {
                    ActivityName = new MultiLangString()
                    {
                        Value = "Transport",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Transport"
                            },
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Transport"
                            }
                        }
                    }
                });

            }

            if (!context.CompanyTypes.Any())
            {
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = new MultiLangString()
                    {
                        Value = "IT",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "IT"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "IT"
                            }
                        }
                    }
                });

                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = new MultiLangString()
                    {
                        Value = "Chemistry",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Chemistry"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Keemia"
                            }
                        }
                    }
                });
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = new MultiLangString()
                    {
                        Value = "Construction",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Construction"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Ehitus"
                            }
                        }
                    }
                });
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = new MultiLangString()
                    {
                        Value = "Business",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Business"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Majandus"
                            }
                        }
                    }
                });
                context.CompanyTypes.Add(new CompanyType
                {
                    CompanyTypeName = new MultiLangString()
                    {
                        Value = "Company",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Company"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Firma"
                            }
                        }
                    }
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

                context.ProjectTypes.Add(new ProjectType
                {
                    ProjectTypeName = "Winter Days",
                    ProjectTypeNameEst = "Talvepäevad",
                    ProjectTypeComments = "Annual organization WinterDays. If you havent been there, you haven't seen real life!",
                    ProjectTypeCommentsEst = "Iga aastane organisatsiooni talvepäevade üritus. Sa pole elu näinud, kui seal pole olnud"
                });
                context.SaveChanges();


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
                    UserStatusNameEst = "Vilistlane"
                });
            }

            if (!context.Departments.Any())
            {
                context.Departments.Add(new Department
                {
                    DepartmentName = "IT Department",
                    DepartmentNameEst = "IT Teaduskond"
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Engineering Department",
                    DepartmentNameEst = "Inseneriteaduskond"
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Department of Science",
                    DepartmentNameEst = "Loodusteaduskond"
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Department of Economics",
                    DepartmentNameEst = "Majandusteaduskond"
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Estonian Marine Academics",
                    DepartmentNameEst = "Eesti mereakadeemia"
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


            if (!context.Projects.Any())
            {
                context.Projects.Add(new Project
                {
                    ProjectName = "Võti Tulevikku 2018",
                    ProjectStartDate = new DateTime(2018, 3, 23),
                    ProjectEndDate = new DateTime(2018, 3, 25),
                    ProjectNameEst = "Võti Tulevikku 2018",
                    ProjectType = context.ProjectTypes.Where(u => u.ProjectTypeName == "Job Fair").Single(),
                });

                context.Projects.Add(new Project
                {
                    ProjectName = "Summer Days 2018",
                    ProjectStartDate = new DateTime(2018, 7, 15),
                    ProjectEndDate = new DateTime(2018, 7, 16),
                    ProjectNameEst = "Suvepäevad 2018",
                    ProjectType = context.ProjectTypes.Where(u => u.ProjectTypeName == "Summer Days").Single(),
                });

                context.Projects.Add(new Project
                {
                    ProjectName = "Carreer Day 2017",
                    ProjectStartDate = new DateTime(2017, 11, 23),
                    ProjectEndDate = new DateTime(2017, 11, 24),
                    ProjectNameEst = "Firmapäevad 2017",
                    ProjectType = context.ProjectTypes.Where(u => u.ProjectTypeName == "Job Fair").Single(),
                });
                

            }
            context.SaveChanges();

        }
        private static readonly string[] Roles = new[]
        {
            "User",
            "Marketer",
            "Admin"
        };

        public static void InitializeIdentity(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            foreach (var role in Roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }

            var userName = "admin@eesti.ee";
            var userPass = "qwerty";

            if (!context.ApplicationUser.Any())
            {
                //var user0 = new ApplicationUser { UserName = userName, Email = userName };
                //var res = userManager.CreateAsync(user0, userPass).Result;
                //if (res == IdentityResult.Success)
                //{
                //    foreach (var role in Roles)
                //    {
                //        userManager.AddToRoleAsync(user0, role).Wait();
                //    }
                //}

                //var user1 = context.ApplicationUser.Where(u => u.UserName == "mtiganik@gmail.com").Single();
                var user1 = new ApplicationUser
                {
                    FirstName = "Mihkel",
                    LastName = "Tiganik",
                    Email = "mtiganik@gmail.com",
                    Address = "Sitsi 15-6, Tallinn",
                    Comments = "Like to Lead people",
                    Department = context.Departments.Where(u => u.DepartmentName == "IT Department").Single(),
                    Skype = "rohep2ike",
                    PhoneNumber = "55655828",
                    UserName = "mtiganik@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusName == "Full member").Single(),

                };
                var res1 = userManager.CreateAsync(user1, userPass).Result;
                if (res1 == IdentityResult.Success)
                {
                    foreach (var role in Roles)
                    {
                        userManager.AddToRoleAsync(user1, role).Wait();
                    }
                }

                var user2 = new ApplicationUser
                {
                    FirstName = "Liisa",
                    LastName = "Kern",
                    Email = "LiisaKern@gmail.com",
                    Address = "Retke tee 8, 2401 Tallinn",
                    Comments = "Motivated for marketing",
                    Department = context.Departments.Where(u => u.DepartmentName == "Department of Science").Single(),
                    Skype = "LiisaKern123",
                    PhoneNumber = "5284532",
                    UserName = "LiisaKern@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusName == "Baby member").Single(),

                };
                var res2 = userManager.CreateAsync(user2, userPass).Result;
                if (res2 == IdentityResult.Success)
                {
                    userManager.AddToRoleAsync(user2, Roles[0]).Wait();
                    userManager.AddToRoleAsync(user2, Roles[1]).Wait();
                }


                var user3 = new ApplicationUser
                {
                    FirstName = "Tiit",
                    LastName = "Kass",
                    Email = "tiitkass@gmail.com",
                    Address = "Lauresi tee 5",
                    Comments = "I'm good guitar player",
                    Department = context.Departments.Where(u => u.DepartmentName == "Department of Economics").Single(),
                    Skype = "tkass",
                    PhoneNumber = "55842974",
                    UserName = "tiitkass@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusName == "New member").Single(),

                };
                var res3 = userManager.CreateAsync(user3, userPass).Result;
                if (res3 == IdentityResult.Success)
                {
                    userManager.AddToRoleAsync(user3, Roles[0]).Wait();
                }

                var user4 = new ApplicationUser
                {
                    FirstName = "Andres",
                    LastName = "Kaver",
                    Email = "akaver@gmail.com",
                    Address = "Harjumaa",
                    Comments = "IT",
                    Department = context.Departments.Where(u => u.DepartmentName == "IT Department").Single(),
                    Skype = "akaver",
                    PhoneNumber = "65740213",
                    UserName = "akaver@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusName == "Alumni").Single(),

                };
                var res4 = userManager.CreateAsync(user4, userPass).Result;
                if (res4 == IdentityResult.Success)
                {
                    userManager.AddToRoleAsync(user4, Roles[0]).Wait();
                    userManager.AddToRoleAsync(user4, Roles[1]).Wait();
                }


            }
        }

        public static void InitializeComplexAppDatabase(ApplicationDbContext context)
        {
            if (!context.Positions.Any())
            {
                context.Positions.Add(new Position
                {
                    ProjectId = context.Projects.Single(u => u.ProjectName == "Võti Tulevikku 2018").ProjectId,
                    PositionNameId = context.PositionNames.Single(u => u.PositionNameEng == "Project manager").PositionNameId,
                    ApplicationUserId = context.ApplicationUser.Single(u => u.UserName == "mtiganik@gmail.com").Id,
                    IsMarketer = true,

                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Võti Tulevikku 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameEng == "Sales lead").Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "LiisaKern@gmail.com").Single(),
                    IsMarketer = true,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Võti Tulevikku 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameEng == "Organizer").Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "tiitkass@gmail.com").Single(),
                    IsMarketer = false,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Summer Days 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameEng == "Project manager").Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "mtiganik@gmail.com").Single(),
                    IsMarketer = false,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Summer Days 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameEng == "Food responsible").Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "akaver@gmail.com").Single(),
                    IsMarketer = false,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Carreer Day 2017").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameEng == "Project manager").Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "tiitkass@gmail.com").Single(),
                    IsMarketer = true,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Carreer Day 2017").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameEng == "Organizer").Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "mtiganik@gmail.com").Single(),
                    IsMarketer = true,
                });

                context.SaveChangesAsync().Wait();
            }
        }


    }

}
