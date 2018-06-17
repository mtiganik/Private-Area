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
                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition()
                {
                    PositionName = new MultiLangString()
                    {
                        Value = "HR",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "HR"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Personalijuht"
                            }

                        }
                    }
                });

                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition()
                {
                    PositionName = new MultiLangString()
                    {
                        Value = "Board Member",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Board Member"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "juhatuse liige"
                            }

                        }
                    }
                });
                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition()
                {
                    PositionName = new MultiLangString()
                    {
                        Value = "CEO",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "CEO"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Juhatuse esimees"
                            }

                        }
                    }
                });
                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition()
                {
                    PositionName = new MultiLangString()
                    {
                        Value = "Marketer",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Marketer"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Müügiosakonna esindaja"
                            }

                        }
                    }
                });
                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition()
                {
                    PositionName = new MultiLangString()
                    {
                        Value = "Secretary",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Secretary"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "Sekretär"
                            }

                        }
                    }
                });
                context.CompanyWorkerPositions.Add(new CompanyWorkerPosition()
                {
                    PositionName = new MultiLangString()
                    {
                        Value = "IT person",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "IT person"
                            },
                            new Translation()
                            {
                                Culture ="et",
                                Value = "IT mees"
                            }

                        }
                    }
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
                    ProjectTypeName = "Karjäärimess",
                    ProjectTypeComments = new MultiLangString()
                    {
                        Value = "Companies have their stalls and present themselves",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Companies have their stalls and present themselves"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Firmapäev, kus tudengid saavad firmadega tutvuda"
                            }
                        }
                    }
                });

                context.ProjectTypes.Add(new ProjectType
                {
                    ProjectTypeName = "Firmapäev",
                    ProjectTypeComments = new MultiLangString()
                    {
                        Value = "Seminar where company worker gives a lecture",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Seminar where company worker gives a lecture"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Firma esindaja tutvustab firma tegemisi"
                            }
                        }
                    }
                });
                context.ProjectTypes.Add(new ProjectType
                {
                    ProjectTypeName = "Suvepäevad",
                    ProjectTypeComments = new MultiLangString()
                    {
                        Value = "Annual organization Summerdays. If you havent been there, you haven't seen real life!",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Annual organization Summerdays. If you havent been there, you haven't seen real life!"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Iga aastane organisatsiooni suvepäevade üritus. Sa pole elu näinud, kui seal pole olnud"
                            }
                        }
                    }
                });
                context.ProjectTypes.Add(new ProjectType
                {
                    ProjectTypeName = "Talvepäevad",
                    ProjectTypeComments = new MultiLangString()
                    {
                        Value = "Annual organization WinterDays. If you havent been there, you haven't seen real life",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Companies have their stalls and present themselves"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Iga aastane organisatsiooni talvepäevade üritus. Sa pole elu näinud, kui seal pole olnud"
                            }
                        }
                    }
                });


                context.SaveChanges();


            }

            if (!context.UserStatuses.Any())
            {
                context.UserStatuses.Add(new UserStatus()
                {
                    UserStatusName = new MultiLangString()
                    {
                        Value = "New member",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "New member"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Uus liige"
                            }
                        }
                    }
                });

                context.UserStatuses.Add(new UserStatus()
                {
                    UserStatusName = new MultiLangString()
                    {
                        Value = "Baby member",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Baby member"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Beebiliige"
                            }
                        }
                    }
                });
                context.UserStatuses.Add(new UserStatus()
                {
                    UserStatusName = new MultiLangString()
                    {
                        Value = "Full member",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Full member"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Täisliige"
                            }
                        }
                    }
                });
                context.UserStatuses.Add(new UserStatus()
                {
                    UserStatusName = new MultiLangString()
                    {
                        Value = "Ex-member",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Ex-member"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Eksliige"
                            }
                        }
                    }
                });
                context.UserStatuses.Add(new UserStatus()
                {
                    UserStatusName = new MultiLangString()
                    {
                        Value = "Alumni",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture ="en",
                                Value = "Alumni"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Vilistlane"
                            }
                        }
                    }
                });

            }

            if (!context.Departments.Any())
            {
                context.Departments.Add(new Department
                {
                    DepartmentName = new MultiLangString()
                    {
                        Value = "Engineering Department",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Engineering Department"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Inseneriteaduskond"
                            }
                        }
                    }
                });

                context.Departments.Add(new Department
                {
                    DepartmentName = new MultiLangString()
                    {
                        Value = "Department of Science",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Department of Science"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Loodusteaduskond"
                            }
                        }
                    }
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = new MultiLangString()
                    {
                        Value = "Department of Economics",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Department of Economics"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Majandusteaduskond"
                            }
                        }
                    }
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = new MultiLangString()
                    {
                        Value = "Estonian Marine Academics",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Estonian Marine Academics"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Eesti mereakadeemia"
                            }
                        }
                    }
                });
            }

            if (!context.PositionNames.Any())
            {
                context.PositionNames.Add(new PositionName
                {
                    PositionNameName = new MultiLangString()
                    {
                        Value = "Project manager",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Project manager"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Projektijuht"
                            }
                        }
                    }
                });

                context.PositionNames.Add(new PositionName
                {
                    PositionNameName = new MultiLangString()
                    {
                        Value = "IT Coordinator",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "IT Coordinator"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "IT koordinaator"
                            }
                        }
                    }
                });
                context.PositionNames.Add(new PositionName
                {
                    PositionNameName = new MultiLangString()
                    {
                        Value = "Sales lead",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Sales lead"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Müügijuht"
                            }
                        }
                    }
                });
                context.PositionNames.Add(new PositionName
                {
                    PositionNameName = new MultiLangString()
                    {
                        Value = "Marketer",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Marketer"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Marketer"
                            }
                        }
                    }
                });
                context.PositionNames.Add(new PositionName
                {
                    PositionNameName = new MultiLangString()
                    {
                        Value = "Organizer",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Organizer"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Korraldaja"
                            }
                        }
                    }
                });
                context.PositionNames.Add(new PositionName
                {
                    PositionNameName = new MultiLangString()
                    {
                        Value = "Food responsible",
                        Translations = new List<Translation>()
                        {
                            new Translation()
                            {
                                Culture = "en",
                                Value = "Food responsible"
                            },
                            new Translation()
                            {
                                Culture = "et",
                                Value = "Toiduvastutaja"
                            }
                        }
                    }
                });



                
            }


            if (!context.Projects.Any())
            {
                context.Projects.Add(new Project
                {
                    ProjectName = "Võti Tulevikku 2018",
                    ProjectStartDate = new DateTime(2018, 3, 23),
                    ProjectEndDate = new DateTime(2018, 3, 25),
                    ProjectType = context.ProjectTypes.Where(u => u.ProjectTypeName == "Karjäärimess").Single(),
                });

                context.Projects.Add(new Project
                {
                    ProjectName = "Summer Days 2018",
                    ProjectStartDate = new DateTime(2018, 7, 15),
                    ProjectEndDate = new DateTime(2018, 7, 16),
                    ProjectType = context.ProjectTypes.Where(u => u.ProjectTypeName == "Suvepäevad").Single(),
                });

                context.Projects.Add(new Project
                {
                    ProjectName = "Carreer Day 2017",
                    ProjectStartDate = new DateTime(2017, 11, 23),
                    ProjectEndDate = new DateTime(2017, 11, 24),
                    ProjectType = context.ProjectTypes.Where(u => u.ProjectTypeName == "Firmapäev").Single(),
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

            //var userName = "admin@eesti.ee";
            var userPass = "qwerty";

            if (!context.ApplicationUser.Any())
            {
                //var user0 = new ApplicationUser {
                //    UserName = userName,
                //    Email = userName,
                //    FirstName = "Admin",
                //    LastName = "Admin",
                //    Department = context.Departments.Where(u => u.DepartmentId == 2).Single(),
                //    UserStatus = context.UserStatuses.Where(u => u.UserStatusId == 3).Single(),
                //};
                //var res = userManager.CreateAsync(user0, userPass).Result;
                //if (res == IdentityResult.Success)
                //{
                //    foreach (var role in Roles)
                //    {
                //        userManager.AddToRoleAsync(user0, role).Wait();
                //    }
                //}

               // var user1 = context.ApplicationUser.Where(u => u.UserName == "mtiganik@gmail.com").Single();
                var user1 = new ApplicationUser
                {
                    FirstName = "Mihkel",
                    LastName = "Tiganik",
                    Email = "mtiganik@gmail.com",
                    Address = "Sitsi 15-6, Tallinn",
                    Comments = "Like to Lead people",
                    Department = context.Departments.Where(u => u.DepartmentId==2).Single(),
                    Skype = "rohep2ike",
                    PhoneNumber = "55655828",
                    UserName = "mtiganik@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusId == 3).Single(),

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
                    Department = context.Departments.Where(u => u.DepartmentId==4).Single(),
                    Skype = "LiisaKern123",
                    PhoneNumber = "5284532",
                    UserName = "LiisaKern@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusId == 4).Single(),

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
                    Department = context.Departments.Where(u => u.DepartmentId == 5).Single(),
                    Skype = "tkass",
                    PhoneNumber = "55842974",
                    UserName = "tiitkass@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusId == 5).Single(),

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
                    Department = context.Departments.Where(u => u.DepartmentId == 2).Single(),
                    Skype = "akaver",
                    PhoneNumber = "65740213",
                    UserName = "akaver@gmail.com",
                    UserStatus = context.UserStatuses.Where(u => u.UserStatusId == 1).Single(),

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
                    PositionNameId = context.PositionNames.Single(u => u.PositionNameId == 5).PositionNameId,
                    ApplicationUserId = context.ApplicationUser.Single(u => u.UserName == "mtiganik@gmail.com").Id,
                    IsMarketer = true,

                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Summer Days 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameId == 5).Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "mtiganik@gmail.com").Single(),
                    IsMarketer = false,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Carreer Day 2017").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameId == 2).Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "mtiganik@gmail.com").Single(),
                    IsMarketer = true,
                });


                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Võti Tulevikku 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameId == 4).Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "LiisaKern@gmail.com").Single(),
                    IsMarketer = true,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Võti Tulevikku 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameId == 2).Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "tiitkass@gmail.com").Single(),
                    IsMarketer = false,
                });


                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Summer Days 2018").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameId == 1).Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "akaver@gmail.com").Single(),
                    IsMarketer = false,
                });

                context.Positions.Add(new Position
                {
                    Project = context.Projects.Where(u => u.ProjectName == "Carreer Day 2017").Single(),
                    PositionName = context.PositionNames.Where(u => u.PositionNameId == 5).Single(),
                    ApplicationUser = context.ApplicationUser.Where(u => u.UserName == "tiitkass@gmail.com").Single(),
                    IsMarketer = true,
                });

              

                context.SaveChangesAsync().Wait();
            }
        }


    }

}
