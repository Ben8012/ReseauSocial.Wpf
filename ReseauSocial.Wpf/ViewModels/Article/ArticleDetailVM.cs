using BLL.Interfaces;
using BLL.Models;

using ReseauSocial.Wpf.Mappers;
using ReseauSocial.Wpf.Models;
using ReseauSocial.Wpf.Models.Enums;
using ReseauSocial.Wpf.Tools.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Mvvm.Commands;
using Tools.Patterns.Mvvm.ViewModels;

namespace ReseauSocial.Wpf.ViewModels.Article
{
    public class ArticleDetailVM : ViewModelBase<ArticleWpf>
    {
        private readonly IArticleBll _articleService;
        private readonly ISessionHelpers _sessionHelpers;
        private readonly IUserBll _userService;

        public ArticleDetailVM(IArticleBll articleService, ISessionHelpers sessionHelpers, ArticleWpf article, IUserBll userService) : base(article)
        {
            _articleService = articleService;
            _sessionHelpers = sessionHelpers;
            _userService = userService;

            refresh();
    }

        public int Id
        {
            get { return Entity.Id; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }

        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { Set(ref _content, value); }

        }

        private bool _commentOk;
        public bool CommentOk
        {
            get { return _commentOk; }
            set { Set(ref _commentOk, value); }

        }

        private bool _onLigne;
        public bool OnLigne
        {
            get { return _onLigne; }
            set { Set(ref _onLigne, value); }

        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { Set(ref _userId, value); }

        }


        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { Set(ref _date, value); }

        }

        private UserBll _auteur;

        public UserBll Auteur
        {
            get { return _auteur; }
            set { Set(ref _auteur, value); }

        }

        private StatusArticleEnum _statusArticle;

        public StatusArticleEnum StatusArticle
        {
            get { return _statusArticle; }
            set { Set(ref _statusArticle, value); }

        }

        public void refresh()
        {
            if (_sessionHelpers.CurentUser is null)
                return;
           // string token = _sessionHelpers.CurentUser.Token;
            ArticleWpf article = _articleService.GetArticleById(Id).ArticleBllToArticleWpf();

            article.Auteur = _userService.GetUser(article.UserId, _sessionHelpers.CurentUser.Token);
            
            Title = Entity.Title = article.Title;
            Content = Entity.Content = article.Content;
            CommentOk = Entity.CommentOk = article.CommentOk;
            OnLigne = Entity.OnLigne = article.OnLigne;
            UserId = Entity.UserId = article.UserId;
            Date = Entity.Date = article.Date;
            Auteur = Entity.Auteur = article.Auteur;
            StatusArticle = Entity.StatusArticle = article.StatusArticle;

        }


        private ICommand _blockCommand;
        public ICommand BlockCommand
        {
            get { return _blockCommand ??= new DelegateCommand(Block, CanBlock); }
        }

        public void Block()
        {
            _articleService.BlockArticle(Id, _sessionHelpers.CurentUser.Id,null);
            refresh();
        }

        private bool CanBlock()
        {
            return !_articleService.IsArticleBlock(Id);
        }

        private ICommand _unblockCommand;
        public ICommand UnblockCommand
        {
            get { return _unblockCommand ??= new DelegateCommand(UnBlock, CanUnBlock); }
        }

        public void UnBlock()
        {
            _articleService.UnBlockArticleAdmin(Id, _sessionHelpers.CurentUser.Id);
            refresh();
        }

        private bool CanUnBlock()
        {
            return _articleService.IsArticleBlock(Id);
        }

        private ICommand _unSignalCommand;
        public ICommand UnSignalCommand
        {
            get { return _unSignalCommand ??= new DelegateCommand(UnSignal, CanUnSignal); }
        }

        public void UnSignal()
        {
            _articleService.UnSignalArticleAdmin(Id, _sessionHelpers.CurentUser.Id);
            refresh();
        }

        private bool CanUnSignal()
        {
            return _articleService.IsSignalArticle(Id);
        }


    }
}
