using Microsoft.EntityFrameworkCore;
using PasaLife.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<HomeCenter> HomeCenters { get; set; }
        public DbSet<HomeCarousel> HomeCarousels { get; set; }
        public DbSet<Navbar> Navbars { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<SecondMenu> SecondMenus { get; set; }
        public DbSet<AboutCompany> AboutCompanies { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InformationCenter> InformationCenters { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportCategory> ReportCategories { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<ManagementCategory> ManagementCategories { get; set; }
        public DbSet<ManagementDetail> ManagementDetail { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<IconButton> IconButtons { get; set; }
        public DbSet<OnlineService> OnlineServices { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<NewsDetail> NewsDetails { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<ITPlatform> ITPlatforms { get; set; }
        public DbSet<FAQCategory> FAQCategories { get; set; }
        public DbSet<URLButton> URLButtons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<ProductChart> ProductCharts { get; set; }
        public DbSet<ProductInformation> ProductInformations { get; set; }
        public DbSet<SimpleProduct> SimpleProducts { get; set; }
        public DbSet<ProductDetailTitle> ProductDetailTitles { get; set; }
        public DbSet<ProductWord> ProductWords { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleCategory> RuleCategories { get; set; }
        public DbSet<AboutCompanyCart> AboutCompanyCarts { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyDetail> VacancyDetails { get; set; }
        public DbSet<AwardSeo> AwardSeos { get; set; }
        public DbSet<HomeCarouselSeo> HomeCarouselSeos{ get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().HasData(
            //    new User() {  }
            //    );
            modelBuilder.Entity<Navbar>().HasData(
                                                  new Navbar { Id = 1, AzTitle = "Haqqımızda", EnTitle = "About us", RuTitle = "О нас", URL = "" },
                                                  new Navbar { Id = 2, AzTitle = "Məhsullar", EnTitle = "Products", RuTitle = "Продукты", URL = "" },
                                                  new Navbar { Id = 3, AzTitle = "Online xidmətlər", EnTitle = "Online services", RuTitle = "Онлайн-сервисы", URL = "" },
                                                  new Navbar { Id = 4, AzTitle = "Məlumat mərkəzi", EnTitle = "Information Center", RuTitle = "Информационный центр", URL = "" },
                                                  new Navbar { Id = 5, AzTitle = "Karyera", EnTitle = "Career", RuTitle = "Карьера", URL = "" },
                                                  new Navbar { Id = 6, AzTitle = "Əlaqə", EnTitle = "Contact", RuTitle = "Контакт", URL = "" });
            modelBuilder.Entity<HomeCenter>().HasData(
                                                  new HomeCenter { Id = 1, AzTitle = "Həyat yaşam sığortası", EnTitle = "Life insurance", RuTitle = "Страхование жизни", URL = "" },
                                                  new HomeCenter { Id = 2, AzTitle = "Gəlirli həyat sığortası", EnTitle = "Profitable life insurance", RuTitle = "Выгодное страхование жизни", URL = "" },
                                                  new HomeCenter { Id = 3, AzTitle = "İcbari həyat sığortası", EnTitle = "Compulsory life insurance", RuTitle = "Обязательное страхование жизни", URL = "" });
            modelBuilder.Entity<SecondMenu>().HasData(
                                                  new SecondMenu { Id = 1, AzTitle = "Şirkət haqqında", EnTitle = "About the company", RuTitle = "О компании", URL = "" },
                                                  new SecondMenu { Id = 2, AzTitle = "Rəhbərlik", EnTitle = "Leadership", RuTitle = "Руководство", URL = "" },
                                                  new SecondMenu { Id = 3, AzTitle = "Struktur", EnTitle = "Structure", RuTitle = "Структура", URL = "" },
                                                  new SecondMenu { Id = 4, AzTitle = "Hesabatlar", EnTitle = "Reports", RuTitle = "Отчеты", URL = "" },
                                                  new SecondMenu { Id = 5, AzTitle = "Mükafatlar", EnTitle = "Awards", RuTitle = "Награды", URL = "" },
                                                  new SecondMenu { Id = 6, AzTitle = "Karyera", EnTitle = "Career", RuTitle = "Карьера", URL = "" });
            modelBuilder.Entity<About>().HasData(
                                                 new About { Id = 1, AzTitle = "PAŞA Həyat", EnTitle = "PAŞA Həyat", RuTitle = "PAŞA Həyat", AzDescription = "“PAŞA Holding” şirkətlər qrupuna daxil olan “PAŞA Həyat Sığorta” Açıq Səhmdar Cəmiyyəti 24.11.2010-cu il tarixdə Azərbaycan Respublikası Vergilər Nazirliyi tərəfindən dövlət qeydiyyatına alınaraq Azərbaycan Respublikası Maliyyə Nazirliyinin 14.02.2011-ci il tarixli lisenziyası əsasında həyat sığortası sahəsi üzrə xidmətlərin həyata keçirilməsi istiqamətində fəaliyyət göstərir.", EnDescription = "“PASHA Life Insurance” Open Joint Stock Company, which is a part of “PASHA Holding” group of companies, was registered by the Ministry of Taxes of the Republic of Azerbaijan on 24.11.2010 and provides life insurance services on the basis of the license of the Ministry of Finance of the Republic of Azerbaijan dated 14.02.2011. acts in the direction of holding.", RuDescription = "Открытое акционерное общество «PASHA Life Insurance», входящее в группу компаний «PASHA Holding», было зарегистрировано Министерством налогов Азербайджанской Республики 24.11.2010 и предоставляет услуги по страхованию жизни на основании лицензии. Министерства финансов Азербайджанской Республики от 14.02.2011 г. действует в направлении холдинга." });

            modelBuilder.Entity<Footer>().HasData(
                                                     new Footer { Id = 1, AzTitle = "infobank.az", EnTitle = "infobank.az", RuTitle = "infobank.az", URL = "https://infobank.az/" });
            modelBuilder.Entity<ManagementCategory>().HasData(
                                                     new ManagementCategory { Id = 1, AzName = "Idarə Heyəti", EnName = "Board of Directors", RuName = "Совет директоров1", },
                                                     new ManagementCategory { Id = 2, AzName = "Direktorlar Şurası", EnName = "Counsel of Directors", RuName = "Совет директоров2", }
                                                     );
            modelBuilder.Entity<AboutCompany>().HasData(
                                                     new AboutCompany
                                                     {
                                                         Id = 1,
                                                         AzTitle = "PAŞA həyat",
                                                         EnTitle = "PAŞA həyat",
                                                         RuTitle = "PAŞA həyat",
                                                         Image = "preview.jpg",
                                                         AzDescription = "a",
                                                         EnDescription = "e",
                                                         RuDescription = "r",
                                                         VideoLink = "https://www.youtube.com/embed/5O3XjaYWyq4",
                                                     });
            modelBuilder.Entity<Contact>().HasData(
                                                  new Contact { Id = 1, AzTitle = "ƏLAQƏ", EnTitle = "CONTACT", RuTitle = "КОНТАКТ",
                                                                        AzDescription = "Hər hansı bir sığorta hadisəsində sizə kömək etməkdən həmişə məmnunuq",
                                                                        EnDescription = "We are always happy to help you in any insurance event",
                                                                        RuDescription = "Мы всегда рады помочь вам в любом страховом случае.",
                                                                        AzAddress = "Bakı, Azərbaycan M.Useynov küç., 61, AZ1003",
                                                                        EnAddress = "Baku, Azerbaijan 61 M.Useynov str., AZ1003",
                                                                        RuAddress = "Баку, Азербайджан ул. М.Усейнова 61, AZ1003",
                                                                        ContactNumber= "012 942 | 994 12 525 29 42"

                                                  }
                                                  );
            modelBuilder.Entity<IconButton>().HasData(
                                                     new IconButton { Id = 1, AzName = "Şəxsi kabinet", EnName = "Personal cabinet", RuName = "Личный кабинет", URL = "https://mylife.az/" , Icon = "u.svg", });
            modelBuilder.Entity<Career>().HasData(
                                                     new Career { Id = 1, AzTitle = "BİZƏ QOŞUL", EnTitle = "JOIN US", RuTitle = "ПРИСОЕДИНЯЙТЕСЬ К НАМ",
                                                         AzDescription = "“PAŞA Həyat Sığorta” ASC dinamik inkişaf edən universal həyat sığortası şirkəti olmaqla hazırda Azərbaycan Respublikasının Sığorta qanunvericiliyi ilə nəzərdə tutulmuş həyat sığortası sinfinə aid olan bütün növ məhsulları müştərilərinə təqdim edir.“PAŞA Həyat Sığorta” ASC İcbari Sığorta Bürosunun iştirakçısıdır.",
                                                         EnDescription = "Being a dynamically developing universal life insurance company, PASHA Life Insurance OJSC currently offers its customers all types of life insurance products provided by the Insurance Legislation of the Republic of Azerbaijan. PASHA Life Insurance OJSC is a member of the Compulsory Insurance Bureau.",
                                                         RuDescription = "ОАО «PASHA Life Insurance» - динамично развивающаяся универсальная компания по страхованию жизни, в настоящее время предлагает своим клиентам все виды продуктов по страхованию жизни, предусмотренные Страховым законодательством Азербайджанской Республики. ОАО «PASHA Life Insurance» является членом Бюро по обязательному страхованию.",
                                                         Image = "preview.jpg",
                                                     });
            modelBuilder.Entity<URLButton>().HasData(
                                                     new URLButton
                                                     {
                                                         Id = 1,Name= "Haqqımızda",
                                                         URL="/aboutus",
                                                         
                                                     }, new URLButton
                                                     {
                                                         Id = 2,
                                                         Name = "Məhsullar",
                                                         URL = "/product",

                                                     }, new URLButton
                                                     {
                                                         Id = 3,
                                                         Name = "Online xidmətlər",
                                                         URL = "/onlineservices",

                                                     }, new URLButton
                                                     {
                                                         Id = 4,
                                                         Name = "Məlumat mərkəzi",
                                                         URL = "/informationcenter",

                                                     }, new URLButton
                                                     {
                                                         Id = 5,
                                                         Name = "Karyera",
                                                         URL = "/career",

                                                     }, new URLButton
                                                     {
                                                         Id = 6,
                                                         Name = "Əlaqə",
                                                         URL = "/contact",

                                                     }, new URLButton
                                                     {
                                                         Id = 7,
                                                         Name = "Şirkət haqqında",
                                                         URL = "/aboutcompany",

                                                     }, new URLButton
                                                     {
                                                         Id = 8,
                                                         Name = "Rəhbərlik",
                                                         URL = "/management",

                                                     }, new URLButton
                                                     {
                                                         Id = 9,
                                                         Name = "Struktur",
                                                         URL = "/structure",

                                                     }, new URLButton
                                                     {
                                                         Id = 10,
                                                         Name = "Hesabatlar",
                                                         URL = "/report",

                                                     }, new URLButton
                                                     {
                                                         Id = 11,
                                                         Name = "Mükafatlar",
                                                         URL = "/award",

                                                     });
            modelBuilder.Entity<Structure>().HasData(
                                                     new AboutCompany
                                                     {
                                                         Id = 1,
                                                         Image = "structure.jpg",
                                                     });
            modelBuilder.Entity<ReportCategory>().HasData(
                                                   new ReportCategory { Id = 1, AzName = "Audit rəyi", EnName = "Audit opinion", RuName = "Аудиторское заключение", },
                                                   new ReportCategory { Id = 2, AzName = "Maliyyə hesabatı", EnName = "Financial report", RuName = "финансовый отчет", },
                                                   new ReportCategory { Id = 3, AzName = "İdarəetmə hesabatı", EnName = "Management report", RuName = "Отчет руководства", }
                                                   );
            modelBuilder.Entity<AwardSeo>().HasData(
                                                     new AwardSeo 
                                                     { 
                                                        Id = 1, 
                                                        AzSeoTitle = "Mükafat Seo Başlıq",
                                                     });
            modelBuilder.Entity<HomeCarouselSeo>().HasData(
                                                    new HomeCarouselSeo
                                                    {
                                                        Id = 1,
                                                        AzSeoTitle = "HomeCarousel Seo Başlıq",
                                                    });



        }
    }
}