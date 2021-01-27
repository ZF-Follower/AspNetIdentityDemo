using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebIdentityDemoV3._1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace WebIdentityDemoV3._1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //������Ҫע����� options.SignIn.RequireConfirmedAccount �����ȱʡ����Ϊtrue��
            //��������£���ע����û���Ҫ����ȷ�ϲ������ע�ᣬ���û�а�װ�ʼ�ϵͳ����������޷���ɣ����������Ϊfalse��
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) 
                .AddEntityFrameworkStores<ApplicationDbContext>();


            #region ����˵�����飺
            //�����û� //��֧��������ʽ

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.User = new UserOptions
            //    {
            //        RequireUniqueEmail = true, //Ҫ��EmailΨһ
            //        AllowedUserNameCharacters = "abcdefgABCDEFG" //������û����ַ���Ĭ���� abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+
            //    };
            //});

            //��������

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.Password = new PasswordOptions
            //    {
            //        RequireDigit = true, //Ҫ�������ֽ���0-9 ֮��,  Ĭ��true
            //        RequiredLength = 6, //Ҫ��������С���ȣ�   Ĭ���� 6 ���ַ�
            //        RequireLowercase = true, //Ҫ��Сд��ĸ,  Ĭ��true
            //        RequireNonAlphanumeric = false, //Ҫ�������ַ�,  Ĭ��true
            //        RequiredUniqueChars = 0, //Ҫ����Ҫ�����еķ��ظ��ַ���,  Ĭ��1
            //        RequireUppercase = false //Ҫ���д��ĸ ��Ĭ��true
            //    };
            //});
            //�����˻�

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.Lockout = new LockoutOptions
            //    {
            //        AllowedForNewUsers = true, // ���û������˻�, Ĭ��true
            //        DefaultLockoutTimeSpan = TimeSpan.FromHours(1), //����ʱ����Ĭ���� 5 ����
            //        MaxFailedAccessAttempts = 3 //��¼��������Դ�����Ĭ�� 5 ��
            //    };
            //});
            //���ݿ�洢 (��������ã��������� max ���ַ������ȡ�)

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.Stores = new StoreOptions
            //    {
            //        MaxLengthForKeys = 128, // ��������󳤶�
            //        ProtectPersonalData = true //�����û����ݣ�Ҫ��ʵ�� IProtectedUserStore �ӿ�
            //    };
            //});
            //��������

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.Tokens = new TokenOptions
            //    {
            //        AuthenticatorTokenProvider = "MyAuthenticatorTokenProvider", //����ʹ����֤����֤˫�ص�¼�ġ�
            //        ChangeEmailTokenProvider = "MyChangeEmailTokenProvider", //�������ɵ����ʼ�����ȷ�ϵ����ʼ���ʹ�õ����Ƶġ�
            //        ChangePhoneNumberTokenProvider = "MyChangePhoneNumberTokenProvider", //�������ɸ��ĵ绰����ʱʹ�õ����Ƶġ�
            //        EmailConfirmationTokenProvider = "MyEmailConfirmationTokenProvider", //���������ʻ�ȷ�ϵ����ʼ���ʹ�õ����Ƶ������ṩ����
            //        PasswordResetTokenProvider = "MyPasswordResetTokenProvider", //���������������õ����ʼ���ʹ�õ�����
            //        ProviderMap = new Dictionary<string, TokenProviderDescriptor>(),  //�����ṩ�������Ƶ���Կ���� �û������ṩ���� ��
            //        AuthenticatorIssuer = "Identity", //��֤��������      
            //    };
            //});
            //��������

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.ClaimsIdentity = new ClaimsIdentityOptions
            //    {
            //        RoleClaimType = "IdentityRole", // ���ڽ�ɫ�������������͡�
            //        UserIdClaimType = "IdentityId", // �����û���ʶ���������������͡�
            //        SecurityStampClaimType = "SecurityStamp", //���ڰ�ȫ���������������͡�
            //        UserNameClaimType = "IdentityName" //�����û����������������͡�
            //    };
            //});
            //��¼��֤���� (�ڵ�¼��ʱ������ֻ��Ż�����û�м���/ȷ�ϣ����޷���¼��)

            //services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.SignIn = new SignInOptions
            //    {
            //        RequireConfirmedEmail = true, //Ҫ�󼤻�����., Ĭ��false
            //        RequireConfirmedPhoneNumber = true //Ҫ�󼤻��ֻ��Ų��ܵ�¼��Ĭ��false
            //    };
            //});
            //cooke����

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.Cookie.Name = "YourAppCookieName";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = "/Identity/Account/Login";
            //    // ReturnUrlParameter requires 
            //    //using Microsoft.AspNetCore.Authentication.Cookies;
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //});
            //Password Hasher ѡ������  

            //services.Configure<PasswordHasherOptions>(option =>
            //{
            //    option.IterationCount = 12000; //ʹ�� PBKDF2 ��������й�ϣ����ʱʹ�õĵ���������
            //});
            //ȫ��Ҫ��������û����������֤

            //services.AddAuthorization(options =>
            //{
            //   options.FallbackPolicy = new AuthorizationPolicyBuilder()
            //      .RequireAuthenticatedUser()
            //      .Build();
            //});


            #endregion


            #region ���Ըĳ���������

            services.Configure<IdentityOptions>(options =>
            {
                // �����û� //��֧��������ʽ
                //options.User = new UserOptions
                //{
                //    RequireUniqueEmail = true, //Ҫ��EmailΨһ
                //    AllowedUserNameCharacters = "abcdefgABCDEFG" //������û����ַ���Ĭ���� abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+
                //};

                // �������� 
                options.Password = new PasswordOptions
                {
                    RequireDigit = false, //Ҫ�������ֽ���0-9 ֮��,  Ĭ��true
                    RequiredLength = 6, //Ҫ��������С���ȣ�   Ĭ���� 6 ���ַ�
                    RequireLowercase = false, //Ҫ��Сд��ĸ,  Ĭ��true
                    RequireNonAlphanumeric = false, //Ҫ�������ַ�,  Ĭ��true
                    RequiredUniqueChars = 0, //Ҫ����Ҫ�����еķ��ظ��ַ���,  Ĭ��1
                    RequireUppercase = false //Ҫ���д��ĸ ��Ĭ��true
                };
                //  �����˻�

                //options.Lockout = new LockoutOptions
                //{
                //    AllowedForNewUsers = true, // ���û������˻�, Ĭ��true
                //    DefaultLockoutTimeSpan = TimeSpan.FromHours(1), //����ʱ����Ĭ���� 5 ����
                //    MaxFailedAccessAttempts = 3 //��¼��������Դ�����Ĭ�� 5 ��
                //};

                //  ���ݿ�洢(��������ã��������� max ���ַ������ȡ�)

                //options.Stores = new StoreOptions
                //{
                //    MaxLengthForKeys = 128, // ��������󳤶�
                //    ProtectPersonalData = true //�����û����ݣ�Ҫ��ʵ�� IProtectedUserStore �ӿ�
                //};

                // ��������

                //options.Tokens = new TokenOptions
                //{
                //    AuthenticatorTokenProvider = "MyAuthenticatorTokenProvider", //����ʹ����֤����֤˫�ص�¼�ġ�
                //    ChangeEmailTokenProvider = "MyChangeEmailTokenProvider", //�������ɵ����ʼ�����ȷ�ϵ����ʼ���ʹ�õ����Ƶġ�
                //    ChangePhoneNumberTokenProvider = "MyChangePhoneNumberTokenProvider", //�������ɸ��ĵ绰����ʱʹ�õ����Ƶġ�
                //    EmailConfirmationTokenProvider = "MyEmailConfirmationTokenProvider", //���������ʻ�ȷ�ϵ����ʼ���ʹ�õ����Ƶ������ṩ����
                //    PasswordResetTokenProvider = "MyPasswordResetTokenProvider", //���������������õ����ʼ���ʹ�õ�����
                //    ProviderMap = new Dictionary<string, TokenProviderDescriptor>(),  //�����ṩ�������Ƶ���Կ���� �û������ṩ���� ��
                //    AuthenticatorIssuer = "Identity", //��֤��������      
                //};

                // ��������

                //options.ClaimsIdentity = new ClaimsIdentityOptions
                //{
                //    RoleClaimType = "IdentityRole", // ���ڽ�ɫ�������������͡�
                //    UserIdClaimType = "IdentityId", // �����û���ʶ���������������͡�
                //    SecurityStampClaimType = "SecurityStamp", //���ڰ�ȫ���������������͡�
                //    UserNameClaimType = "IdentityName" //�����û����������������͡�
                //};

                //��¼��֤����(�ڵ�¼��ʱ������ֻ��Ż�����û�м��� / ȷ�ϣ����޷���¼��)

                //options.SignIn = new SignInOptions
                //{
                //    RequireConfirmedEmail = true, //Ҫ�󼤻�����., Ĭ��false
                //    RequireConfirmedPhoneNumber = true //Ҫ�󼤻��ֻ��Ų��ܵ�¼��Ĭ��false
                //};

            });
            //cooke����

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.Cookie.Name = "YourAppCookieName";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = "/Identity/Account/Login";
            //    // ReturnUrlParameter requires 
            //    //using Microsoft.AspNetCore.Authentication.Cookies;
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //});
            //Password Hasher ѡ������  

            //services.Configure<PasswordHasherOptions>(option =>
            //{
            //    option.IterationCount = 12000; //ʹ�� PBKDF2 ��������й�ϣ����ʱʹ�õĵ���������
            //});
            //ȫ��Ҫ��������û����������֤

            //services.AddAuthorization(options =>
            //{
            //    options.FallbackPolicy = new AuthorizationPolicyBuilder()
            //       .RequireAuthenticatedUser()
            //       .Build();
            //});

            #endregion

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
