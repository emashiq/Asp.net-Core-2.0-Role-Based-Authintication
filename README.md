# Asp.net-Core-2.0-Role-Based-Authintication

I have use default Identity Class which i have inherited from IdentityUser
According to system everyone need to customize the user account table


I have created a class which contain the user profile information

 public class ApplicationUser : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
    }

    public class UserProfile
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string GooglePlusUrl { get; set; }
        public string OtherUrl { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ApplicationUserID { get; set; }
        

        public ApplicationUser ApplicationUser { get; set; }
    }
    
    I have maintained this with fluent api relationship in database context
    
    builder.Entity<ApplicationUser>().HasOne<UserProfile>().WithOne(x => x.ApplicationUser);
    
     in database context 
     
     then I used a command that Add-migration Initialcreate
     
     That create the database table schema
     
     In start up configuration file I have added these item as per as documentation
     
     //Connection string for Config File
     services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
          //Identity Using with role based
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services dependency inject.
            services.AddTransient<IEmailSender, EmailSender>();
            
            //policy for role based authintication
            here you can add multiple policy with your own funcitonality also
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            services.AddMvc();
            
    Now your role based .NET Core 2.0 Application is ready.
