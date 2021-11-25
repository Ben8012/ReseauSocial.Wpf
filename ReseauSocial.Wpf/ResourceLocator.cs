using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using ReseauSocial.Wpf.Tools.Sessions;
using ReseauSocial.Wpf.ViewModels;
using ReseauSocial.Wpf.ViewModels.Article;
using ReseauSocial.Wpf.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Locator;

namespace ReseauSocial.Wpf
{
    public class ResourceLocator : LocatorBase
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISessionHelpers, SessionHelpers>();

            services.AddSingleton<IArticleDal, ArticleDalService>();
            services.AddSingleton<IArticleBll, ArticleBllService>();

            services.AddSingleton<ICommentDal, CommentDalService>();
            services.AddSingleton<ICommentBll, CommentBllService>();

            services.AddSingleton<IUserDal, UserDalService>();
            services.AddSingleton<IUserBll, UserBllService>();

            services.AddSingleton<LoginVM>();

            services.AddSingleton<UserListVM>();

            services.AddSingleton<ArticleListVM>();

            // services.AddSingleton<Main>();

        }

        public LoginVM Login
        {
            get { return GetResource<LoginVM>(); }
        }

        public UserListVM UserListVM
        {
            get { return GetResource<UserListVM>(); }
        }

        public ArticleListVM ArticleListVM
        {
            get { return GetResource<ArticleListVM>(); }
        }
    }
}
