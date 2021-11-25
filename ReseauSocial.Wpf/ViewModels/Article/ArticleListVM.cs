using BLL.Interfaces;
using ReseauSocial.Wpf.Mappers;
using ReseauSocial.Wpf.Models;
using ReseauSocial.Wpf.Models.Enums;
using ReseauSocial.Wpf.Tools.Sessions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Mvvm.Commands;
using Tools.Patterns.Mvvm.ViewModels;

namespace ReseauSocial.Wpf.ViewModels.Article
{
    public class ArticleListVM : ViewModelCollectionBase<ArticleDetailVM>
    {
        private readonly IArticleBll _articleService;
        private readonly ISessionHelpers _sessionHelpers;
        private readonly IUserBll _userService;

        public ArticleListVM(IArticleBll articleService, ISessionHelpers sessionHelpers,IUserBll userService)
        {
            _articleService = articleService;
            _sessionHelpers = sessionHelpers;
            _userService = userService;
        }

        protected override ObservableCollection<ArticleDetailVM> LoadItems()
        {

            if (_sessionHelpers.CurentUser is null)
                return new ObservableCollection<ArticleDetailVM>();
            //string token = _sessionHelpers.CurentUser.Token;
            IEnumerable<ArticleWpf> articleList = _articleService.GetAllArticle() 
                .Select(a => { 
                    ArticleWpf articleWpf = a.ArticleBllToArticleWpf();
                    articleWpf.Auteur = _userService.GetUser(a.UserId, _sessionHelpers.CurentUser.Token);
                    return articleWpf;
                });

            if(SelectedStatus != StatusArticleEnum.Tout)
            {
                articleList = articleList.Where(a => a.StatusArticle == SelectedStatus);
            }

            return new ObservableCollection<ArticleDetailVM>(articleList.Select(a => new ArticleDetailVM(_articleService, _sessionHelpers, a, _userService)));
        }

        #region Filtre status article
        
        private StatusArticleEnum _selectedStatus = StatusArticleEnum.Tout;

        public StatusArticleEnum SelectedStatus
        {
            get { return _selectedStatus; }
            set { 
                Set(ref _selectedStatus, value);
                Refresh();
            }
        } 

        #endregion

        #region Gestion d'un article

        private ArticleDetailVM _selectedItem;

        public ArticleDetailVM SelectedItem
        {
            get { return _selectedItem; }
            set {
                Set(ref _selectedItem, value); 
            }

        }

        #endregion

        #region Commandes

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get { return _refreshCommand ??= new DelegateCommand(Refresh); }
        }

        public void Refresh()
        {
            ObservableCollection<ArticleDetailVM> listArticle = LoadItems();
            Items.Clear();
            foreach (ArticleDetailVM article in listArticle)
            {
                Items.Add(article);
            }
        }

        #endregion

    }
}

